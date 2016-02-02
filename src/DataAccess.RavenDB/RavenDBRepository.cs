// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="RavenDBRepository.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'RavenDBRepository.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RavenDB
{
    using System.Collections;
    using System.Linq.Expressions;
    using Documentania.Common;
    using Documentania.Interfaces;
    using Microsoft.Practices.ServiceLocation;
    using Prism.Logging;
    using Raven.Abstractions.Extensions;
    using Raven.Client;

    public class RavenDBRepository : IRepository
    {
        private readonly DocumentaniaLogger logger =
            (DocumentaniaLogger) ServiceLocator.Current.GetInstance(typeof (ILoggerFacade));

        private readonly IDocumentSession session;
        private readonly IDocumentStore store;

        public RavenDBRepository(DocumentaniaDocumentStore store)
        {
            this.store = store;
            store.Initialize();
            session = store.OpenSession();
        }

        public void Dispose()
        {
            session.Dispose();
            store.Dispose();
            logger.Log("Disposed Ravendb repository.", Category.Info, Priority.None);
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T item) where T : class, IStorable, new()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll<T>() where T : class, IStorable, new()
        {
            throw new NotImplementedException();
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class, IStorable, new()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All<T>() where T : class, IStorable, new()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All<T>(int page, int pageSize) where T : class, IStorable, new()
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T item) where T : class, IStorable, new()
        {
            logger.Log($"Add {typeof (T)} : {item}", Category.Debug, Priority.None);
            session.Store(item);
        }

        public void Add<T>(IEnumerable<T> items) where T : class, IStorable, new()
        {
            items.ForEach(x => Add(x));
        }
    }
}