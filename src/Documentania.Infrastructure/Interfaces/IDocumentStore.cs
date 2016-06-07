// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IDocumentStore.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IDocumentStore.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.Infrastructure.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IDocumentStore<T>
    {
        void Save(T document);

        string Load(T document);
    }
}