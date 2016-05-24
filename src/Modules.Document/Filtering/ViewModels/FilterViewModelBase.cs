namespace Modules.Document.Filtering.ViewModels
{
    using Prism.Events;
    using Prism.Mvvm;

    public abstract class FilterViewModelBase : BindableBase
    {
        protected NameContainsFilterDecorator Decorator;

        private bool enabled;
        
        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
                this.OnPropertyChanged();
            }
        }

        public abstract Filter CreateFilter(Decorator filter);
    }
}