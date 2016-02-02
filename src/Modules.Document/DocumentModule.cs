using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentania.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Prism.Logging;
using Prism.Modularity;

namespace Modules.Document
{
    [Module(ModuleName = "DocumentModule")]
    public class DocumentModule : IModule
    {
        IDocumentaniaLogger logger = (IDocumentaniaLogger)ServiceLocator.Current.GetInstance(typeof(ILoggerFacade));
        public void Initialize()
        {
            this.logger.Log("Initialize DocumentModule", Category.Info, Priority.None);
        }
    }
}
