using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RavenDB
{
    using Raven.Client.Document;
    public class DocumentaniaDocumentStore : DocumentStore
    {
        public DocumentaniaDocumentStore(string url, string defaultDatabase)
            : base()
        {
            this.Url = url;
            this.DefaultDatabase = defaultDatabase;
        }
    }
}
