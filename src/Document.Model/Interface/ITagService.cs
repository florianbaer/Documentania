// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ITagService.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'ITagService.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model.Interface
{
    using System;
    using Tag = Models.Tag;

    public interface ITagService : IDisposable
    {
        void Add(Tag tag);

        void Update(Tag tag);

        void Delete(Tag tag);
    }
}