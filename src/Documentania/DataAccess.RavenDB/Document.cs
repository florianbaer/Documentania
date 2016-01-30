// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Document.cs" company="BaerDev">
// Copyright (c) BaerDev. All rights reserved.
// </copyright>
// <summary>
// The file 'Document.cs'.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RavenDB
{
    public class Document
    {
        public virtual string Id { get; set; }

        public virtual string Path { get; set; }

        public virtual DateTime Imported { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}