namespace Documentania.Infrastructure.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Documentania.Infrastructure.Configuration;
    using Documentania.Infrastructure.Services;
    using Documentania.Interfaces;

    using Microsoft.Practices.ObjectBuilder2;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class NavigationViewModel : BindableBase
    {
        private readonly IServiceLocator serviceLocator;

        private readonly NavigationConfigurationService configurationService;

        private ICollection<NavigationElementViewModel> navigationElements;

        public NavigationViewModel(IServiceLocator locator)
        {
            this.serviceLocator = locator;
            this.configurationService = this.serviceLocator.GetInstance<NavigationConfigurationService>();
        }

        public ICollection<NavigationElementViewModel> NavigationElements
        {
            get
            {
                if (this.navigationElements == null)
                {
                    this.navigationElements = this.configurationService.GetNavigationConfiguration().Select(navigationElement => new NavigationElementViewModel(this.serviceLocator.GetInstance<IRegionManager>(), navigationElement)).ToList();
                }
                return this.navigationElements;
            }
            set
            {
                this.navigationElements = value;
            }
        }
    }
}
