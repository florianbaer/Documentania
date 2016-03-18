// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IRepository.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IRepository.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The Interface for the IRepository.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Deletes the specified expression.
        /// </summary>
        /// <typeparam name="T">The given type.</typeparam>
        /// <param name="expression">The expression.</param>
        void Delete<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new();

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="item">The item.</param>
        void Delete<T>(T item) where T : class, IStorable, new();

        /// <summary>
        /// Gets the specified single expression.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>One of the given type.</returns>
        T Single<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new();

        /// <summary>
        /// Gets all from the given type.
        /// </summary>
        /// <typeparam name="T">The passed type.</typeparam>
        /// <returns>Returns all of the given type.</returns>
        System.Linq.IQueryable<T> All<T>() where T : class, IStorable, new();

        /// <summary>
        /// Gets all the specified pages.
        /// </summary>
        /// <typeparam name="T">The given type.</typeparam>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Returns all of the given type.</returns>
        System.Linq.IQueryable<T> All<T>(int page, int pageSize) where T : class, IStorable, new();

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <typeparam name="T">The given type.</typeparam>
        /// <param name="item">The item.</param>
        void Add<T>(T item) where T : class, IStorable;

        /// <summary>
        /// Adds the specified items.
        /// </summary>
        /// <typeparam name="T">The given type.</typeparam>
        /// <param name="items">The items.</param>
        void Add<T>(IEnumerable<T> items) where T : class, IStorable;

        /// <summary>
        /// Gets all from a given type.
        /// </summary>
        /// <typeparam name="T">The given type.</typeparam>
        /// <returns>All items of a given type.</returns>
        IList<T> GetAll<T>();
    }
}