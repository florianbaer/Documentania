// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="App.xaml.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'App.xaml.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania
{
    using System.Windows;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Bootstrapper bootstrapper;

        public App()
        {
            this.bootstrapper = new Bootstrapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.bootstrapper.Run();
        }
    }
}