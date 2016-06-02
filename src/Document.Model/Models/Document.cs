// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Document.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Document.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using Documentania.Infrastructure.Interfaces;

    public class Document : IStorable
    {
        public virtual DateTime DateReceived { get; set; } = DateTime.Now;

        public virtual DateTime Imported { get; set; }

        public virtual string Name { get; set; }

        [XmlIgnore]
        public virtual string Path { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public virtual string Id { get; set; } = string.Empty;
    }
}