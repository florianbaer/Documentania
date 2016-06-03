namespace Document.Model.Filter
{
    using System.Collections.Generic;
    using Document = Models.Document;

    public abstract class Filter
    {
        public abstract ICollection<Document> Execute(ICollection<Document> documents);
    }
}
