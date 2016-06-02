// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentModelModule.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentModelModule.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.Wpf
{
    using Documentania.Infrastructure;

    using Document.Model;
    using Document.Model.DocumentStorage.Archiver;
    using Document.Model.Services;
    using Document.Wpf.Filtering.Views;
    using Document.Wpf.Navigation.Views;
    using Document.Wpf.Views;

    using Documentania.SplashScreen.Events;

    using log4net;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    using Prism.Events;
    using Prism.Modularity;
    using Prism.Regions;

    [Module(ModuleName = "DocumentWpfModule")]
    public class DocumentWpfModule : IModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentWpfModule));

        private readonly IServiceLocator locator;

        private IUnityContainer container;

        private IRegionManager regionManager;

        public DocumentWpfModule(IServiceLocator locator)
        {
            this.locator = locator;
            this.container = this.locator.GetInstance<IUnityContainer>();
            this.regionManager = this.locator.GetInstance<IRegionManager>();
        }

        public void Initialize()
        {
            this.container.Resolve<EventAggregator>().GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Initialize Document wpf module" });

            Log.Info("Initialize Document wpf Module");
            this.container.RegisterType<FilterViewBase, NameContainsFilterView>("NameFilter");
            this.container.RegisterType<FilterViewBase, TagNameContainsFilterView>("TagNameFilter");

            // Views
            this.regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(DocumentView));
            this.regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(AllDocumentsView));
            this.regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(DocumentsNavigationView));
            this.regionManager.RegisterViewWithRegion(RegionNames.SubNavigationRegion, typeof(DocumentsSubMenuView));
        }
    }
}