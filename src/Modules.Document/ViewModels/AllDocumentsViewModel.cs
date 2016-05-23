// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AllDocumentsViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'AllDocumentsViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Modules.Document.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using Documentania.Infrastructure.Interfaces;
    using Interfaces;

    using Microsoft.Practices.ObjectBuilder2;
    using Microsoft.Practices.ServiceLocation;
    using Models;
    using Modules.Document.Event;

    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using Prism.Regions;

    public class AllDocumentsViewModel : BindableBase, INavigationAware
    {
        private readonly IDocumentService service;

        private readonly IEventAggregator eventAggregator;

        private ICollection<DocumentViewModel> documents = new ObservableCollection<DocumentViewModel>();

        private DocumentViewModel selected;
        
        public ObservableCollection<string>Tags { get; private set; }

        public AllDocumentsViewModel(IDocumentService service, IEventAggregator eventAggregator)
        {
            this.service = service;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<PubSubEvent<DocumentsCollectionUpdateEvent>>().Subscribe(this.UpdateCollection);
            this.service.GetAll().ForEach(x => this.Documents.Add(new DocumentViewModel(x, this.service)));
        }
        
        private void UpdateCollection(DocumentsCollectionUpdateEvent obj)
        {
            this.Documents.Clear();
            this.service.GetAll().ForEach(x => this.Documents.Add(new DocumentViewModel(x, this.service)));
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
                    this.Tags = new ObservableCollection<string>(this.Selected.Tags);
                }
                this.OnPropertyChanged();
            }
        }

        public ICollection<DocumentViewModel> Documents
        {
            get
            {
                return this.documents;
            }
            set
            {
                this.documents = value;
                this.OnPropertyChanged();
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.Documents.Clear();
            this.service.GetAll().ForEach(x => this.Documents.Add(new DocumentViewModel(x, this.service)));
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
    }
}