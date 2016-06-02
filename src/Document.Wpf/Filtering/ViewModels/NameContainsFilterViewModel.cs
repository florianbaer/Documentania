// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NameContainsFilterViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NameContainsFilterViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Wpf.Filtering.ViewModels
{
    using Document.Model;

    public class NameContainsFilterViewModel : FilterViewModelBase
    {
        private string filterText;

        public NameContainsFilterViewModel()
        {
        }

        public string FilterText
        {
            get
            {
                return this.filterText;
            }
            set
            {
                this.filterText = value;
                this.OnPropertyChanged();
            }
        }

        public override Filter CreateFilter(Filter filter)
        {
            this.Decorator = new NameContainsFilterDecorator(filter, this.filterText);
            return this.Decorator;
        }
    }
}