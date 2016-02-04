// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="UnitTestBootstrapper.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'UnitTestBootstrapper.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB.Tests.Utils
{
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