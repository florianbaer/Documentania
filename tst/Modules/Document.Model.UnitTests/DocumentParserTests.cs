// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentParserTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentParserTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model.UnitTests
{
    using System;
    using System.IO;

    using Document.Model.DocumentStorage.Archiver;
    using Document.Model.Interface;
    using Document.Model.Models;

    using ExAs;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class DocumentParserTests
    {
        [TestMethod]
        [TestCategory("DocumentParser")]
        [TestCategory("DocumentModule")]
        [TestProperty("Created", "2016-05-23")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void ParseDocumenZip()
        {
            Document expectedDocument = new Document() { Id = "d7bfe8af-ca61-4969-9f13-30a2db63d1d5" };

            Mock<IServiceLocator> locatorMock = new Mock<IServiceLocator>();
            Mock<IFileInfoSerializeService> fileInfoSerializerMock = new Mock<IFileInfoSerializeService>();
            Mock<IZipProvider> zipProviderMock = new Mock<IZipProvider>();

            zipProviderMock.Setup(
                x =>
                x.Extract(
                    Path.Combine(Environment.CurrentDirectory, expectedDocument.Id + ".document"),
                    It.IsAny<string>(),
                    null));

            fileInfoSerializerMock.Setup(x => x.Deserialize(It.IsAny<string>())).Returns(expectedDocument);

            locatorMock.Setup(x => x.GetInstance<IFileInfoSerializeService>()).Returns(fileInfoSerializerMock.Object);

            Document document = new DocumentParser(locatorMock.Object).ParseDocument(Path.Combine(Environment.CurrentDirectory, expectedDocument.Id + ".document"), zipProviderMock.Object);
            document.ExAssert(m => m.Member(x => x.Id).IsEqualTo(expectedDocument.Id));

            locatorMock.Verify(x => x.GetInstance<IFileInfoSerializeService>(), Times.Once);
            fileInfoSerializerMock.Verify(x => x.Deserialize(It.IsAny<string>()), Times.Once);
            zipProviderMock.Verify(x => x.Extract(It.IsAny<string>(), It.IsAny<string>(), null), Times.Once);
        }

        [TestMethod]
        [TestCategory("DocumentParser")]
        [TestCategory("DocumentModule")]
        [TestProperty("Created", "2016-05-23")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("SadCase")]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseDocumenZipFileNotFound()
        {
            Document expectedDocument = new Document() { Id = "d7bfe8af-ca61-4969-9f13-30a2db63d1d5" };

            Mock<IServiceLocator> locatorMock = new Mock<IServiceLocator>();
            Mock<IFileInfoSerializeService> fileInfoSerializerMock = new Mock<IFileInfoSerializeService>();
            Mock<IZipProvider> zipProviderMock = new Mock<IZipProvider>();

            fileInfoSerializerMock.Setup(x => x.Deserialize(It.IsAny<string>())).Returns(expectedDocument);

            locatorMock.Setup(x => x.GetInstance<IFileInfoSerializeService>()).Returns(fileInfoSerializerMock.Object);

            Document document = new DocumentParser(locatorMock.Object).ParseDocument(string.Empty, zipProviderMock.Object);
            Assert.AreEqual(expectedDocument.Id, document.Id);
        }
    }
}