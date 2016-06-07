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
    using System.Management.Instrumentation;

    using DataAccess.RavenDB.Extension;

    using Documentania.Infrastructure.Interfaces;

    using log4net;
    using Raven.Abstractions.Extensions;
    using Raven.Client;
    using Raven.Client.Linq;

    using Rhino.Licensing;

    public class RavenDbRepository : IRepository
    {
        private readonly ILog log = LogManager.GetLogger(typeof(RavenDbRepository));

        private readonly IDocumentStore store;

        public RavenDbRepository(IDocumentStore store)
        {
            this.store = store;
            store.Initialize();
        }

        public void Dispose()
        {
            this.store.Dispose();
            this.log.Debug("Disposed Ravendb repository.");
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new()
        {
            using (IDocumentSession session = this.store.OpenSession())
            {
                Queryable.Where(session.Query<T>(), expression).ForEach(x => session.Delete(x));
            }
        }

        public void Delete<T>(T item) where T : class, IStorable, new()
        {
            using (IDocumentSession session = this.store.OpenSession())
            {
                session.Delete(item);
            }
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new()
        {
            using (IDocumentSession session = this.store.OpenSession())
            {
                return Queryable.Where(session.Query<T>(), expression).Single();
            }
        }

        public IQueryable<T> All<T>() where T : class, IStorable, new()
        {
            using (IDocumentSession session = this.store.OpenSession())
            {
                return session.Query<T>().AsQueryable();
            }
        }

        public IQueryable<T> All<T>(int page, int pageSize) where T : class, IStorable, new()
        {
            using (IDocumentSession session = this.store.OpenSession())
            {
                return session.Query<T>().Page(page, pageSize);
            }
        }

        public void Add<T>(T item) where T : class, IStorable, new()
        {
            using (IDocumentSession session = this.store.OpenSession())
            {
                session.Store(item);
            }
        }

        public void Add<T>(IEnumerable<T> items) where T : class, IStorable, new()
        {
            items.ForEach(x => this.Add(x));
        }
    }
}