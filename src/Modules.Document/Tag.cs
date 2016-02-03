// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Tag.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Tag.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Documentania.Interfaces;

namespace Modules.Document
{
    public class Tag : IStorable
    {
        public virtual string Value { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();
        public virtual string Id { get; set; }

        public void Store(bool withRelation)
        {
            if (withRelation)
            {
                // Todo: implement intelligent save 
                //// this.Documents.ForEach(x => repo.Add(x));
            }
        }
    }
}