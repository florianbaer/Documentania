// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentModelModule.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentModelModule.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.RavenRepository
{
    using Documentania.Infrastructure;
    using Documentania.Infrastructure.Events.SplashScreen;
    using Documentania.Infrastructure.Interfaces;

    using log4net;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Model;
    using Model.Interface;
    using Prism.Events;
    using Prism.Modularity;
    using Prism.Regions;

    using Raven.Client;

    [ModuleDependency("DocumentModelModule")]
    [Module(ModuleName = "DocumentRavenStorageModule")]
    public class DocumentRavenStorageModule : IModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentRavenStorageModule));

        private readonly IServiceLocator locator;

        private IUnityContainer container;
        

        public DocumentRavenStorageModule(IServiceLocator locator)
        {
            this.locator = locator;
            this.container = this.locator.GetInstance<IUnityContainer>();

            this.RunIndexes();
        }

        private void RunIndexes()
        {
            IDocumentStore storage = this.locator.GetInstance<IDocumentStore>();

            new Documents_ByTags().Execute(storage);
        }

        public void Initialize()
        {
            this.container.Resolve<EventAggregator>().GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Initialize Document raven storage module" });

            Log.Info("Initialize Document raven storage Module");

            this.container.RegisterType<IDocumentMetaDataService, DocumentMetaDataService>(new InjectionFactory(x => DocumentServiceFactory.GetDocumentService(this.container)));
        }
    }
}