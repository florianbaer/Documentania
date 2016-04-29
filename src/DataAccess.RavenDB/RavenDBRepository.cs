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

    using Documentania.Infrastructure.Interfaces;

    using log4net;

    using Raven.Abstractions.Extensions;
    using Raven.Client;

    public class RavenDbRepository : IRepository
    {
        private readonly ILog log = LogManager.GetLogger(typeof(RavenDbRepository));

        private readonly IDocumentSession session;

        private readonly IDocumentStore store;

        public RavenDbRepository(IDocumentStore store)
        {
            this.store = store;
            store.Initialize();
            this.session = store.OpenSession();
        }

        public void Dispose()
        {
            this.session.Dispose();
            this.store.Dispose();
            this.log.Debug("Disposed Ravendb repository.");
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new()
        {
            var items = this.All<T>().Where(expression);
            foreach (T item in items)
            {
                this.Delete(item);
            }
        }

        public void Delete<T>(T item) where T : class, IStorable, new()
        {
            this.session.Delete(item);
            this.session.SaveChanges();
            this.log.Debug($"Deleted {typeof(T)} : {item}");
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
            this.session.SaveChanges();
            this.log.Debug($"Added {typeof(T)} : {item}");
        }

        public void Add<T>(IEnumerable<T> items) where T : class, IStorable
        {
            items.ForEach(x => this.Add(x));
        }

        public IList<T> GetAll<T>()
        {
            int start = 0;
            IList<T> allItems = new List<T>();

            var current = this.session.Query<T>().Take(1024).Skip(start).ToList();

            while (current.Count > 0)
            {
                start += current.Count;
                allItems.AddRange(current);

                current = this.session.Query<T>().Take(1024).Skip(start).ToList();
            }

            return allItems;
        }
    }
}