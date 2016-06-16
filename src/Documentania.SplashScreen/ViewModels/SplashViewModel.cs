// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SplashViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'SplashViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.SplashScreen.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    using Documentania.Infrastructure.Events.SplashScreen;

    using Prism.Events;
    using Prism.Mvvm;

    public class SplashViewModel : BindableBase
    {

        #region Declarations

        private string status;

        #endregion

        #region ctor

        public SplashViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageUpdateEvent>().Subscribe(e => UpdateMessage(e.Message));
        }

        #endregion

        #region Public Properties

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #endregion

        #region Private Methods

        private void UpdateMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            Status = string.Concat(message, "...");
        }

        #endregion
    }
}