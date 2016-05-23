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
    using System.Linq;

    using Documentania.Infrastructure.Interfaces;
    using Interfaces;
    using Models;

    public class DocumentService : IDocumentService
    {
        private readonly IRepository repository;

        private IDocumentStorage storage;

        public DocumentService(IRepository repo, IDocumentStorage storage)
        {
            this.storage = storage;
            this.repository = repo;
        }

        public void AddDocument(Document document)
        {
            this.repository.Add(document);
            this.storage.SerializeDocument(document);
        }

        public void DeleteDocument(Document document)
        {
            this.repository.Delete(document);
        }

        public Document GetDocumentById(string id)
        {
            return this.repository.Single<Document>(document => document.Id == id);
        }

        public Document GetDocumentByName(string name)
        {
            return this.repository.Single<Document>(document => document.Name == name);
        }

        public ICollection<Document> GetAll()
        {
            return this.repository.GetAll<Document>();
        }

        public ICollection<Document> SearchByTag(string tag)
        {
            return this.repository.GetAll<Document>().Where(document => document.Tags.Contains(tag)).ToList();
        }

        public ICollection<Document> SearchByName(string name)
        {
            return this.repository.GetAll<Document>().Where(x => x.Name == name).ToList();
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }
    }
}