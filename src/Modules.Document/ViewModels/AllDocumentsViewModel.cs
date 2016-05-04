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
    using Documentania.Infrastructure.Models;

    using Microsoft.Practices.ServiceLocation;

    using Modules.Document.Event;

    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using Prism.Regions;

    public class AllDocumentsViewModel : BindableBase, INavigationAware
    {
        private readonly IDocumentService service;

        private readonly IEventAggregator eventAggregator;

        private ICollection<Document> documents = new List<Document>();

        private Document selected;
        
        public ObservableCollection<Tag>Tags { get; private set; }

        public AllDocumentsViewModel(IDocumentService service, IEventAggregator eventAggregator)
        {
            this.service = service;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<PubSubEvent<DocumentsCollectionUpdateEvent>>().Subscribe(this.UpdateCollection);
////            eventAggregator.GetEvent<PubSubEvent<AddDocumentEvent>>().Subscribe(localUpdate);
            this.Documents = this.service.GetAll();
            
        }

        private void localUpdate(AddDocumentEvent addDocumentEvent)
        {
            this.Documents.Add(addDocumentEvent.Document);
        }

        private void UpdateCollection(DocumentsCollectionUpdateEvent obj)
        {
            this.Documents = this.service.GetAll();
        }

        public Document Selected
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
                    Tags = new ObservableCollection<Tag>(this.Selected.Tags);
                }
                this.OnPropertyChanged();
            }
        }

        public ICollection<Document> Documents
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
            this.Documents = this.service.GetAll();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //
        }

        public DelegateCommand<Document> DeleteDocumentCommand
        {
            get
            {
                return new DelegateCommand<Document>(DeleteDocument);
            }
        }

        private void DeleteDocument(Document document)
        {
            this.service.DeleteDocument(document);
            this.UpdateCollection(null);
        }
    }
}