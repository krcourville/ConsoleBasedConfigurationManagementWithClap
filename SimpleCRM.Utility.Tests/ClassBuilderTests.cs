using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SimpleCRM.Utility.Tests
{
    [TestClass]
    public class ClassBuilderTests
    {
        [TestMethod]
        public void ClassBuilderCanGenerateObservableCollectionProperty()
        {
            var builder = new ClassBuilder(
                new[] { typeof(ClassWithCollection) },
                "Test"
            );

            Debug.Write(builder.ToString());
        }
    }

    class ClassWithCollection
    {
        public virtual ICollection<Name> Names { get; set; }
    }

    class Name
    {
        public string First { get; set; }

        public virtual ClassWithCollection Parent { get; set; }
    }
}
