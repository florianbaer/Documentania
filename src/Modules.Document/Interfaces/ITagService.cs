// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ITagService.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'ITagService.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Interfaces
{
    using System;

    using Modules.Document.Models;

    public interface ITagService : IDisposable
    {
        void Add(Tag tag);

        void Update(Tag tag);

        void Delete(Tag tag);
    }
}