using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.Archiver
{
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    using ICSharpCode.SharpZipLib.Zip;

    using Modules.Document.Models;

    public class DocumentArchiver
    {
        public static void Save(Document document)
        {
            string commonAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Documentania");
            if (!Directory.Exists(commonAppData))
            {
                Directory.CreateDirectory(commonAppData);
            }

            var infoFile = Path.Combine(commonAppData, document.Name);

            XmlSerializer writer = new XmlSerializer(typeof(Document));

            System.IO.FileStream file = System.IO.File.Create(infoFile);

            writer.Serialize(file, document);
            file.Close();

            using (ZipFile zip = ZipFile.Create(Path.Combine(commonAppData, document.Id.Split('/')[1] + ".document")))
            {
                zip.BeginUpdate();
                zip.Add(document.Path);
                zip.Add(infoFile);
                zip.CommitUpdate();
            }

            File.Delete(infoFile);
        }
    }
}
