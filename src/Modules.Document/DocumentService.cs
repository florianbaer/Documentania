// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentService.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentService.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document
{
    using System.Collections.Generic;

    public class DocumentService : IDocumentService
    {
        public Document GetDocumentById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Document GetDocumentByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Document> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Document> SearchByTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Document> SearchByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}