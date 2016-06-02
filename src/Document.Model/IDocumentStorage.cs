namespace Document.Model
{
    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public interface IDocumentStorage
    {
        void SaveDocument(Document document);

        Document LoadDocument(string path);
    }
}