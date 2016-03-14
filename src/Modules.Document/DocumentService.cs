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

    using Documentania.Contracts;

    using Microsoft.Practices.ServiceLocation;

    public class DocumentService : IDocumentService
    {
        private readonly IRepository repository;

        public DocumentService(IRepository repo)
        {
            this.repository = repo;
        }

        public void AddDocument(Document document)
        {
            this.repository.Add(document);
        }

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
            return this.repository.GetAll<Document>();
        }

        public ICollection<Document> SearchByTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Document> SearchByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }
    }
}