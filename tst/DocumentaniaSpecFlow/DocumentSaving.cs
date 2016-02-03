// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentSaving.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentSaving.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DataAccess.RavenDB;
using Documentania.Interfaces;
using ExAs;
using Modules.Document;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DocumentaniaSpecFlow.Tests
{
    [Binding]
    public sealed class DocumentSaving
    {
        Mock<IRepository> repoMock;

        [Given(@"I have a RavenDB Repository")]
        public void GivenIHaveARavenDBRepository()
        { 
            this.repoMock = new Mock<IRepository>();
        }

        [When(@"I add a Document to the Repository")]
        public void WhenIAddADocumentToTheRepository()
        {
            this.repoMock.Setup(x => x.GetAll<Document>()).Returns(new List<Document>() { new Document()
            {
                Id = "1",
                DateReceived = DateTime.MaxValue,
                Path = "Path"
            }});
        }

        [Then(@"I get (.*) Document when i get all Documents")]
        public void ThenIGetDocumentWhenIGetAllDocuments(int p0)
        {
            IList<Document> count = repoMock.Object.GetAll<Document>();
            Assert.AreEqual(count.Count, p0);
        }


    }
}