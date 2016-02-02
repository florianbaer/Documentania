// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentaniaLogger.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentaniaLogger.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using Documentania.Interfaces;
using log4net;

namespace Documentania.Common
{
    using Prism.Logging;

    public class DocumentaniaLogger : IDocumentaniaLogger
    {
        private readonly ILog logger;

        public DocumentaniaLogger()
        {
            logger = LogManager.GetLogger(GetType());
        }

        /// <summary>
        ///     Writes a log message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="category">The message category.</param>
        /// <param name="priority">Not used by Log4Net; pass Priority.None.</param>
        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    logger.Debug(message);
                    break;
                case Category.Warn:
                    logger.Warn(message);
                    break;
                case Category.Exception:
                    logger.Error(message);
                    break;
                case Category.Info:
                    logger.Info(message);
                    break;
            }
        }
    }
}