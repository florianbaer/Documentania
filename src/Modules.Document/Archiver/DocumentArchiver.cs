using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.Archiver
{
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using ICSharpCode.SharpZipLib.Zip;

    using Modules.Document.Interfaces;
    using Modules.Document.Models;

    public class DocumentArchiver : IDocumentStorage
    {
        public void Save(Document document)
        {
            string commonAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Documentania");
            if (!Directory.Exists(commonAppData))
            {
                Directory.CreateDirectory(commonAppData);
            }

            var infoFilePath = Path.Combine(commonAppData, document.Name + ".xml");
            string metaData = Path.Combine(commonAppData, "Metadata" + ".xml");

            new FileInfoSerializer().CreateInfoFile(document, infoFilePath);
            
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
    }
}
