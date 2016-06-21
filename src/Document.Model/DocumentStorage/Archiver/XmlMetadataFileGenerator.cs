namespace Document.Model.DocumentStorage.Archiver
{
    using System.Reflection;
    using System.Xml.Linq;

    using Document.Model.Interface;

    public class XmlMetadataFileGenerator : IMetadataFileGenerator
    {
        public XmlMetadataFileGenerator()
        {
        }

        public void GenerateFile(string path)
        {
            XDocument doc = new XDocument(new XElement("Documentania",
                new XElement("Version", new XAttribute("Version", Assembly.GetExecutingAssembly().GetName().Version))));

            doc.Save(path);
        }
    }
}
