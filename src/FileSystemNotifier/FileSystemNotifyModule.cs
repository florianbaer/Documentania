using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
