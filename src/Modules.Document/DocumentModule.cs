// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentModule.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentModule.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

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
        private readonly IDocumentaniaLogger logger =
            (IDocumentaniaLogger) ServiceLocator.Current.GetInstance(typeof (ILoggerFacade));

        public void Initialize()
        {
            logger.Log("Initialize DocumentModule", Category.Info, Priority.None);
        }
    }
}