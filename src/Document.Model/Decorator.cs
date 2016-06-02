// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Decorator.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Decorator.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model
{
    using System.Collections.Generic;
    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public abstract class Decorator : Filter
    {
        private readonly Filter filter;

        public Decorator(Filter filter)
        {
            this.filter = filter;
        }

        public override ICollection<Document> Execute(ICollection<Document> documents)
        {
            return this.filter.Execute(documents);
        }
    }
}