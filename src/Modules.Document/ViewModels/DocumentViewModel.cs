// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Modules.Document.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Forms;
    using Documentania.Infrastructure.Interfaces;
    using Interfaces;
    using Models;
    using Prism.Commands;
    using Prism.Mvvm;

    public enum DocumentMode
    {
        Create,
        Edit
    }

    public class DocumentViewModel : BindableBase
    {
        private DocumentMode mode;

        private IDocumentService service;

        private string tagValue;

        public DocumentViewModel(IDocumentService documentService)
        {
            this.Model = new Document();
            this.service = documentService;
            this.mode = DocumentMode.Create;
        }

        public DocumentViewModel(Document document, IDocumentService documentService)
        {
            this.service = documentService;
            this.Model = document;
            this.mode = DocumentMode.Edit;
        }

        public Document Model { get; set; }

        public string Id => this.Model.Id;

        public string Name
        {
            get
            {
                if (this.Model == null)
                {
                    this.Model = new Document();
                }
                return this.Model.Name;
            }
            set
            {
                this.Model.Name = value;
                this.OnPropertyChanged();
            }
        }

        public string Path
        {
            get
            {
                return this.Model.Path;
            }
            set
            {
                this.Model.Path = value;
                this.OnPropertyChanged();
            }
        }

        public DateTime DateReceived
        {
            get
            {
                return this.Model.DateReceived;
            }
            set
            {
                this.Model.DateReceived = value;
                this.OnPropertyChanged();
            }
        }

        public string TagValue
        {
            get
            {
                return this.tagValue;
            }
            set
            {
                this.tagValue = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Tags => new ObservableCollection<string>(this.Model.Tags);

        public DelegateCommand SaveDocumentCommand
        {
            get
            {
                return new DelegateCommand(SaveDocument, CanSaveDocument);
            }
        }

        public DelegateCommand AddTagCommand
        {
            get
            {
                return new DelegateCommand(() =>
                    {
                        // todo: cleanup what is really needed 
                        this.Model.Tags.Add(this.TagValue);
                        this.Tags.Add(this.TagValue);
                        this.OnPropertyChanged(() => this.Tags);
                        this.TagValue = string.Empty;
                    });
            }
        }

        public DelegateCommand LoadDocumentCommand
        {
            get
            {
                return new DelegateCommand(LoadDocument, CanLoadDocument);
            }
        }

        public DelegateCommand<string> RemoveTagCommand
        {
            get
            {
                return new DelegateCommand<string>(RemoveTag);
            }
        }

        private void RemoveTag(string tagToRemove)
        {
            this.Tags.Remove(tagToRemove);
            this.Model.Tags.Remove(tagToRemove);
            this.OnPropertyChanged(() => this.Tags);
        }


        private bool CanLoadDocument()
        {
            return true;
        }

        private void LoadDocument()
        {
            OpenFileDialog fileDialog = new OpenFileDialog() {Multiselect = false};
            fileDialog.ShowDialog();
            this.Path = fileDialog.FileName;

        }

        private bool CanSaveDocument()
        {
            return true;
        }

        private void SaveDocument()
        {
            this.service.AddDocument(this.Model);
            this.CleanViewModel();
        }

        private void CleanViewModel()
        {
            this.Model = new Document();
            this.OnPropertyChanged(() => this.DateReceived);
            this.OnPropertyChanged(() => this.Id);
            this.OnPropertyChanged(() => this.Name);
            this.OnPropertyChanged(() => this.Path);
            this.OnPropertyChanged(() => this.Tags);
        }
    }
}