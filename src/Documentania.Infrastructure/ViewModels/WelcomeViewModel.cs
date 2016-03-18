// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="WelcomeViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'WelcomeViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Infrastructure.ViewModels
{
    using Prism.Mvvm;
    using Prism.Regions;

    public interface IWelcomeViewModel
    {
        string Text { get; }
    }

    class WelcomeViewModel : BindableBase, IWelcomeViewModel, INavigationAware
    {
        /// <summary>
        /// Called when the implementer has been navigated to.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// Called to determine if this instance can handle the navigation request.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        /// <returns>
        /// <see langword="true"/> if this instance accepts the navigation request; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// Called when the implementer is being navigated away from.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public string Text
        {
            get
            {
                return "HALLO";
            }
        }
    }

    public class WelcomeDesignViewModel : IWelcomeViewModel
    {
        public WelcomeDesignViewModel()
        {
            this.Text = "Welcome to my design time";
        }

        public string Text { get; }
    }
}