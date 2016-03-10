// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Document.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Document.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Modules.Document
{
    using System;
    using System.Collections.Generic;
    using Documentania.Contracts;

    public class Document : IStorable
    {
        public virtual DateTime DateReceived { get; set; }

        public virtual DateTime Imported { get; set; }

        public virtual string Path { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public virtual string Id { get; set; }
    }
}