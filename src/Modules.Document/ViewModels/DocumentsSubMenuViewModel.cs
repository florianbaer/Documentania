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

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Win32;

    using Prism.Commands;
    using Prism.Mvvm;

    public class DocumentsSubMenuViewModel : BindableBase
    {
        private readonly IServiceLocator locator;

        public DocumentsSubMenuViewModel(IServiceLocator locator)
        {
            this.locator = locator;
        }

        public DelegateCommand SaveDelegateCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                        {
                            OpenFileDialog fileDialog = new OpenFileDialog();
                            fileDialog.ShowDialog();
                            using (IDocumentService documentService = this.locator.GetInstance<IDocumentService>())
                            {
                                documentService.AddDocument(
                                    new Document()
                                        {
                                            Path = fileDialog.FileName,
                                            DateReceived = DateTime.Now,
                                            Imported = DateTime.Now
                                        });
                            }
                        });
            }
        }
    }
}