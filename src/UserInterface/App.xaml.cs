// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="App.xaml.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'App.xaml.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace UserInterface
{
    using System.Windows;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Bootstrapper.Bootstrapper bootstrapper;

        public App()
        {
            this.bootstrapper = new Bootstrapper.Bootstrapper();
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            this.bootstrapper.Run();
        }
    }
}