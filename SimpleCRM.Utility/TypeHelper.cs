using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleCRM.Utility
{
    public class ClassBuilder
    {
        private int indentLevel = 0;

        private IEnumerable<Type> types;

        private Queue<Type> typeprocessingQueue = new Queue<Type>();

        private StringBuilder sb = new StringBuilder();

        private string targetNameSpace;
        private IEnumerable<string> additionalImports;
        private readonly IEnumerable<string> defaultImports = new[] { 
            "System",
            "System.Collections.Generic",
            "GalaSoft.MvvmLight"
        };

        public ClassBuilder(IEnumerable<Type> types, string targetNameSpace, IEnumerable<string> additionalImports = null)
        {
            this.additionalImports = additionalImports ?? new List<string>();
            this.additionalImports = defaultImports.Union(this.additionalImports);
            foreach (var t in types)
            {
                typeprocessingQueue.Enqueue(t);
            }
            this.targetNameSpace = targetNameSpace;
        }


        private void Indent()
        {
            indentLevel++;
        }

        private void Unindent()
        {
            indentLevel--;
        }

        private void Write(string format, params object[] args)
        {
            var indents = string.Join(
                string.Empty,
                Enumerable.Range(0, indentLevel).Select(s => '\t')
            );
            sb.Append(indents);
            sb.AppendLine(string.Format(format, args));
        }

        private void WriteAll(string format, IEnumerable<string> values)
        {
            foreach (var v in values)
            {
                Write(format, v);
            }
        }

        private void WriteLine()
        {
            Write(Environment.NewLine);
        }

        private void BeginBlock(string labelformat, params object[] args)
        {
            var label = string.Format(labelformat, args);
            Write(label);
            Write("{{");
            Indent();
        }

        private void EndBlock()
        {
            Unindent();
            Write("}}");
        }

        public override string ToString()
        {
            WriteAll("using {0};", additionalImports);

            BeginBlock("namespace {0}", targetNameSpace);

            while (typeprocessingQueue.Any())
            {
                RenderClass(typeprocessingQueue.Dequeue());
            }
            EndBlock();

            return sb.ToString();
        }

        private void RenderClass(Type type)
        {
            BeginBlock("class {0}ViewModel", type.Name);

            foreach (var prop in type.GetProperties())
            {
                Indent();
                Write("#region {0} Property", prop.Name);
                if (IsCollectionType(prop.PropertyType))
                {
                    RendorCollectionProperty(prop);
                }
                else
                {
                    RenderProperty(prop);
                }


                Write("#endregion");
                Unindent();
            }
            EndBlock();
        }

        private static bool IsCollectionType(Type type)
        {
            return type.IsGenericType &&
                type.Name == "ICollection`1";
        }

        private void RendorCollectionProperty(PropertyInfo prop)
        {
            var propName = prop.Name;
            var fieldName = string.Format("_{0}", prop.Name);
            var propType = GetPropTypeName(prop.PropertyType) + "ViewModel";


            Write("private ObservableCollection<{0}> {1};", propType, fieldName);

            BeginBlock("public ObservableCollection<{0}> {1}", propType, propName);
            BeginBlock("get");
            Write("return {0} ?? ({0} = new ObservableCollection<{1}>());",
                fieldName, propType);
            EndBlock();
            EndBlock();

        }

        private void RenderProperty(PropertyInfo prop)
        {
            var propName = prop.Name;
            var fieldName = string.Format("_{0}", prop.Name);
            var propType = GetPropTypeName(prop.PropertyType);
            var constName = string.Format("{0}PropertyName", propName);

            Write("public const string {0}=\"{1}\";", constName, propName);
            Write("private {0} {1};", propType, fieldName);
            BeginBlock("public {0} {1}", propType, propName);
            BeginBlock("get");
            Write("return {0};", fieldName);
            EndBlock();

            BeginBlock("set");
            BeginBlock("if( {0} == value)", fieldName);
            Write("return;");
            EndBlock();
            Write("RaisePropertyChanging({0});", constName);
            Write("{0} = value;", fieldName);
            Write("RaisePropertyChanged({0});", constName);
            EndBlock();
            EndBlock();
        }

        private string GetPropTypeName(Type type)
        {
            var nullable = Nullable.GetUnderlyingType(type);
            if (nullable != null)
            {
                return nullable.FullName + "?";
            }

            if (IsCollectionType(type))
            {
                if (type.IsGenericType)
                {
                    var basetype = type.GetGenericArguments().First().UnderlyingSystemType;
                    typeprocessingQueue.Enqueue(basetype);

                    return GetPropTypeName(basetype);
                }
            }


            return type.FullName;
        }
    }
}
