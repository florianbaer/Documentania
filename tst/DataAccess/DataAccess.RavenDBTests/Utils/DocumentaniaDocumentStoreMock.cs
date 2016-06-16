// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentaniaDocumentStoreMock.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentaniaDocumentStoreMock.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDBTests.Utils
{
    using Moq;

    using Raven.Client;

    public class DocumentaniaDocumentStoreMock
    {
        public DocumentaniaDocumentStoreMock()
        {
            this.Mock = new Mock<IDocumentStore>();
            this.DocumentSession = new DocumentSessionMock();
        }

        public Mock<IDocumentStore> Mock { get; }

        public DocumentSessionMock DocumentSession { get; }

        public DocumentaniaDocumentStoreMock WireUp()
        {
            this.Mock.Setup(x => x.OpenSession()).Returns(this.DocumentSession.Mock.Object);
            return this;
        }
    }
}