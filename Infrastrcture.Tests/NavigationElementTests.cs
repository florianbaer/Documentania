// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationElementTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationElementTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Infrastrcture.Tests
{
    using Documentania.Infrastructure.Configuration;

    using ExAs;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                x => x.Member(m => m.Assembly).IsEqualTo(AssemblyName).Member(m => m.Type).IsEqualTo(TypeName));
        }
    }
}