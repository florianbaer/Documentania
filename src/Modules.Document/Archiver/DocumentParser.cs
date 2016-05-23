using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.Archiver
{
    using System.IO;

    using Documentania.Infrastructure.File;

    using ICSharpCode.SharpZipLib.Zip;

    using Modules.Document.Models;

    public class DocumentParser
    {
        public Document ParseDocument(string path)
        {
            using (TempDirectory directory = new TempDirectory())
            {
                FastZip zip = new FastZip();
                zip.ExtractZip(path, directory.ToString(), null);

                Document document = new FileInfoSerializer().Deserialize(Path.Combine(directory.FilePath, "DocumentInfo.xml"));

                return document;
            }
        }
    }
}
