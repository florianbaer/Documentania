// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IStorable.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IStorable.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for a storable object.
    /// </summary>
    public interface IStorable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        string Id { get; set; }

        string Name { get; set; }
    }
}