namespace Document.Model.Filter
{
    using System.Collections.Generic;
    using Document = Models.Document;

    public class AllDocumentsFilter : Filter
    {
        public override ICollection<Document> Execute(ICollection<Document> documents)
        {
            return documents;
        }
    }
}
