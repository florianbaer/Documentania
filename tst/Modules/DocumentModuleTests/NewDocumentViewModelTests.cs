using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentModule.Tests
{
    using Document.Model;
    using Document.Model.Interface;
    using Document.Wpf.ViewModels;

    using Documentania.Infrastructure.Interfaces;

    using ExAs;
    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;
    using Moq;

    [TestClass]
    public class NewDocumentViewModelTests
    {
        private const string NewDocumentName = "NewName";

        [TestMethod]
        [TestCategory("HappyCase")]
        [TestProperty("Created", "2016-03-18")]
        [TestProperty("Creator", "Florian Bär")]
        [TestCategory("DocumentModule")]
        [TestCategory("ViewModels")]
        public void NewDocumentViewModelPropertyTest()
        {
            // arrange
            Document document = new Document
            {
                Path = "Path",
                DateReceived = DateTime.Now,
                Id = "Document",
                Name = "MyDocument",
                Imported = new DateTime(2014, 03, 13, 19, 24, 00)
            };

            // act
            DocumentViewModel documentViewModel = new DocumentViewModel(new Mock<IDocumentMetaDataService>().Object) { Model = document };

            // assert
            documentViewModel.ExAssert(x => x.Member(m => m.Model).IsEqualTo(document)
                                             .Member(m => m.DateReceived).IsOnSameDayAs(document.DateReceived)
                                             .Member(m => m.Id).IsEqualTo(document.Id)
                                             .Member(m => m.Name).IsEqualTo(document.Name)
                                             .Member(m => m.Path).IsEqualTo(document.Path));
        }

        [TestMethod]
        [TestCategory("HappyCase")]
        [TestProperty("Created", "2016-03-18")]
        [TestProperty("Creator", "Florian Bär")]
        [TestCategory("ViewModels")]
        public void NewDocumentViewModelSetPropertyTest()
        {
            // arrange
            Document document = new Document
            {
                Path = "Path",
                DateReceived = DateTime.Now,
                Id = "Document",
                Name = "MyDocument",
                Imported = new DateTime(2014, 03, 13, 19, 24, 00)
            };

            // act
            DocumentViewModel documentViewModel = new DocumentViewModel(new Mock<IDocumentMetaDataService>().Object) { Model = document };

            documentViewModel.Name = NewDocumentName;

            DateTime newDateTime = new DateTime(2014, 03, 13, 14, 14, 00);
            documentViewModel.DateReceived = newDateTime;

            // assert
            documentViewModel.ExAssert(
                x =>
                x.Member(m => m.Model).IsEqualTo(document)
                    .Member(m => m.DateReceived).IsOnSameDayAs(newDateTime)
                    .Member(m => m.Name).IsEqualTo(NewDocumentName)
                    .Member(m => m.DateReceived).IsOnSameDayAs(newDateTime));
        }
    }
}
