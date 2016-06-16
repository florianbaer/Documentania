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
    using System.Runtime.CompilerServices;

    using Documentania.Infrastructure.Events.SplashScreen;

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

        public DocumentModelModule(IServiceLocator locator)
        {
            this.locator = locator;
            this.container = this.locator.GetInstance<IUnityContainer>();
        }

        public void Initialize()
        {
            IEventAggregator eventAggregator = this.locator.GetInstance<IEventAggregator>();
            
            MessageUpdateEvent messageUpdate = eventAggregator.GetEvent<MessageUpdateEvent>();

            messageUpdate.Publish(new MessageUpdateEvent { Message = "Initialize Document Model module" });

            Log.Info("Initialize DocumentModelModule");


            this.container.RegisterType<IDocumentStorage, DocumentArchiveService>(new ContainerControlledLifetimeManager());
        }
    }
}