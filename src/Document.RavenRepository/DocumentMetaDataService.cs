// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="documentMetaDataService.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'documentMetaDataService.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.RavenRepository
{
    using System.Collections.Generic;
    using System.Linq;
    using Documentania.Infrastructure.Interfaces;
    using Model;
    using Model.Interface;
    using Model.Models;

    public class DocumentMetaDataService : IDocumentMetaDataService
    {
        private readonly IRepository repository;

        private IDocumentStorage storage;

        public DocumentMetaDataService(IRepository repo, IDocumentStorage storage)
        {
            this.storage = storage;
            this.repository = repo;
        }

        public void AddDocument(Document document)
        {
            this.repository.Add(document);
            this.storage.SaveDocument(document);
        }

        public void DeleteDocument(string id)
        {
            this.repository.Delete<Document>(document => document.Id == id);
        }
        
        public Document GetDocumentById(string id)
        {
            return this.repository.Single<Document>(document => document.Id == id);
        }

        public Document GetDocumentByName(string name)
        {
            return this.repository.Single<Document>(document => document.Name == name);
        }

        public IList<Document> GetAll()
        {
            return this.repository.All<Document>().ToList();
        }

        public ICollection<Document> SearchByTag(Tag tag)
        {
            return this.repository.All<Document>().Where(document => document.Tags.Contains(tag)).ToList();
        }

        public ICollection<Document> SearchByName(string name)
        {
            return this.repository.All<Document>().Where(x => x.Name == name).ToList();
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }
    }
}