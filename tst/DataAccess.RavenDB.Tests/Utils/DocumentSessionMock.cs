using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RavenDB.Tests.Utils
{
    using Moq;

    using Raven.Client;
    using Raven.Client.Document;

    public class DocumentSessionMock
    {
        public DocumentSessionMock()
        {
            this.Mock = new Mock<IDocumentSession>();
        }

        public Mock<IDocumentSession> Mock { get; }
    }
}
