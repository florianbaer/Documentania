// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Decorator.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Decorator.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Filtering
{
    using System.Collections.Generic;

    using Modules.Document.Models;
    using Modules.Document.ViewModels;

    public abstract class Decorator : Filter
    {
        private readonly Filter filter;

        public Decorator(Filter filter)
        {
            this.filter = filter;
        }

        public override ICollection<DocumentViewModel> Execute(ICollection<DocumentViewModel> documents)
        {
            return this.filter.Execute(documents);
        }
    }
}