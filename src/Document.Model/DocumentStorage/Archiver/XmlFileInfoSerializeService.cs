// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="XmlFileInfoSerializeService.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'XmlFileInfoSerializeService.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model.DocumentStorage.Archiver
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using Document.Model.Interface;

    using Raven.Abstractions.Extensions;

    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public class XmlFileInfoSerializeService : IFileInfoSerializeService
    {
        private XDocument xDocument;

        public void Serialize(Document document, string infoFile)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Document), new Type[] { typeof(Tag) });

            System.IO.FileStream file = System.IO.File.Create(infoFile);

            writer.Serialize(file, document);
            file.Close();
        }

        public Document Deserialize(string infoFile)
        {
            if (!File.Exists(infoFile))
            {
                throw new FileNotFoundException($"File '{Path.GetFileName(infoFile)}' does not exist at '{Path.GetDirectoryName(infoFile)}'");
            }

            Document document = new Document();
            this.xDocument = XDocument.Load(infoFile);
            document.Id = this.GetDocumentId();
            document.Name = this.GetDocumentName();
            document.Imported = this.GetImportedDate();
            document.DateReceived = this.GetReceivedDate();
            document.Tags = this.GetTags();
            return document;
        }

        private string GetDocumentId()
        {
            return this.xDocument.Root.Elements().Single(x => x.Name == "Id").Value;
        }

        private List<Tag> GetTags()
        {
            var list = new List<Tag>();
            this.xDocument.Root.Elements().Single(x => x.Name == "Tags").Elements().ForEach(x => list.Add(new Tag() {Value = x.Value}));
            return list;
        }

        private DateTime GetReceivedDate()
        {
            return DateTime.Parse(this.xDocument.Root.Elements().Single(x => x.Name == "DateReceived").Value);
        }

        private DateTime GetImportedDate()
        {
            return DateTime.Parse(this.xDocument.Root.Elements().Single(x => x.Name == "Imported").Value);
        }

        private string GetDocumentName()
        {
            return this.xDocument.Root.Elements().Single(x => x.Name == "Name").Value;
        }
    }
}