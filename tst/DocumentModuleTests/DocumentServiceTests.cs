// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentServiceTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentServiceTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DocumentModule.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Documentania.Infrastructure.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Modules.Document;
    using Modules.Document.Interfaces;
    using Modules.Document.Models;
    using Modules.Document.Services;

    using Moq;

    using IDocumentService = Modules.Document.Interfaces.IDocumentService;

    [TestClass]
    public class DocumentServiceTests
    {
        [TestMethod]
        [TestCategory("DocumentService")]
        [TestCategory("DocumentModule")]
        [TestProperty("Created", "2016-03-17")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void AddDocumentTest()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();
            Mock<IDocumentStorage> storageMock = new Mock<IDocumentStorage>();

            Tag tagToAdd = new Tag() { Value = "Tag" };

            Document documentToAdd = new Document()
                                         {
                                             Imported = new DateTime(2013, 3, 20),
                                             Name = "DocumentName",
                                             DateReceived = new DateTime(2012, 1, 13),
                                             Path = "DocumentPath",
                                             Tags = new List<Tag>() { tagToAdd }
                                         };

            IDocumentService documentService = new DocumentService(repositoryMock.Object, storageMock.Object);
            documentService.AddDocument(documentToAdd);

            repositoryMock.Verify(x => x.Add(documentToAdd));
        }

        [TestMethod]
        [TestCategory("DocumentService")]
        [TestCategory("DocumentModule")]
        [TestProperty("Created", "2016-03-17")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void GetDocumentByIdTest()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();
            Mock<IDocumentStorage> storageMock = new Mock<IDocumentStorage>();

            Tag tagToAdd = new Tag() {Value = "Tag" };

            Document documentToFind = new Document()
                                          {
                                              Id = "ID",
                                              Imported = new DateTime(2013, 3, 20),
                                              Name = "DocumentName",
                                              DateReceived = new DateTime(2012, 1, 13),
                                              Path = "DocumentPath",
                                              Tags = new List<Tag>() { tagToAdd }
                                          };

            repositoryMock.Setup(x => x.Single<Document>(It.IsAny<Expression<Func<Document, bool>>>()));

            IDocumentService documentService = new DocumentService(repositoryMock.Object, storageMock.Object);
            documentService.GetDocumentById(documentToFind.Id);

            repositoryMock.Verify(x => x.Single<Document>(It.IsAny<Expression<Func<Document, bool>>>()));
        }

        [TestMethod]
        [TestCategory("DocumentService")]
        [TestCategory("DocumentModule")]
        [TestProperty("Created", "2016-03-17")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void GetDocumentByNameTest()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();
            Mock<IDocumentStorage> storageMock = new Mock<IDocumentStorage>();

            Tag tagToAdd = new Tag() { Value = "Tag" };

            Document documentToFind = new Document()
                                          {
                                              Id = "ID",
                                              Imported = new DateTime(2013, 3, 20),
                                              Name = "DocumentName",
                                              DateReceived = new DateTime(2012, 1, 13),
                                              Path = "DocumentPath",
                                              Tags = new List<Tag>() { tagToAdd }
                                          };

            repositoryMock.Setup(x => x.Single<Document>(It.IsAny<Expression<Func<Document, bool>>>()));

            IDocumentService documentService = new DocumentService(repositoryMock.Object, storageMock.Object);
            documentService.GetDocumentByName(documentToFind.Name);

            repositoryMock.Verify(x => x.Single<Document>(It.IsAny<Expression<Func<Document, bool>>>()));
        }
    }
}