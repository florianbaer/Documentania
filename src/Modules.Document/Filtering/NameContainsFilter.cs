// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NameContainsFilter.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NameContainsFilter.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Filtering
{
    using System.Collections.Generic;
    using System.Linq;

    using Modules.Document.Models;

    public class NameContainsFilter : DocumentFilterBase
    {
        private string value;

        public NameContainsFilter(string value)
        {
            this.value = value;
        }

        public override IEnumerable<Document> Filter(ICollection<Document> documents)
        {
            IEnumerable<Document> filteredDocuments = from document in documents
                                                      where document.Name.Contains(this.value)
                                                      select document;

            return filteredDocuments;
        }
    }
}