// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentFilterViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentFilterViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Filtering.ViewModels
{
    using System.Security.RightsManagement;

    using Prism.Events;

    public class DocumentFilterViewModel
    {
        private IEventAggregator eventAggregator;

        public DocumentFilterViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public string Title => "hallo";
    }
}