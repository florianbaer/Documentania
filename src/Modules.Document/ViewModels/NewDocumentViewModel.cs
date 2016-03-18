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
        public Document Model { get; set; }

        public string Id => this.Model.Id;

        public string Name
        {
            get
            {
                return this.Model.Name;
            }
            set
            {
                this.Model.Name = value;
                this.OnPropertyChanged();
            }
        }

        public string Path => this.Model.Path;

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
    }
}