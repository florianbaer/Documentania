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

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Win32;

    using Modules.Document.Event;
    using Modules.Document.Views;

    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;

    public class DocumentsSubMenuViewModel : BindableBase
    {
        private readonly IServiceLocator locator;

        private readonly IEventAggregator eventAggregator;

        public DocumentsSubMenuViewModel(IServiceLocator locator, IEventAggregator eventAggregator)
        {
            this.locator = locator;
            this.eventAggregator = eventAggregator;
        }

        public DelegateCommand SaveDelegateCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                        {
                            Window window = new Window() { Title = "New Document", Content = new NewDocumentView() };
                            window.ShowDialog();
                        });
            }
        }

        public DelegateCommand NewFileDialogCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                        {
                            Document document;
                            OpenFileDialog fileDialog = new OpenFileDialog();
                            fileDialog.ShowDialog();
                            using (IDocumentService documentService = this.locator.GetInstance<IDocumentService>())
                            {
                                document = new Document()
                                               {
                                                   Path = fileDialog.FileName,
                                                   DateReceived = DateTime.Now,
                                                   Imported = DateTime.Now,
                                                   Tags =
                                                       new List<Tag>()
                                                           {
                                                               new Tag() { Value = "Test" },
                                                               new Tag() { Value = "Test2" }
                                                           }
                                               };
                                documentService.AddDocument(document);

                            }
                            this.eventAggregator.GetEvent<PubSubEvent<DocumentsCollectionUpdateEvent>>().Publish(new DocumentsCollectionUpdateEvent());
                            this.eventAggregator.GetEvent<PubSubEvent<AddDocumentEvent>>().Publish(new AddDocumentEvent(document));
                        });
            }
        }
    }
}