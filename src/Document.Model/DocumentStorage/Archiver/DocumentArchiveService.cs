namespace Document.Model.DocumentStorage.Archiver
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Interface;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity.Utility;

    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public class DocumentArchiveService : IDocumentStorage
    {
        private readonly IServiceLocator serviceLocator;

        public DocumentArchiveService(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void SaveDocument(Document document)
        {
            Guard.ArgumentNotNull(document, "document");

            string commonAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Documentania");
            if (!Directory.Exists(commonAppData))
            {
                Directory.CreateDirectory(commonAppData);
            }

            var infoFilePath = Path.Combine(commonAppData, "DocumentInfo" + ".xml");
            string metaData = Path.Combine(commonAppData, "Metadata" + ".xml");

            IFileInfoSerializeService fileSerializationService = this.serviceLocator.GetInstance<IFileInfoSerializeService>();
            Guard.ArgumentNotNull(fileSerializationService, "fileSerializationService");
            fileSerializationService.Serialize(document, infoFilePath);
            
            IMetadataFileGenerator metaDataFileGenerator = this.serviceLocator.GetInstance<IMetadataFileGenerator>();

            Guard.ArgumentNotNull(metaDataFileGenerator, "metaDataFileGenerator");
 
            metaDataFileGenerator.GenerateFile(metaData);

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
