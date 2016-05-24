namespace Modules.Document.Interfaces
{
    using Modules.Document.Models;

    public interface IDocumentStorage
    {
        void SaveDocument(Document document);

        Document LoadDocument(string path);
    }
}