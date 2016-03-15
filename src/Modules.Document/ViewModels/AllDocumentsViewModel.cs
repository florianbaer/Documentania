using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.ViewModels
{
    using Documentania.Contracts;

    using Prism.Mvvm;
    using Prism.Regions;

    public class AllDocumentsViewModel : BindableBase, INavigationAware
    {
        private readonly IDocumentService service;

        private ICollection<Document> documents = new List<Document>();

        private Document selected;

        private string selectedPath;

        public AllDocumentsViewModel(IDocumentService service)
        {
            this.service = service;
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
                this.SetProperty(ref this.selected, value);
                this.SetProperty(ref this.selectedPath, value.Path);
            }
        }

        public string SelectedPath
        {
            get
            {
                return this.selectedPath;
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
                this.SetProperty(ref this.documents, value);
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
    }
}
