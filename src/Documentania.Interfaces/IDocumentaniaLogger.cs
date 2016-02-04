// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IDocumentaniaLogger.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IDocumentaniaLogger.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Interfaces
{
    using System;
    using Prism.Logging;

    /// <summary>
    /// The interface for the documentania logger.
    /// </summary>
    /// <seealso cref="Prism.Logging.ILoggerFacade" />
    public interface IDocumentaniaLogger : ILoggerFacade
    {
        /// <summary>
        /// Creates a debug log.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(object message);

        /// <summary>
        /// Creates a debug log with exception text.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Debug(object message, Exception exception);

        /// <summary>
        /// Creates a info log.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(object message);

        /// <summary>
        /// Creates a info log with a exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Info(object message, Exception exception);

        /// <summary>
        /// Creates a warn log.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warn(object message);

        /// <summary>
        /// Creates a warn log with a exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Warn(object message, Exception exception);

        /// <summary>
        /// Creates a exception log.
        /// </summary>
        /// <param name="message">The message.</param>
        void Exception(object message);

        /// <summary>
        /// Creates a exceptional log with a nested exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Exception(object message, Exception exception);
    }
}