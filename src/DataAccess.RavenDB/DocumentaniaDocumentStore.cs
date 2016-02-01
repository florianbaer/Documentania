// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentaniaDocumentStore.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentaniaDocumentStore.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB
{
    using System;

    using Documentania.Common.Bootstrapper;

    using Microsoft.Practices.ServiceLocation;

    using Prism.Logging;

    using Raven.Client.Document;

    public class DocumentaniaDocumentStore : DocumentStore
    {
        DocumentaniaLogger logger;
        public DocumentaniaDocumentStore(string url, string defaultDatabase)
        {
            this.logger = (DocumentaniaLogger)ServiceLocator.Current.GetInstance(typeof(ILoggerFacade));

            this.logger.Log($"Create instance of logger for url {url} with databasename {defaultDatabase}", Category.Info, Priority.Low);

            this.Url = url;
            this.DefaultDatabase = defaultDatabase;
        }
    }
}