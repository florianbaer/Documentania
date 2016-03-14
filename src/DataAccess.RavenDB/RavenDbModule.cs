// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="RavenDbModule.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'RavenDbModule.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB
{
    using Documentania.Contracts;

    using log4net;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;

    using Raven.Client;

    [Module(ModuleName = "RavenDbModule")]
    public class RavenDbModule : IModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RavenDbModule));

        private IUnityContainer container = ServiceLocator.Current.GetInstance<IUnityContainer>();

        public void Initialize()
        {
            Log.Debug("Initialize RaveDbModule");
            this.container.RegisterType<IDocumentStore, DocumentaniaDocumentStore>();
            this.container.RegisterType(typeof(IRepository), typeof(RavenDbRepository), new TransientLifetimeManager());
        }
    }
}