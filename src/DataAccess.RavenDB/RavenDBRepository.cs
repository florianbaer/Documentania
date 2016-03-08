// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="RavenDBRepository.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'RavenDBRepository.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using DataAccess.RavenDB.Extension;

    using Documentania.Interfaces;
    using log4net;
    using Raven.Abstractions.Extensions;
    using Raven.Client;

    public class RavenDBRepository : IRepository
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RavenDBRepository));

        private readonly IDocumentSession session;

        private readonly IDocumentStore store;

        public RavenDBRepository(IDocumentStore store)
        {
            this.store = store;
            store.Initialize();
            this.session = store.OpenSession();
        }

        public void Dispose()
        {
            this.session.Dispose();
            this.store.Dispose();
            Log.Debug("Disposed Ravendb repository.");
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new()
        {
            var items = All<T>().Where(expression);
            foreach (T item in items)
            {
                Delete(item);
            }
        }

        public void Delete<T>(T item) where T : class, IStorable, new()
        {
            this.session.Delete(item);
            Log.Debug($"Deleted {typeof(T)} : {item}");
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new()
        {
            return this.All<T>().Where(expression).SingleOrDefault();
        }

        public IQueryable<T> All<T>() where T : class, IStorable, new()
        {
            return this.session.Load<T>().AsQueryable();
        }

        public IQueryable<T> All<T>(int page, int pageSize) where T : class, IStorable, new()
        {
            return this.All<T>().Page(page, pageSize);
        }

        public void Add<T>(T item) where T : class, IStorable
        {
            this.session.Store(item);
            Log.Debug($"Added {typeof(T)} : {item}");
        }

        public void Add<T>(IEnumerable<T> items) where T : class, IStorable
        {
            items.ForEach(x => this.Add(x));
        }

        public IList<T> GetAll<T>()
        {
            return this.session.Load<T>();
        }
    }
}