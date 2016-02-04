// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentaniaDocumentStoreTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentaniaDocumentStoreTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using Modules.Document;

namespace DataAccess.RavenDB.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utils;
    using ExAs;
    using NUnit.Framework;
    using Raven.Client;
    using Raven.Client.Linq;

    /// <summary>
    ///     Summary description for DocumentaniaDocumentStoreTests
    /// </summary>
    [TestFixture]
    public class DocumentaniaDocumentStoreTests
    {
        [Test]
        public void ConstructorPassingParameterTest()
        {
            const string defaultDatabase = "defaultDatabase";
            const string url = "url";

            DocumentaniaDocumentStore store = new DocumentaniaDocumentStore(url, defaultDatabase);
            store.ExAssert(x => x.Member(m => m.Url).IsEqualTo(url).Member(m => m.DefaultDatabase).IsEqualTo(defaultDatabase));
        }
    }
}