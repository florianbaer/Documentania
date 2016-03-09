namespace Documentania.Infrastructure.ViewModels
{
    using Documentania.Interfaces;

    using Microsoft.Practices.Unity;

    using Prism.Commands;
    using Prism.Mvvm;

    public class NavigationViewModel : BindableBase
    {
        IUnityContainer serviceLocator;

        public NavigationViewModel(IUnityContainer locator)
        {
            
            this.serviceLocator = locator;
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
