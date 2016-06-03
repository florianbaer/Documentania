// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="TagService.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'TagService.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.RavenRepository
{
    using Documentania.Infrastructure.Interfaces;
    using Model;
    using Model.Interface;
    using Model.Models;

    public class TagService : ITagService
    {
        private IRepository repository;

        private IDocumentStorage storage;

        public TagService(IRepository repo, IDocumentStorage storage)
        {
            this.storage = storage;
            this.repository = repo;
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public void Add(Tag tag)
        {
            this.repository.Add(tag);
        }

        public void Update(Tag tag)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Tag tag)
        {
            throw new System.NotImplementedException();
        }
    }
}