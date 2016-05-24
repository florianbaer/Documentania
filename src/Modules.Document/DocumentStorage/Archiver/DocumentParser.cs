namespace Modules.Document.DocumentStorage.Archiver
{
    using System.IO;

    using Documentania.Infrastructure.File;

    using ICSharpCode.SharpZipLib.Zip;

    using Modules.Document.Models;

    public class DocumentParser
    {
        private const string FILE_NAME = "DocumentInfo.xml";

        public Document ParseDocument(string path)
        {
            using (TempDirectory directory = new TempDirectory())
            {
                FastZip zip = new FastZip();
                zip.ExtractZip(path, directory.ToString(), null);

                Document document = new FileInfoSerializer().Deserialize(Path.Combine(directory.FilePath, FILE_NAME));

                return document;
            }
        }
    }
}
