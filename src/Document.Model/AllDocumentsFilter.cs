namespace Document.Model
{
    using System.Collections.Generic;
    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public class AllDocumentsFilter : Filter
    {
        public override ICollection<Document> Execute(ICollection<Document> documents)
        {
            return documents;
        }
    }
}
