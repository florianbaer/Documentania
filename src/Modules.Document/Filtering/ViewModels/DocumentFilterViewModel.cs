﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentFilterViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentFilterViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Filtering.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Security.RightsManagement;

    using log4net.Filter;
    using Microsoft.Practices.Unity;

    using Modules.Document.Filtering.Events;
    using Modules.Document.Filtering.Views;
    using Modules.Document.Interfaces;

    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;

    public class DocumentFilterViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;

        private Filter documentFilters;


        private IUnityContainer container;

        private ObservableCollection<FilterViewBase> filters;

        public DocumentFilterViewModel(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.container = container;
            this.Filters = new ObservableCollection<FilterViewBase>(this.container.ResolveAll<FilterViewBase>());
        }

        public ObservableCollection<FilterViewBase> Filters
        {
            get
            {
                return this.filters;
            }
            set
            {
                this.filters = value;
                this.OnPropertyChanged();
            }
        }

        public DelegateCommand ApplyFilterCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                        {
                            this.documentFilters = new AllDocumentsFilter();

                            foreach (FilterViewBase filterView in this.Filters)
                            {
                                var viewModel = ((FilterViewModelBase)filterView.DataContext);
                                if (viewModel.Enabled)
                                {
                                    this.documentFilters = viewModel.CreateFilter(this.documentFilters);
                                }
                            }
                            this.eventAggregator.GetEvent<FilterEvent>().Publish(this.documentFilters);
                        });

            }
        }
    }
}