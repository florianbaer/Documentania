// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IDocumentService.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IDocumentService.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.Model.Interface
{
    using System;
    using System.Collections.Generic;
    using Document = Models.Document;
    using Tag = Models.Tag;

    public interface IDocumentService : IDisposable
    {
        void AddDocument(Document document);

        void DeleteDocument(Document document);

        Document GetDocumentById(string id);

        Document GetDocumentByName(string name);

        IList<Document> GetAll();

        ICollection<Document> SearchByTag(Tag tag);

        ICollection<Document> SearchByName(string name);
    }
}