// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IStorableService.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IStorableService.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Modules.Document
{
    using System;
    using System.Collections.Generic;

    using Documentania.Contracts;

    public interface IStorableService : IDisposable
    {
        void AddDocument(IStorable document);

        IStorable GetDocumentById(string id);

        IStorable GetDocumentByName(string name);

        ICollection<IStorable> GetAll();

        ICollection<IStorable> SearchByTag(IStorable tag);

        ICollection<IStorable> SearchByName(string name);
    }
}