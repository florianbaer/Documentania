using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentania.Infrastructure.Navigation.ViewModels
{
    using Documentania.Infrastructure.Views;

    using Microsoft.Practices.ServiceLocation;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class HomeNavigationViewModel : BindableBase
    {
        private IRegionManager regionManager;

        public HomeNavigationViewModel(IServiceLocator locator)
        {
            this.regionManager = locator.GetInstance<IRegionManager>();
        }

        public string Title
        {
            get
            {
                return "Home";
            }
        }

        public DelegateCommand AllDocumentsCommand => new DelegateCommand(
            () =>
            {
                this.regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(WelcomeView).ToString());
                this.regionManager.RequestNavigate(RegionNames.SubNavigationRegion, typeof(SubNavigationWelcomeView).ToString());
            });
    }
}
