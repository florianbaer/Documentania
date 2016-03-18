// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationExecutionBase.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationExecutionBase.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Contracts
{
    using Prism.Regions;

    public abstract class NavigationExecutionBase : INavigationExecution
    {
        protected IRegionManager regionManager;

        public abstract string Title { get; }

        public abstract void NavigateTo();

        public void SetRegionManager(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
    }
}