using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document
{
    using Documentania.Infrastructure.Interfaces;
    using Interfaces;
    using Microsoft.Practices.Unity;

    public static class DocumentServiceFactory
    {
        private static IDocumentService service;
        public static IDocumentService GetDocumentService(IUnityContainer container)
        {
            if (service == null)
            {
                IRepository repo = container.Resolve<IRepository>();
                var storage = container.Resolve<IDocumentStorage>();
                service = new DocumentService(repo, storage);
            }
            return service;
        }
    }
}
