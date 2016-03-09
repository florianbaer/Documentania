using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.Navigation
{
    using System.CodeDom;

    using Documentania.Interfaces;

    using Modules.Document.Views;

    using Prism.Regions;
    public class AllDocumentsNavigation : INavigationItem
    {
        public string content = "Test";

        IRegionManager manager;

        public AllDocumentsNavigation(IRegionManager regionManager)
        {
            
            manager = regionManager;
        }

        public void NavigateTo()
        {
            manager.RequestNavigate(RegionNames.ContentRegion, typeof(AllDocumentsView).ToString());
        }
    }
}
