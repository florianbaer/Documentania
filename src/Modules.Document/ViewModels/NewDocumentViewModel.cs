// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NewDocumentViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NewDocumentViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.ViewModels
{
    using System;

    using Prism.Mvvm;
    public class NewDocumentViewModel : BindableBase
    {
         private Document model { get; set; }

        public string Id => this.model.Id;

        public string Name
        {
            get
            {
                return this.model.Name;
            }
            set
            {
                this.model.Name = value;
                this.OnPropertyChanged();
            }
        }

        public string Path => this.model.Path;
        public DateTime DateReceived
        {
            get
            {
                return this.model.DateReceived;
            }
            set
            {
                this.model.DateReceived = value;
                this.OnPropertyChanged();
            }
        }
    }
}