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

    using Modules.Document.Filtering.Events;

    using Prism.Commands;
    using Prism.Events;

    public class DocumentFilterViewModel
    {
        private IEventAggregator eventAggregator;

        private Filter DocumentFilters;

        private bool filterApplied = false;

        public DocumentFilterViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.DocumentFilters = new AllDocumentsFilter();
        }

        public string Title => "hallo";

        public DelegateCommand ApplyFilterCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                        {
                            if (this.filterApplied)
                            {
                                this.DocumentFilters = new NameContainsFilterDecorator(new AllDocumentsFilter(), "ei");
                            }
                            else
                            {
                                this.DocumentFilters = new AllDocumentsFilter();
                            }
                            this.eventAggregator.GetEvent<FilterEvent>().Publish(this.DocumentFilters);
                            this.filterApplied = !this.filterApplied;
                        });

            }
        }
    }
}