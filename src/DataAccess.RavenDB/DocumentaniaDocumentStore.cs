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
    using Raven.Client.Document;

    public class DocumentaniaDocumentStore : DocumentStore
    {
        public DocumentaniaDocumentStore(string url, string defaultDatabase)
        {
            this.Url = url;
            this.DefaultDatabase = defaultDatabase;
        }
    }
}