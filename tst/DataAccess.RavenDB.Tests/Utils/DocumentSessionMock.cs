// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentSessionMock.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentSessionMock.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB.Tests.Utils
{
    using Moq;

    using Raven.Client;

    public class DocumentSessionMock
    {
        public DocumentSessionMock()
        {
            this.Mock = new Mock<IDocumentSession>();
        }

        public Mock<IDocumentSession> Mock { get; }
    }
}