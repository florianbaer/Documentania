// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IDocumentaniaLogger.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IDocumentaniaLogger.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Logging;

namespace Documentania.Interfaces
{
    using log4net;

    public interface IDocumentaniaLogger : ILoggerFacade
    {
        void Debug(object message);
        void Debug(object message, Exception exception);
        void Info(object message);
        void Info(object message, Exception exception);
        void Warn(object message);
        void Warn(object message, Exception exception);
        void Exception(object message);
        void Exception(object message, Exception exception);
    }
}