// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NameContainsFilterDecorator.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NameContainsFilterDecorator.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Filtering
{
    using System.Collections.Generic;
    using System.Linq;

    using Modules.Document.Models;
    using Modules.Document.ViewModels;

    public class NameContainsFilterDecorator : Decorator
    {
        private readonly string filterText;

        public NameContainsFilterDecorator(Filter filter, string filterText)
            : base(filter)
        {
            this.filterText = filterText;
        }

        public override ICollection<DocumentViewModel> Execute(ICollection<DocumentViewModel> documents)
        {
            IEnumerable<DocumentViewModel> filteredDocuments = from selection in documents
                                                      where selection.Name.Contains(this.filterText)
                                                      select selection;

            return base.Execute(filteredDocuments.ToList());
        }
    }
}