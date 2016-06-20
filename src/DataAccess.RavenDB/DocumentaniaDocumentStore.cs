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
    using System.Runtime.CompilerServices;

    using log4net;

    using Raven.Client.Embedded;

    public class DocumentaniaDocumentStore : EmbeddableDocumentStore
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentaniaDocumentStore));

        public DocumentaniaDocumentStore() : this(@"C:\Documentania\Data\")
        {
            this.Initialize();
            Log.Debug($"Create instance of logger for data directory {this.DataDirectory}");
        }

        public DocumentaniaDocumentStore(string dataDirectory)
        {
            if (string.IsNullOrEmpty(dataDirectory))
            {
                this.DataDirectory = @"C:\Documentania\Data\";
            }
            else { 
            this.DataDirectory = dataDirectory;
            }
        }
    }
}