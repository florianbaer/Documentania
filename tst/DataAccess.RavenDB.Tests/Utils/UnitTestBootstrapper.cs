using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RavenDB.Tests.Utils
{
    using System.Windows;

    using Documentania.Common;

    using Prism.Logging;
    using Prism.Unity;

    public class UnitTestBootstrapper : UnityBootstrapper
    {
        public UnitTestBootstrapper()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new DocumentaniaLogger();
        }
        
    }
}