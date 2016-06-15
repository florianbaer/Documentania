namespace Document.RavenRepository
{
    using System.Linq;

    using Document.Model.Models;

    using Raven.Client.Indexes;

    public class Documents_ByTags : AbstractIndexCreationTask<Document>
    {
        public Documents_ByTags()
        {
            this.Map = documents => from document in documents
                                    select new
                                               {
                                                   document.Tags
                                               };
        }
    }
}