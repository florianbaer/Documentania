namespace Document.RavenRepository
{
    using Documentania.Infrastructure.Interfaces;
    using Microsoft.Practices.Unity;
    using Model;
    using Model.Interface;

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
