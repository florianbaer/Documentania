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
    using log4net;
    using Prism.Modularity;

    [Module(ModuleName = "DocumentModule")]
    public class DocumentModule : IModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentModule));

        public void Initialize()
        {
            Log.Info("Initialize DocumentModule");
        }
    }
}