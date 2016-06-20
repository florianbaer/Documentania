namespace Document.Model.Interface
{
    public interface IFileInfoSerializeService
    {
        Models.Document Deserialize(string infoFile);
        void Serialize(Models.Document document, string infoFile);
    }
}