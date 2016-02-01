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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataAccess.RavenDB.Tests.Utils;

    using ExAs;

    using NUnit.Framework;

    using Raven.Client;
    using Raven.Client.Linq;

    /// <summary>
    /// Summary description for DocumentaniaDocumentStoreTests
    /// </summary>
    [TestFixture]
    public class DocumentaniaDocumentStoreTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            UnitTestBootstrapper bootstrapper = new UnitTestBootstrapper();
            bootstrapper.Run();
        }

        [Test]
        public void CreateDocumentAndReadTagsTest()
        {
            using (IDocumentStore store = new DocumentaniaDocumentStore("http://localhost:1303", "Documentania"))
            {
                store.Initialize();
                // initializes document store, by connecting to server and downloading various configurations

                // opens a session that will work in context of 'DefaultDatabase'
                using (IDocumentSession session = store.OpenSession())
                {
                    Document document = new Document
                                            {
                                                Imported = DateTime.Now,
                                                Path = "Baden",
                                                Tags = new List<Tag> { new Tag { Value = "Test" } }
                                            };

                    Document testDocument = new Document
                                                {
                                                    Imported = DateTime.Now,
                                                    Path = "Baden",
                                                    Tags = new List<Tag> { new Tag { Value = "Test" } }
                                                };

                    session.Store(document);
                    session.Store(testDocument);

                    session.SaveChanges(); // sends all changes to server

                    string documentId = document.Id; // Session.Store will assign Id to employee, if it is not set

                    List<Document> documents =
                        session.Query<Document>().Where(doc => doc.Tags.Any(tag => tag.Value == "Test")).ToList();

                    documents.ExAssert(x => x.Member(m => m.Count).IsEqualTo(2));
                }
            }
        }

        [Test]
        public void CreateDocumentAndReadTest()
        {
            using (IDocumentStore store = new DocumentaniaDocumentStore("http://localhost:1303", "Documentania"))
            {
                store.Initialize();
                // initializes document store, by connecting to server and downloading various configurations

                // opens a session that will work in context of 'DefaultDatabase'
                using (IDocumentSession session = store.OpenSession())
                {
                    Document document = new Document
                                            {
                                                Imported = DateTime.Now,
                                                Path = "Baden",
                                                Tags = new List<Tag> { new Tag { Value = "Test" } }
                                            };

                    session.Store(document); // stores employee in session, assigning it to a collection `Employees`

                    string documentId = document.Id; // Session.Store will assign Id to employee, if it is not set

                    session.SaveChanges(); // sends all changes to server

                    // Session implements Unit of Work pattern,
                    // therefore employee instance would be the same and no server call will be made
                    Document loadedDocument = session.Load<Document>(documentId);
                    document.ExAssert(
                        d =>
                        d.Member(m => m.Path)
                            .IsEqualTo(loadedDocument.Path)
                            .Member(m => m.Imported)
                            .IsOnSameDayAs(loadedDocument.Imported)
                            .Member(m => m.Tags.FirstOrDefault(x => x.Value == "Test"))
                            .IsNotNull());
                }
            }
        }

        [TearDown]
        public void DeleteDatebase()
        {
            DatabaseEnvironment.DropDatabase();
        }
    }
}