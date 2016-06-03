// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Decorator.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Decorator.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model.Filter
{
    using System.Collections.Generic;
    using Document = Models.Document;

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