// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentaniaDocumentStore.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentaniaDocumentStore.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using Microsoft.Practices.ServiceLocation;

namespace DataAccess.RavenDB
{
    using System;
    using Documentania.Common;
    using Prism.Logging;
    using Raven.Client.Document;

    public class DocumentaniaDocumentStore : DocumentStore
    {
        private readonly DocumentaniaLogger Log =
            (DocumentaniaLogger) ServiceLocator.Current.GetInstance(typeof (ILoggerFacade));

        public DocumentaniaDocumentStore(string url, string defaultDatabase)
        {
            this.Log.Debug($"Create instance of logger for url {url} with databasename {defaultDatabase}");

            Url = url;
            DefaultDatabase = defaultDatabase;
        }
    }
}