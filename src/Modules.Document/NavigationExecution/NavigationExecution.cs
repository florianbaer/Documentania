// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationExecution.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationExecution.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.NavigationExecution
{
    using Documentania.Contracts;

    using Modules.Document.Views;

    using Prism.Regions;

    public class NavigationExecution : NavigationExecutionBase
    {
        public override void NavigateTo()
        {
            base.regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(AllDocumentsView).ToString());
        }
    }
}