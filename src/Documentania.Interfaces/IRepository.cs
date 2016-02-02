// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IRepository.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IRepository.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository : IDisposable
    {
        void Delete<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new();
        void Delete<T>(T item) where T : class, IStorable, new();
        void DeleteAll<T>() where T : class, IStorable, new();
        T Single<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new();
        System.Linq.IQueryable<T> All<T>() where T : class, IStorable, new();
        System.Linq.IQueryable<T> All<T>(int page, int pageSize) where T : class, IStorable, new();
        void Add<T>(T item) where T : class, IStorable, new();
        void Add<T>(IEnumerable<T> items) where T : class, IStorable, new();
    }
}