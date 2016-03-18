// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Infrastructure.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Documentania.Contracts;
    using Documentania.Infrastructure.Configuration;
    using Documentania.Infrastructure.Services;
    using Documentania.Infrastructure.Views;

    using Microsoft.Practices.ServiceLocation;

    using Prism.Mvvm;
    using Prism.Regions;

    public class NavigationViewModel : BindableBase
    {
        private readonly NavigationConfigurationService configurationService;

        private readonly IServiceLocator serviceLocator;

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

                foreach (
                    NavigationElement navigationElement in
                        this.configurationService.GetNavigationConfiguration().ToList())
                {
                    Assembly asm = Assembly.Load(navigationElement.Assembly);

                    var enumerable = asm.GetTypes().Where(x => typeof(INavigationExecution).IsAssignableFrom(x));

                    foreach (Type type in enumerable)
                    {
                        if (navigationElement.Type == type.Name)
                        {
                            var navigationElementViewModel =
                                new NavigationElementViewModel(this.serviceLocator.GetInstance<IRegionManager>(), type);
                            var navigationItemView = new NavigationItemView();
                            navigationItemView.DataContext = navigationElementViewModel;
                            views.Add(navigationItemView);
                        }
                    }
                }
                return views;
            }
        }
    }
}