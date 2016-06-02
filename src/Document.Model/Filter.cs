namespace Document.Model
{
    using System.Collections.Generic;

    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public abstract class Filter
    {
        public abstract ICollection<Document> Execute(ICollection<Document> documents);
    }
}
