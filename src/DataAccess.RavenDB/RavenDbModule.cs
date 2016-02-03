using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace DataAccess.RavenDB
{
    [Module(ModuleName = "RavenDbModule")]
    public class RavenDbModule : IModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (RavenDbModule));
        IUnityContainer container = ServiceLocator.Current.GetInstance<IUnityContainer>();
        public void Initialize()
        {
            Log.Debug("Initialize RaveDbModule");
            //// container.RegisterInstance(new RavenDBRepository(new DocumentaniaDocumentStore("http://localhost:1303", "Documentania")));
        }
    }
}
