using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.ViewModels
{
    using Documentania.Contracts;

    using Microsoft.Practices.ServiceLocation;

    using Prism.Mvvm;
    using Prism.Regions;

    public class AllDocumentsViewModel : BindableBase, INavigationAware
    {
        private readonly IServiceLocator service;

        private ICollection<Document> documents = new List<Document>();

        private Document selected;

        public AllDocumentsViewModel(IServiceLocator service)
        {
            this.service = service;
            using (var store = this.service.GetInstance<IDocumentService>())
            {
                this.Documents = store.GetAll();
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
                this.SetProperty(ref this.selected, value);
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
            using (var store = this.service.GetInstance<IDocumentService>())
            {
                this.Documents = store.GetAll();
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
