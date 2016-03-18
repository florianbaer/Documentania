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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using DataAccess.RavenDB.Tests.Utils;

    using ExAs;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class RavenDbRepositoryTests
    {
        const string url = "url";

        DocumentaniaDocumentStoreMock documentStoreMock;

        [TestInitialize]
        public void TestInitialize()
        {
            this.documentStoreMock = new DocumentaniaDocumentStoreMock().WireUp();

            this.documentStoreMock.Mock.Setup(x => x.Url).Returns(url);
            this.documentStoreMock.Mock.Setup(x => x.Initialize());
        }

        [TestMethod]
        public void InitializeRavenDbTest()
        {
            RavenDbRepository repository = new RavenDbRepository(this.documentStoreMock.Mock.Object);
            repository.Dispose();

            this.documentStoreMock.Mock.Verify(x => x.Initialize(), Times.Once);
            this.documentStoreMock.Mock.Verify(x => x.OpenSession(), Times.Once);
            this.documentStoreMock.Mock.Verify(x => x.Dispose(), Times.Once);
            this.documentStoreMock.DocumentSession.Mock.Verify(x => x.Dispose(), Times.Once);
        }

        [TestMethod]
        public void AddItemTest()
        {
            Item item = new Item("1", "Name");

            this.documentStoreMock.DocumentSession.Mock.Setup(x => x.Store(item));

            using (RavenDbRepository repository = new RavenDbRepository(this.documentStoreMock.Mock.Object))
            {
                repository.Add(item);
            }

            this.documentStoreMock.DocumentSession.Mock.Verify(x => x.Store(item), Times.Once);
        }

        [TestMethod]
        public void GetAllItems()
        {
            this.documentStoreMock.DocumentSession.Mock.Setup(x => x.Load<Item>())
                .Returns(new Collection<Item>() { new Item("1", "Path"), new Item("2", "Path2") }.ToArray());

            List<Item> items;
            using (RavenDbRepository repository = new RavenDbRepository(this.documentStoreMock.Mock.Object))
            {
                items = repository.All<Item>().ToList();
            }

            items[0].ExAssert(x => x.Member(m => m.Id).IsEqualTo("1").Member(m => m.Name).IsEqualTo("Path"));
            items[1].ExAssert(x => x.Member(m => m.Id).IsEqualTo("2").Member(m => m.Name).IsEqualTo("Path2"));

            this.documentStoreMock.DocumentSession.Mock.Verify(x => x.Load<Item>());
        }
    }
}