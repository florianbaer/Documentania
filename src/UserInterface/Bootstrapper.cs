// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Bootstrapper.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Bootstrapper.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania
{
    using System.Windows;

    using Documentania.Infrastructure;
    using Documentania.Infrastructure.Logger;
    using Documentania.Infrastructure.Views;
    using Infrastructure.Interfaces;
    using log4net;

    using Microsoft.Practices.Unity;

    using Prism.Logging;
    using Prism.Modularity;
    using Prism.Mvvm;
    using Prism.Regions;
    using Prism.Unity;

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

        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();

            var serviceLocator = new UnityServiceLocator(this.Container);
            this.Container.RegisterInstance(serviceLocator);
        }

        protected override void ConfigureContainer()
        {
            Container.RegisterType<IShell, Shell>(new ContainerControlledLifetimeManager());

            base.ConfigureContainer();

            this.Container.RegisterType<object, WelcomeView>(typeof(WelcomeView).ToString());
            this.Container.RegisterType<object, NavigationView>(typeof(NavigationView).ToString());
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            var shell = Container.Resolve<IShell>();
            return shell as DependencyObject;
        }

        protected override void InitializeShell()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => this.Container.Resolve(type));

            var regionManager = this.Container.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion(RegionNames.SubNavigationRegion, typeof(SubNavigationWelcomeView));
            regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(WelcomeView).ToString());
            regionManager.RequestNavigate(RegionNames.SubNavigationRegion, typeof(SubNavigationWelcomeView).ToString());
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }
    }
}