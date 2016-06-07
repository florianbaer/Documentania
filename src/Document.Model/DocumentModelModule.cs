// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentModelModule.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentModelModule.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.Model
{
    using Documentania.SplashScreen.Events;
    using DocumentStorage.Archiver;
    using Interface;
    using log4net;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Prism.Events;
    using Prism.Modularity;
    using Prism.Regions;

    [Module(ModuleName = "DocumentModelModule")]
    public class DocumentModelModule : IModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentModelModule));

        private readonly IServiceLocator locator;

        private IUnityContainer container;

        private IRegionManager regionManager;

        public DocumentModelModule(IServiceLocator locator)
        {
            this.locator = locator;
            this.container = this.locator.GetInstance<IUnityContainer>();
            this.regionManager = this.locator.GetInstance<IRegionManager>();
        }

        public void Initialize()
        {
            this.container.Resolve<EventAggregator>().GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Initialize Document Model module" });

            Log.Info("Initialize DocumentModelModule");


            this.container.RegisterType<IDocumentStorage, DocumentArchiveService>(new ContainerControlledLifetimeManager());
        }
    }
}