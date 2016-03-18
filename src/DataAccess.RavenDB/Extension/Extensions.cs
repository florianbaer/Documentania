// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Extensions.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Extensions.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB.Extension
{
    using System.Linq;

    public static class Extensions
    {
        /// <summary>
        /// Pages a LINQ query to return just the subset of rows from the database. Use as follows:
        /// 
        /// var query = from s in _context.Table
        ///             orderby s.Id ascending
        ///             select s;
        ///
        /// return _myRepository.Find(query, page, pageSize).ToList();
        /// </summary>
        /// <typeparam name="TSource">Entity</typeparam>
        /// <param name="source">LINQ query</param>
        /// <param name="page">Page Index</param>
        /// <param name="pageSize">Number of Rows</param>
        /// <returns>IQueryable</returns>
        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}