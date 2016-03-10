namespace Documentania.Infrastructure.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Documentania.Infrastructure.Configuration;
    using Documentania.Infrastructure.Services;
    using Documentania.Infrastructure.Views;
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

        public NavigationViewModel(IServiceLocator locator)
        {
            this.serviceLocator = locator;
            this.configurationService = this.serviceLocator.GetInstance<NavigationConfigurationService>();
        }

        public ICollection<NavigationItemView> NavigationElements
        {
            get
            {
                ICollection<NavigationItemView> views = new List<NavigationItemView>();

                foreach (NavigationElementViewModel navigationElementViewModel in this.configurationService.GetNavigationConfiguration().Select(navigationElement => new NavigationElementViewModel(this.serviceLocator.GetInstance<IRegionManager>(), navigationElement)).ToList())
                {
                    var navigationItemView = new NavigationItemView();
                    navigationItemView.DataContext = navigationElementViewModel;
                    views.Add(navigationItemView);
                }
                return views;
            }
        }
    }
}
