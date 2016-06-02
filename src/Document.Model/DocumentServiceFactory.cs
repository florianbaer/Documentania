namespace Document.Model
{
    using Documentania.Infrastructure.Interfaces;

    using global::Document.Model.Services;

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
