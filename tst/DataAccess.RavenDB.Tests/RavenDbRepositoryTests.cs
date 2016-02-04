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
    using DataAccess.RavenDB.Tests.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class RavenDbRepositoryTests
    {
        [TestMethod]
        public void InitializeRavenDbTest()
        {
            const string url = "url";

            DocumentaniaDocumentStoreMock documentStoreMock = new DocumentaniaDocumentStoreMock().WireUp();

            documentStoreMock.Mock.Setup(x => x.Url).Returns(url);
            documentStoreMock.Mock.Setup(x => x.Initialize());

            RavenDBRepository repository = new RavenDBRepository(documentStoreMock.Mock.Object);
            repository.Dispose();

            documentStoreMock.Mock.Verify(x => x.Initialize(), Times.Once);
            documentStoreMock.Mock.Verify(x => x.OpenSession(), Times.Once);
            documentStoreMock.Mock.Verify(x => x.Dispose(), Times.Once);
            documentStoreMock.DocumentSession.Mock.Verify(x => x.Dispose(), Times.Once);
        }

        [TestMethod]
        public void AddItemTest()
        {
            const string url = "url";

            DocumentaniaDocumentStoreMock documentStoreMock = new DocumentaniaDocumentStoreMock().WireUp();

            documentStoreMock.Mock.Setup(x => x.Url).Returns(url);
            documentStoreMock.Mock.Setup(x => x.Initialize());

            Item item = new Item("1", "Name");

            documentStoreMock.DocumentSession.Mock.Setup(x => x.Store(item));

            using(RavenDBRepository repository = new RavenDBRepository(documentStoreMock.Mock.Object))
            {
                repository.Add(item);
            }

            documentStoreMock.DocumentSession.Mock.Verify(x => x.Store(item), Times.Once);
        }
    }
}