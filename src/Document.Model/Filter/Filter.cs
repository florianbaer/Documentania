namespace Document.Model.Filter
{
    using System.Collections.Generic;
    using System.Linq;
    using Document = Models.Document;

    public abstract class Filter
    {
        public abstract IQueryable<Document> Execute(IQueryable<Document> documents);
    }
}
