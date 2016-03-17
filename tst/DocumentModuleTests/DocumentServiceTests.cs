using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentModule.Tests
{
    using System.Collections.Generic;

    using Documentania.Contracts;

    using Modules.Document;

    using Moq;

    [TestClass]
    public class DocumentServiceTests
    {
        [TestMethod]
        [TestCategory("PropertyTests")]
        [TestCategory("DocumentModule")]
        [TestProperty("Created", "2016-03-17")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void AddDocumentTest()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();

            Tag tagToAdd = new Tag() { Value = "Tag" };

            Document documentToAdd = new Document()
                                         {
                                             Imported = new DateTime(2013, 3, 20),
                                             Name = "DocumentName",
                                             DateReceived = new DateTime(2012, 1, 13),
                                             Path = "DocumentPath",
                                             Tags = new List<Tag>() { tagToAdd }
                                         };

            IDocumentService documentService = new DocumentService(repositoryMock.Object);
            documentService.AddDocument(documentToAdd);

            repositoryMock.Verify(x => x.Add(documentToAdd));
        }
    }
}
