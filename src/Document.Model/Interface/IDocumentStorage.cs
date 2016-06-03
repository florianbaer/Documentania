namespace Document.Model.Interface
{
    using Document = Models.Document;

    public interface IDocumentStorage
    {
        void SaveDocument(Document document);

        Document LoadDocument(string path);
    }
}