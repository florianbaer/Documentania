// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="RavenDbRepositoryTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'RavenDbRepositoryTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDBTests
{
    using DataAccess.RavenDB;
    using DataAccess.RavenDBTests.Utils;

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

            this.documentStoreMock.Mock.Verify(x => x.Initialize(), Times.Never);
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
    }
}