// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentsSubMenuViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentsSubMenuViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Modules.Document.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using Documentania.Infrastructure;
    using Documentania.Infrastructure.Interfaces;
    using Interfaces;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Win32;
    using Models;
    using Modules.Document.Event;
    using Modules.Document.Filtering.ViewModels;
    using Modules.Document.Filtering.Views;
    using Modules.Document.Views;

    using Prism.Commands;
    using Prism.Events;
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