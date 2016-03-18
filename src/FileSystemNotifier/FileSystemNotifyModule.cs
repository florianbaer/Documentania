// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FileSystemNotifyModule.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'FileSystemNotifyModule.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace FileSystemNotifier
{
    using log4net;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    using Prism.Modularity;

    [Module(ModuleName = "FileSystemNotify")]
    public class FileSystemNotifyModule : IModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(FileSystemNotifyModule));

        private IUnityContainer container = ServiceLocator.Current.GetInstance<IUnityContainer>();

        public void Initialize()
        {
            Log.Debug("FileSytemNotfier Module initialized");
        }
    }
}