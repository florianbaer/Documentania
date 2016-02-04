// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentaniaDocumentStoreTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentaniaDocumentStoreTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB.Tests
{
    using ExAs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Summary description for DocumentaniaDocumentStoreTests
    /// </summary>
    [TestClass]
    public class DocumentaniaDocumentStoreTests
    {
        [TestMethod]
        public void ConstructorPassingParameterTest()
        {
            const string defaultDatabase = "defaultDatabase";
            const string url = "url";

            DocumentaniaDocumentStore store = new DocumentaniaDocumentStore(url, defaultDatabase);
            store.ExAssert(
                x => x.Member(m => m.Url).IsEqualTo(url).Member(m => m.DefaultDatabase).IsEqualTo(defaultDatabase));
        }
    }
}