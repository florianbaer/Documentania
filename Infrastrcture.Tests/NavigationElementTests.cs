using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastrcture.Tests
{
    using System.Security.Cryptography.X509Certificates;

    using Documentania.Infrastructure.Configuration;

    using ExAs;

    [TestClass]
    public class NavigationElementTests
    {
        private const string AssemblyName = "Assembly";
        private const string TypeName = "Type";

        [TestMethod]
        public void PropertyTest()
        {
            NavigationElement element = new NavigationElement() { Type = TypeName, Assembly = AssemblyName };

            element.ExAssert(
                x => x.Member(m => m.Assembly).IsEqualTo(AssemblyName)
                      .Member(m => m.Type).IsEqualTo(TypeName));
        }
    }
}
