// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentParserTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentParserTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace DocumentModule.Tests
{
    using System;
    using System.IO;

    using Document.Model.DocumentStorage.Archiver;
    using Document.Model.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class DocumentParserTests
    {
        [TestMethod]
        [TestCategory("DocumentParser")]
        [TestCategory("DocumentModule")]
        [TestProperty("Created", "2016-05-23")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        [DeploymentItem("Resources")]
        public void ParseDocumenZip()
        {
            string documentId = "d7bfe8af-ca61-4969-9f13-30a2db63d1d5";
            Document document = new DocumentParser().ParseDocument(Path.Combine(Environment.CurrentDirectory, documentId + ".document"));
            Assert.AreEqual(documentId, document.Id);
        }
    }
}