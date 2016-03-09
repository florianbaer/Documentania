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

    using Documentania.Common;
    using Documentania.Infrastructure.Views;

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

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            var serviceLocator = new UnityServiceLocator(this.Container);
            this.Container.RegisterInstance(serviceLocator);
        }
        
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            Log.Debug("Create Shell");
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            var shell = (Shell)this.Shell;
            Application.Current.MainWindow = shell;

            ViewModelLocationProvider.SetDefaultViewModelFactory(type => this.Container.Resolve(type));

            var regionManager = this.Container.Resolve<IRegionManager>();

            this.Container.RegisterType<object, WelcomeView>(typeof(WelcomeView).ToString());
            this.Container.RegisterType<object, NavigationView>(typeof(NavigationView).ToString());
            
            regionManager.RequestNavigate(RegionNames.NavigationRegion, typeof(NavigationView).ToString());
            regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(WelcomeView).ToString());

            shell.Show();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }
    }
}