﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Tag.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Tag.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB
{
    using System.Collections.Generic;

    using Documentania.Interfaces;
    public class Tag : IStorable
    {
        public virtual string Id { get; set; }
        public virtual string Value { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();

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