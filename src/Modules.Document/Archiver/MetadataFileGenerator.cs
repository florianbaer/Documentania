using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.Archiver
{
    using System.IO;
    using System.Reflection;
    using System.Xml.Linq;

    public class MetadataFileGenerator
    {
        private readonly string path;

        public MetadataFileGenerator(string path)
        {
            this.path = path;
        }

        public void GenerateFile()
        {
            XDocument doc = new XDocument(new XElement("Documentania",
                new XElement("Version", new XAttribute("Version", Assembly.GetExecutingAssembly().GetName().Version))));

            doc.Save(this.path);
        }
    }
}
