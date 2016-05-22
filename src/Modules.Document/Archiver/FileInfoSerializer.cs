// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FileInfoSerializer.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'FileInfoSerializer.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Archiver
{
    using System.Xml.Serialization;
    using Models;

    public class FileInfoSerializer
    {
        public void CreateInfoFile(Document document, string infoFile)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Document));

            System.IO.FileStream file = System.IO.File.Create(infoFile);

            writer.Serialize(file, document);
            file.Close();
        } 
    }
}