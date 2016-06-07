// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IDocumentExporter.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IDocumentExporter.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.Infrastructure.Interfaces
{
    using System.Collections.Generic;

    public interface IDocumentExporter<T>
    {
        void Export(IEnumerable<T> items, string exportedFilePath);

        IEnumerable<T> Import(string importFile);
    }
}