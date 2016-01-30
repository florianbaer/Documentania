// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentaniaDocumentStore.cs" company="BaerDev">
// Copyright (c) BaerDev. All rights reserved.
// </copyright>
// <summary>
// The file 'DocumentaniaDocumentStore.cs'.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RavenDB
{
    using Raven.Client.Document;

    public class DocumentaniaDocumentStore : DocumentStore
    {
        public DocumentaniaDocumentStore(string url, string defaultDatabase)
            : base()
        {
            Url = url;
            DefaultDatabase = defaultDatabase;
        }
    }
}