using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCRM.UI.WPF.ViewModel
{
    class Generator
    {
        public static string GetPropTypeName(Type type)
        {
            var nullable = Nullable.GetUnderlyingType(type);
            if (nullable != null)
            {
                return nullable.Name + "?";
            }

            return type.Name;
        }
    }
}
