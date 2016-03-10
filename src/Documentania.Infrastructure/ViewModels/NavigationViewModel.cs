namespace Documentania.Infrastructure.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Documentania.Infrastructure.Configuration;
    using Documentania.Infrastructure.Services;
    using Documentania.Infrastructure.Views;
    using Documentania.Contracts;

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

                foreach (NavigationElement navigationElement in this.configurationService.GetNavigationConfiguration().ToList())
                {
                    Assembly asm = Assembly.Load(navigationElement.Type);

                    var enumerable = asm.GetTypes().Where(x => typeof(INavigationExecution).IsAssignableFrom(x));

                    foreach (Type type in enumerable)
                    {
                        var navigationElementViewModel = new NavigationElementViewModel(this.serviceLocator.GetInstance<IRegionManager>(), type);
                        var navigationItemView = new NavigationItemView();
                        navigationItemView.DataContext = navigationElementViewModel;
                        views.Add(navigationItemView);
                        // this.serviceLocator.GetInstance<IUnityContainer>().RegisterType(typeof(INavigationExecution), type);
                    }
                }
                return views;
            }
        }
    }
}
