namespace Document.Model.DocumentStorage.Archiver
{
    using System.IO;

    using Document.Model.Interface;
    using Document.Model.Models;

    using Documentania.Infrastructure.File;

    using ICSharpCode.SharpZipLib.Zip;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity.Utility;

    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public class DocumentParser
    {
        private IServiceLocator serviceLocator;

        public DocumentParser(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        private const string FILE_NAME = "DocumentInfo.xml";

        public Document ParseDocument(string path, IZipProvider zipProvider)
        {
            Guard.ArgumentNotNullOrEmpty(path, "path");
            Guard.ArgumentNotNull(zipProvider, "zipProvider");

            using (TempDirectory directory = new TempDirectory())
            {
                zipProvider.Extract(path, directory.ToString(), null);

                IFileInfoSerializeService fileInfoSerializerService = this.serviceLocator.GetInstance<IFileInfoSerializeService>();

                Document document = fileInfoSerializerService.Deserialize(Path.Combine(directory.FilePath, FILE_NAME));

                return document;
            }
        }
    }
}
