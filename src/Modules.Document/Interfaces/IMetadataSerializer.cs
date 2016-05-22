// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IMetadataSerializer.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IMetadataSerializer.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Interfaces
{
    using Models;

    public interface IMetadataSerializer
    {
        void Serialize(Document document);

        Document Deserialize(string path);
    }
}