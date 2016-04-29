// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AllDocumentsNavigation.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'AllDocumentsNavigation.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Modules.Document.Navigation
{
    using Documentania.Infrastructure;

    using Modules.Document.Views;

    public class AllDocumentsNavigation : NavigationExecutionBase
    {
        public override string Title
        {
            get
            {
                return "All Documents";
            }
        }

        public override void NavigateTo()
        {
            this.regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(AllDocumentsView).ToString());
            this.regionManager.RequestNavigate(RegionNames.SubNavigationRegion, typeof(DocumentsSubMenuView).ToString());
        }
    }
}