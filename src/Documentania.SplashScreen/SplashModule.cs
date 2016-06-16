// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SplashModule.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'SplashModule.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.SplashScreen
{
    using System;
    using System.Threading;
    using System.Windows.Threading;

    using Documentania.Infrastructure.Events.SplashScreen;

    using Infrastructure.Interfaces;
    using Microsoft.Practices.Unity;
    using Prism.Events;
    using Prism.Modularity;
    using ViewModels;
    using Views;

    [Module(ModuleName = "SplashModule")]
    public class SplashModule : IModule
    {
        #region ctors

        public SplashModule(IUnityContainer container, IEventAggregator eventAggregator, IShell shell)
        {
            Container = container;
            EventAggregator = eventAggregator;
            Shell = shell;
        }

        #endregion

        #region Private Properties

        private IUnityContainer Container { get; set; }

        private IEventAggregator EventAggregator { get; set; }

        private IShell Shell { get; set; }

        private AutoResetEvent WaitForCreation { get; set; }

        #endregion

        public void Initialize()
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(
                (Action) (() =>
                {
                    Shell.Show();
                    EventAggregator.GetEvent<CloseSplashEvent>().Publish(new CloseSplashEvent());
                }));

            WaitForCreation = new AutoResetEvent(false);

            ThreadStart showSplash =
                () =>
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(
                        (Action) (() =>
                        {
                            Container.RegisterType<SplashViewModel, SplashViewModel>();
                            Container.RegisterType<SplashView, SplashView>();

                            var splash = Container.Resolve<SplashView>();
                            EventAggregator.GetEvent<CloseSplashEvent>().Subscribe(
                                e => splash.Dispatcher.BeginInvoke((Action) splash.Close),
                                ThreadOption.PublisherThread, true);

                            splash.Show();

                            WaitForCreation.Set();
                        }));

                    Dispatcher.Run();
                };

            var thread = new Thread(showSplash) {Name = "Splash Thread", IsBackground = true};
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            WaitForCreation.WaitOne();
        }
    }
}