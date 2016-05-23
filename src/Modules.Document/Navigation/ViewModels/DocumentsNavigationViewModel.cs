// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentsNavigationViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentsNavigationViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Navigation.ViewModels
{
    using Documentania.Infrastructure;

    using Microsoft.Practices.ServiceLocation;

    using Modules.Document.Views;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class DocumentsNavigationViewModel : BindableBase
    {
        private IRegionManager regionManager;

        public DocumentsNavigationViewModel(IServiceLocator locator)
        {
            this.regionManager = locator.GetInstance<IRegionManager>();
        }

        public string Title
        {
            get
            {
                return "All Documents";
            }
        }

        public DelegateCommand AllDocumentsCommand => new DelegateCommand(
            () =>
                {
                    this.regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(AllDocumentsView).ToString());
                    this.regionManager.RequestNavigate(RegionNames.SubNavigationRegion, typeof(DocumentsSubMenuView).ToString());
                });
    }
}