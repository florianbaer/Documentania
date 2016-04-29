// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Tag.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Tag.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Infrastructure.Models
{
    using Documentania.Infrastructure.Interfaces;

    public class Tag : IStorable
    {
        public virtual string Value { get; set; }

        public virtual string Id { get; set; }
    }
}