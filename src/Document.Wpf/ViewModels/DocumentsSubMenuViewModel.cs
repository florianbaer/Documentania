// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentsSubMenuViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentsSubMenuViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.Wpf.ViewModels
{
    using System.Windows;

    using Document.Wpf.Filtering.Views;
    using Document.Wpf.Views;

    using Documentania.Infrastructure;

    using Microsoft.Practices.ServiceLocation;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class DocumentsSubMenuViewModel : BindableBase
    {
        private readonly IServiceLocator locator;

        private IRegionManager regionManager;

        public DocumentsSubMenuViewModel(IServiceLocator locator)
        {
            this.locator = locator;
            this.regionManager = locator.GetInstance<IRegionManager>();
        }

        public DelegateCommand AddDocumentCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                    {
                        this.regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(DocumentView).ToString());
                    });
            }
        }

        public DelegateCommand ShowFilterWindowCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                        {
                            Window window = new Window() { Content = new DocumentFilterView(), Height = 500, Width = 500 };
                            window.Show();
                        });
            }
        }
    }
}