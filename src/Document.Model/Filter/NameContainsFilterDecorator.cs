// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NameContainsFilterDecorator.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NameContainsFilterDecorator.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model.Filter
{
    using System.Collections.Generic;
    using System.Linq;
    using Document = Models.Document;

    public class NameContainsFilterDecorator : Decorator
    {
        private readonly string filterText;

        public NameContainsFilterDecorator(Filter filter, string filterText)
            : base(filter)
        {
            this.filterText = filterText;
        }

        public override IQueryable<Document> Execute(IQueryable<Document> documents)
        {
            IQueryable<Document> filteredDocuments = from selection in documents
                                                      where selection.Name.Contains(this.filterText)
                                                      select selection;

            return base.Execute(filteredDocuments);
        }
    }
}