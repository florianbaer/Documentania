// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AllDocumentsViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'AllDocumentsViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.Wpf.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Document.Model;
    using Document.Model.Events;
    using Document.Model.Models;

    using Microsoft.Practices.ObjectBuilder2;
    using Model.Filter;
    using Model.Interface;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using Prism.Regions;

    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public class AllDocumentsViewModel : BindableBase, INavigationAware, IDisposable
    {
        private readonly IDocumentService service;

        private readonly IEventAggregator eventAggregator;

        private Filter DocumentsFilter
        {
            get
            {
                return this.documentsFilter;
            }
            set
            {
                this.documentsFilter = value;
                this.OnPropertyChanged(() => this.Documents);
            }
        }

        private ICollection<DocumentViewModel> documents = new ObservableCollection<DocumentViewModel>();

        private DocumentViewModel selected;

        private Filter documentsFilter;

        private readonly SubscriptionToken filterEventSubscriptionToken;

        public ObservableCollection<Tag>Tags { get; private set; }

        public AllDocumentsViewModel(IDocumentService service, IEventAggregator eventAggregator)
        {
            this.service = service;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<PubSubEvent<DocumentsCollectionUpdateEvent>>().Subscribe(this.UpdateCollection);
            this.service.GetAll().ForEach(x => this.documents.Add(new DocumentViewModel(x, this.service)));
            
            this.filterEventSubscriptionToken = this.eventAggregator.GetEvent<FilterEvent>().Subscribe(
                x =>
                    {
                        this.DocumentsFilter = x;
                    });
        }
        
        private void UpdateCollection(DocumentsCollectionUpdateEvent obj)
        {
            this.documents.Clear();
            this.service.GetAll().ForEach(x => this.documents.Add(new DocumentViewModel(x, this.service)));
        }

        public DocumentViewModel Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                this.selected = value;
                if (this.selected != null)
                {
                    this.Tags = new ObservableCollection<Tag>(this.Selected.Tags);
                }
                this.OnPropertyChanged();
            }
        }

        public ICollection<DocumentViewModel> Documents
        {
            get
            {
                if (this.DocumentsFilter != null)
                {
                    ICollection<Document> list = new List<Document>();
                    this.documents.ForEach(x => list.Add(x.Model));

                    ICollection<DocumentViewModel> viewModels = new ObservableCollection<DocumentViewModel>();
                    this.DocumentsFilter.Execute(list).ForEach(x => viewModels.Add(new DocumentViewModel(x, this.service)));
                    return viewModels;
                }
                return this.documents;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.documents.Clear();
            this.service.GetAll().ForEach(x => this.documents.Add(new DocumentViewModel(x, this.service)));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //
        }

        public DelegateCommand<DocumentViewModel> DeleteDocumentCommand
        {
            get
            {
                return new DelegateCommand<DocumentViewModel>(DeleteDocument);
            }
        }

        private void DeleteDocument(DocumentViewModel document)
        {
            this.service.DeleteDocument(document.Model);
            this.UpdateCollection(null);
        }

        public void Dispose()
        {
            this.eventAggregator.GetEvent<FilterEvent>().Unsubscribe(this.filterEventSubscriptionToken);
        }
    }
}