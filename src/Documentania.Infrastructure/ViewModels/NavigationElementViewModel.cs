using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentania.Infrastructure.ViewModels
{
    using System.Reflection;

    using Documentania.Infrastructure.Configuration;
    using Documentania.Contracts;

    using Prism.Commands;
    using Prism.Regions;

    public class NavigationElementViewModel
    {
        private readonly IRegionManager regionManager;

        private readonly Type type;

        public NavigationElementViewModel(IRegionManager regionManager, Type type)
        {
            this.regionManager = regionManager;
            this.type = type;
        }

        public string Titel => "Test";

        public Type Type => this.type;

        public DelegateCommand NavigateCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                        {
                            INavigationExecution instance = (INavigationExecution)Activator.CreateInstance(this.Type);
                            instance.SetRegionManager(this.regionManager);
                            var methodInfo = this.Type.GetMethod("NavigateTo");
                            methodInfo.Invoke(instance, null);
                        });
            }
        }
    }
}
