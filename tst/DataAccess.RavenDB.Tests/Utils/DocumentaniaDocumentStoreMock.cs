using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RavenDB.Tests.Utils
{
    using Moq;

    using Raven.Client;

    public class DocumentaniaDocumentStoreMock
    {
        public Mock<IDocumentStore> Mock { get; }

        public DocumentaniaDocumentStoreMock()
        {
            this.Mock = new Mock<IDocumentStore>();
            this.DocumentSession = new DocumentSessionMock();
        }

        public DocumentSessionMock DocumentSession { get; }

        public DocumentaniaDocumentStoreMock WireUp()
        {
            this.Mock.Setup(x => x.OpenSession()).Returns(this.DocumentSession.Mock.Object);
            return this;
        }
    }
}
