// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentTagsEntity.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentTagsEntity.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace DataAccess.RavenDB.Entities
{
    using System.Linq;

    using Modules.Document.Models;

    using Raven.Client.Indexes;
    using Raven.Database.Linq.PrivateExtensions;

    public class DocumentTagsEntity : AbstractIndexCreationTask<Document>
    {
        public DocumentTagsEntity()
        {
            this.Map = documents => from e in documents select new { DocumentId = e.Id, TagId = e.Tags.SelectMany(x => x.Id) };
        }
    }
}