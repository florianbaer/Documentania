using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    using Documentania.Interfaces;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    using Prism.Commands;
    using Prism.Mvvm;
    public class NavigationViewModel : BindableBase
    {
        IUnityContainer serviceLocator;

        public NavigationViewModel(IUnityContainer locator)
        {
            
            serviceLocator = locator;
        }

        public DelegateCommand OnNavigateDelegateCommand
        {
            get
            {
                return new DelegateCommand(() => this.serviceLocator.Resolve<INavigationItem>().NavigateTo());
            }
        }

    }
}
