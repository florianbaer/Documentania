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

    using Microsoft.Practices.ServiceLocation;

    using Modules.Document.Event;

    using Prism.Events;
    using Prism.Mvvm;
    using Prism.Regions;

    public class AllDocumentsViewModel : BindableBase, INavigationAware
    {
        private readonly IServiceLocator service;

        private readonly IEventAggregator eventAggregator;

        private ICollection<Document> documents = new List<Document>();

        private Document selected;

        public AllDocumentsViewModel(IServiceLocator service, IEventAggregator eventAggregator)
        {
            this.service = service;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<PubSubEvent<DocumentsCollectionUpdateEvent>>().Subscribe(this.UpdateCollection);
            eventAggregator.GetEvent<PubSubEvent<AddDocumentEvent>>().Subscribe(localUpdate);
            using (var documentService = this.service.GetInstance<IDocumentService>())
            {
                this.Documents = documentService.GetAll();
            }
        }

        private void localUpdate(AddDocumentEvent addDocumentEvent)
        {
            this.Documents.Add(addDocumentEvent.Document);
        }

        private void UpdateCollection(DocumentsCollectionUpdateEvent obj)
        {
            using (var documentService = this.service.GetInstance<IDocumentService>())
            {
                this.Documents = documentService.GetAll();
            }
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
            using (var documentService = this.service.GetInstance<IDocumentService>())
            {
                this.Documents = documentService.GetAll();
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //
        }
    }
}