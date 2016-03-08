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
    using Documentania.Interfaces;

    using log4net;

    using Microsoft.Practices.Unity;

    using Prism.Logging;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;

    using UserInterface.Views;

    /// <summary>
    ///     The Bootstrapper of Documentania which is as prism implemented.
    /// </summary>
    /// <seealso cref="Prism.Unity.UnityBootstrapper" />
    public class Bootstrapper : UnityBootstrapper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Bootstrapper));

        public Bootstrapper()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new DocumentaniaLogger();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            var serviceLocator = new UnityServiceLocator(this.Container);
            this.Container.RegisterInstance(serviceLocator);
        }

        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            Log.Debug("Show Shell");
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            var shell = (Shell)this.Shell;
            Application.Current.MainWindow = shell;

            var regionManager = this.Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(WelcomeUserControl));

            shell.ShowDialog();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }
    }
}