namespace Document.Model.DocumentStorage.Archiver
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Interface;
    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public class DocumentArchiveService : IDocumentStorage
    {
        public void SaveDocument(Document document)
        {
            string commonAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Documentania");
            if (!Directory.Exists(commonAppData))
            {
                Directory.CreateDirectory(commonAppData);
            }

            var infoFilePath = Path.Combine(commonAppData, "DocumentInfo" + ".xml");
            string metaData = Path.Combine(commonAppData, "Metadata" + ".xml");

            new XmlFileInfoSerializeService().Serialize(document, infoFilePath);
            
            new MetadataFileGenerator(metaData).GenerateFile();

            var documents = new List<string>()
            {
                metaData,
                infoFilePath,
                document.Path
            };

            new DocumentArchiveZipper(commonAppData).CreateArchive(document.Id, documents);

            File.Delete(infoFilePath);
            File.Delete(metaData);
        }

        public Document LoadDocument(string path)
        {
            throw new NotImplementedException();
        }
    }
}
