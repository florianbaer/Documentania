// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="RavenDbRepositoryTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'RavenDbRepositoryTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB.Tests
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Security.RightsManagement;

    using DataAccess.RavenDB.Tests.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Modules.Document;

    using Moq;

    [TestClass]
    public class RavenDbRepositoryTests
    {
        const string url = "url";

        DocumentaniaDocumentStoreMock documentStoreMock;

        [TestInitialize]
        public void TestInitialize()
        {
            documentStoreMock = new DocumentaniaDocumentStoreMock().WireUp();

            documentStoreMock.Mock.Setup(x => x.Url).Returns(url);
            documentStoreMock.Mock.Setup(x => x.Initialize());
        }

        [TestMethod]
        public void InitializeRavenDbTest()
        {
            RavenDbRepository repository = new RavenDbRepository(documentStoreMock.Mock.Object);
            repository.Dispose();

            documentStoreMock.Mock.Verify(x => x.Initialize(), Times.Once);
            documentStoreMock.Mock.Verify(x => x.OpenSession(), Times.Once);
            documentStoreMock.Mock.Verify(x => x.Dispose(), Times.Once);
            documentStoreMock.DocumentSession.Mock.Verify(x => x.Dispose(), Times.Once);
        }

        [TestMethod]
        public void AddItemTest()
        {
            Item item = new Item("1", "Name");

            documentStoreMock.DocumentSession.Mock.Setup(x => x.Store(item));

            using (RavenDbRepository repository = new RavenDbRepository(documentStoreMock.Mock.Object))
            {
                repository.Add(item);
            }

            documentStoreMock.DocumentSession.Mock.Verify(x => x.Store(item), Times.Once);
        }

        [TestMethod]
        public void GetAllItems()
        {
            this.documentStoreMock.DocumentSession.Mock.Setup(x => x.Load<Item>())
                .Returns(new Collection<Item>()
                             {
                                 new Item("1", "Path"),
                                 new Item("2", "Path2")
                             }.ToArray());

            using (RavenDbRepository repository = new RavenDbRepository(documentStoreMock.Mock.Object))
            {
                var items = repository.All<Item>().ToList();
            }

            this.documentStoreMock.DocumentSession.Mock.Verify(x => x.Load<Item>());
        }
    }
}