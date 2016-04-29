// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="WelcomeNavigation.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'WelcomeNavigation.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Infrastructure.Navigation
{
    using Documentania.Infrastructure.Views;

    public class WelcomeNavigation : NavigationExecutionBase
    {
        public override string Title
        {
            get
            {
                return "Welcome";
            }
        }

        public override void NavigateTo()
        {
            this.regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(WelcomeView).ToString());
        }
    }
}