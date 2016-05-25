// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentModule.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentModule.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Modules.Document
{
    using Documentania.Infrastructure;
    using Documentania.Infrastructure.Interfaces;
    using Documentania.SplashScreen.Events;
    using Interfaces;
    using log4net;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    using Modules.Document.DocumentStorage.Archiver;
    using Modules.Document.Filtering.Views;
    using Modules.Document.Navigation;
    using Modules.Document.ViewModels;
    using Modules.Document.Views;
    using Prism.Events;
    using Prism.Modularity;
    using Prism.Regions;

    using DocumentsNavigationView = Modules.Document.Navigation.Views.DocumentsNavigationView;

    [Module(ModuleName = "DocumentModule")]
    public class DocumentModule : IModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentModule));

        private readonly IServiceLocator locator;

        private IUnityContainer container;

        private IRegionManager regionManager;

        public DocumentModule(IServiceLocator locator)
        {
            this.locator = locator;
            this.container = this.locator.GetInstance<IUnityContainer>();
            this.regionManager = this.locator.GetInstance<IRegionManager>();
        }

        public void Initialize()
        {
            this.container.Resolve<EventAggregator>().GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Initialize Document module" });

            Log.Info("Initialize DocumentModule");
            this.container.RegisterType<FilterViewBase, NameContainsFilterView>("NameFilter");
            this.container.RegisterType<FilterViewBase, TagNameContainsFilterView>("TagNameFilter");


            this.container.RegisterType<IDocumentStorage, DocumentArchiveService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IDocumentService, DocumentService>(new InjectionFactory(x => DocumentServiceFactory.GetDocumentService(this.container)));
            
            // Views
            this.regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(DocumentView));
            this.regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(AllDocumentsView));
            this.regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(DocumentsNavigationView));
            this.regionManager.RegisterViewWithRegion(RegionNames.SubNavigationRegion, typeof(DocumentsSubMenuView));
        }
    }
}