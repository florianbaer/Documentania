// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentaniaDocumentStore.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentaniaDocumentStore.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using log4net;
using Microsoft.Practices.ServiceLocation;

namespace DataAccess.RavenDB
{
    using System;
    using Documentania.Common;
    using Prism.Logging;
    using Raven.Client.Document;

    public class DocumentaniaDocumentStore : DocumentStore
    {
        private static ILog Log = LogManager.GetLogger(typeof (DocumentaniaDocumentStore));

        public DocumentaniaDocumentStore(string url, string defaultDatabase)
        {
            Log.Debug($"Create instance of logger for url {url} with databasename {defaultDatabase}");
                        Url = url;
            DefaultDatabase = defaultDatabase;
        }
    }
}