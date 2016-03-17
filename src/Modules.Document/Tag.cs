// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Tag.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Tag.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Modules.Document
{
    using System.Collections.Generic;
    using Documentania.Contracts;

    public class Tag : IStorable
    {
        public virtual string Value { get; set; }

        public virtual string Id { get; set; }
        
    }
}