// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="TagNameContainsFilter.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'TagNameContainsFilter.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model.Filter
{
    using System.Collections.Generic;
    using System.Linq;

    using Document = Document.Model.Models.Document;

    public class TagNameContainsFilter : Decorator
    {
        private string tagName;

        public string TagName
        {
            get { return this.tagName; }
            set { this.tagName = value; }
        }
        
        public TagNameContainsFilter(Model.Filter.Filter filter, string tagName) : base(filter)
        {
            this.tagName = tagName;
        }

        public override ICollection<Document> Execute(ICollection<Document> documents)
        {
            var filteredDocuments = from selection in documents
                where selection.Tags.Any(x => x.Value.Contains(this.tagName))
                select selection;
            return base.Execute(filteredDocuments.ToList());
        }
    }
}