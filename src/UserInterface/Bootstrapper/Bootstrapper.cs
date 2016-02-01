// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Bootstrapper.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Bootstrapper.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace UserInterface.Bootstrapper
{
    using System.Windows;

    using Documentania.Common;

    using Prism.Logging;
    using Prism.Unity;

    public class Bootstrapper : UnityBootstrapper
    {
        public Bootstrapper()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new DocumentaniaLogger();
        }

        protected override DependencyObject CreateShell()
        {
            this.Logger.Log("Show MainWindow", Category.Info, Priority.Low);
            MainWindow window = new MainWindow();
            window.Show();
            return window;
        }
    }
}