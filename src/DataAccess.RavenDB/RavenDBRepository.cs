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
        private IDocumentStore store;

        private IDocumentSession session;

        DocumentaniaLogger logger = (DocumentaniaLogger)ServiceLocator.Current.GetInstance(typeof(ILoggerFacade));

        public RavenDBRepository(DocumentaniaDocumentStore store)
        {
            this.store = store;
            store.Initialize();
            session = store.OpenSession();
        }

        public void Dispose()
        {
            this.session.Dispose();
            this.store.Dispose();
            this.logger.Log("Disposed Ravendb repository.", Category.Info, Priority.None);
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
            this.logger.Log($"Add {typeof(T)} : {item}", Category.Debug, Priority.None);
            this.session.Store(item);
        }
        
        public void Add<T>(IEnumerable<T> items) where T : class, IStorable, new()
        {
            items.ForEach(x => Add(x));
        }
    }
}
