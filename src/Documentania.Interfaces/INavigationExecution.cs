// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="INavigationExecution.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'INavigationExecution.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.Contracts
{
    using Prism.Regions;

    public interface INavigationExecution
    {
        void NavigateTo();

        void SetRegionManager(IRegionManager regionManager);
    }
}