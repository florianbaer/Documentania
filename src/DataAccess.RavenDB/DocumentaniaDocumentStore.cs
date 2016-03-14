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
    using log4net;
    using Raven.Client.Document;

    public class DocumentaniaDocumentStore : DocumentStore
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentaniaDocumentStore));

        public DocumentaniaDocumentStore()
        {
            var url = "http://localhost:1303";
            var defaultDatabase = "Documentania";
            Log.Debug($"Create instance of logger for url {url} with databasename {defaultDatabase}");
            this.Url = url;
            this.DefaultDatabase = defaultDatabase;
        }
    }
}