// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentaniaLogger.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentaniaLogger.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Infrastructure.Logger
{
    using System;

    using Documentania.Contracts;

    using log4net;

    using Prism.Logging;

    /// <summary>
    /// The documentania logger.
    /// </summary>
    /// <seealso cref="ILoggerFacade" />
    public class DocumentaniaLogger : ILoggerFacade
    {
        private readonly ILog Logger;

        public DocumentaniaLogger()
        {
            this.Logger = LogManager.GetLogger(this.GetType());
        }

        /// <summary>
        ///     Writes a log message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="category">The message category.</param>
        /// <param name="priority">Not used by Log4Net; pass Priority.None.</param>
        [Obsolete("Use 'private static readonly ILog Log = LogManager.GetLogger(TYPE));'")]
        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    this.Logger.Debug(message);
                    break;
                case Category.Warn:
                    this.Logger.Warn(message);
                    break;
                case Category.Exception:
                    if (priority == Priority.High)
                    {
                        this.Logger.Fatal(message);
                    }
                    this.Logger.Error(message);
                    break;
                case Category.Info:
                    this.Logger.Info(message);
                    break;
            }
        }
    }
}