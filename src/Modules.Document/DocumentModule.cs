// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentModule.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentModule.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Modules.Document
{
    using Documentania.Interfaces;

    using log4net;
    using Microsoft.Practices.Unity;

    using Modules.Document.Navigation;
    using Modules.Document.Views;

    using Prism.Modularity;

    [Module(ModuleName = "DocumentModule")]
    public class DocumentModule : IModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentModule));

        private readonly IUnityContainer container;

        public DocumentModule(IUnityContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            Log.Info("Initialize DocumentModule");

            this.container.RegisterType(typeof(IStorable), typeof(Document), typeof(Document).Name, new ContainerControlledLifetimeManager());
            Log.Debug("Document is registered as type.");
            this.container.RegisterType(typeof(IStorable), typeof(Tag), typeof(Tag).Name, new ContainerControlledLifetimeManager());
            Log.Debug("Tag is registered as type.");

            // Views
            this.container.RegisterType<object, AllDocumentsView>(typeof(AllDocumentsView).ToString());

            // Navigation
            this.container.RegisterType<INavigationItem, AllDocumentsNavigation>();
        }
    }
}