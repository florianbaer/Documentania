using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for App.xaml
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
            this.bootstrapper.StartUp();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            this.bootstrapper.ShutDown();
        }
    }
}
