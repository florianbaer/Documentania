namespace Modules.Document.Interfaces
{
    using Modules.Document.Models;

    public interface IDocumentStorage
    {
        void SerializeDocument(Document document);
    }
}