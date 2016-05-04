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
    using Documentania.Infrastructure.Models;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Win32;

    using Modules.Document.Event;
    using Modules.Document.Views;

    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using Prism.Regions;

    public class DocumentsSubMenuViewModel : BindableBase
    {
        private readonly IServiceLocator locator;

        private readonly IEventAggregator eventAggregator;

        private IRegionManager regionManager;

        public DocumentsSubMenuViewModel(IServiceLocator locator, IEventAggregator eventAggregator)
        {
            this.locator = locator;
            this.regionManager = locator.GetInstance<IRegionManager>();
            this.eventAggregator = eventAggregator;
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
    }
}