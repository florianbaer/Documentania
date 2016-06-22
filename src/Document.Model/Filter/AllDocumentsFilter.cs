namespace Document.Model.Filter
{
    using System.Collections.Generic;
    using System.Linq;
    using Document = Models.Document;

    public class AllDocumentsFilter : Filter
    {
        public override IQueryable<Document> Execute(IQueryable<Document> documents)
        {
            return documents;
        }
    }
}
