namespace Document.RavenRepository
{
    using Documentania.Infrastructure.Interfaces;
    using Microsoft.Practices.Unity;
    using Model;
    using Model.Interface;

    public static class DocumentServiceFactory
    {
        private static IDocumentMetaDataService metaDataService;
        public static IDocumentMetaDataService GetDocumentService(IUnityContainer container)
        {
            if (metaDataService == null)
            {
                IRepository repo = container.Resolve<IRepository>();
                var storage = container.Resolve<IDocumentStorage>();
                metaDataService = new DocumentMetaDataService(repo, storage);
            }
            return metaDataService;
        }
    }
}
