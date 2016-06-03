namespace Document.Wpf.Filtering.ViewModels
{
    using Document.Model;
    using Model.Filter;
    using Prism.Mvvm;

    public abstract class FilterViewModelBase : BindableBase
    {
        protected Decorator Decorator;

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

        public abstract Filter CreateFilter(Filter filter);
    }
}