using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentania.Interfaces;

namespace UserInterface.Bootstrapper
{
    public class Bootstrapper : IBootstrapper
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Bootstrapper()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void StartUp()
        {
            Logger.Info("Starting up bootstrapper...");
        }

        public void ShutDown()
        {
            Logger.Info("Shutdown bootstrapper...");
        }
    }
}
