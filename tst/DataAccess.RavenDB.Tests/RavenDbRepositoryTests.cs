using System;

namespace DataAccess.RavenDB.Tests
{
    using DataAccess.RavenDB.Tests.Utils;

    using Moq;

    using NUnit.Framework;

    using Raven.Client.Document;

    [TestFixture]
    public class RavenDbRepositoryTests
    {
        [Test]
        public void InitializeRavenDbTest()
        {
            const string defaultDatabase = "defaultDatabase";
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

        [Test]
        public void AddItemTest()
        {
            const string defaultDatabase = "defaultDatabase";
            const string url = "url";

            DocumentaniaDocumentStoreMock documentStoreMock = new DocumentaniaDocumentStoreMock().WireUp();
            
            documentStoreMock.Mock.Setup(x => x.Url).Returns(url);
            documentStoreMock.Mock.Setup(x => x.Initialize());

            Item item = new Item("1", "Name");

            documentStoreMock.DocumentSession.Mock.Setup(x => x.Store(item));

            using (RavenDBRepository repository = new RavenDBRepository(documentStoreMock.Mock.Object))
            {
                repository.Add<Item>(item);
            }

            documentStoreMock.DocumentSession.Mock.Verify(x => x.Store(item), Times.Once);
        }
    }
}
