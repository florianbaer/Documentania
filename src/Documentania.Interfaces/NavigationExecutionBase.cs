using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentania.Contracts
{
    using Prism.Regions;

    public abstract class NavigationExecutionBase : INavigationExecution
    {
        protected IRegionManager regionManager;

        public abstract void NavigateTo();

        public void SetRegionManager(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
    }
}
