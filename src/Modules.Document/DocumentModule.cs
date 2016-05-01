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
    using log4net;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

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
            this.container.Resolve<EventAggregator>().GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Document module" });

            Log.Info("Initialize DocumentModule");

            this.container.RegisterType<IDocumentService, DocumentService>(new TransientLifetimeManager());

            this.container.RegisterType<AllDocumentsViewModel, AllDocumentsViewModel>();

            this.container.Resolve<EventAggregator>().GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Registering views" });

            // Views
            this.regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(AllDocumentsView));
            this.regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(DocumentsNavigationView));
            this.regionManager.RegisterViewWithRegion(RegionNames.SubNavigationRegion, typeof(DocumentsSubMenuView));
        }
    }
}