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
    using Raven.Client.Indexes;
    using Raven.Client.Linq;
    using Raven.Client.Linq.Indexing;
    using Raven.Database.DiskIO;
    using Raven.Database.Linq.PrivateExtensions;

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
                session.Delete(session.Load<T>(item.Id));
                session.SaveChanges();
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
            this.Test();
            using (IDocumentSession session = this.store.OpenSession())
            {
                return session.Query<T>();
            }
        }

        public IQueryable<T> All<T>(int page, int pageSize) where T : class, IStorable, new()
        {
            using (IDocumentSession session = this.store.OpenSession())
            {
                return session.Query<T>().Page(page, pageSize);
            }
        }

        public IQueryable<T> All<T, P>(int page, int pageSize) where T : class, IStorable, new() where P : AbstractIndexCreationTask, new()
        {
            using (IDocumentSession session = this.store.OpenSession())
            {
                return session.Query<T, P>().Page(page, pageSize);
            }
        }

        public void Add<T>(T item) where T : class, IStorable, new()
        {
            using (IDocumentSession session = this.store.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
            }
        }

        public void Add<T>(IEnumerable<T> items) where T : class, IStorable, new()
        {
            items.ForEach(x => this.Add(x));
        }

        public void Test()
        {
            new TestItem_ByName().Execute(this.store);

            TestItem item1 = new TestItem("id1", 1, "testitem 1");
            this.Add(item1);
            TestItem item2 = new TestItem("id3", 2, "testitem 2");
            this.Add(item2);

            ItemBase baseItm = new ItemBase("id2", "baseitem 1");
            this.Add(baseItm);
            ItemBase baseItm2 = new ItemBase("id4", "baseitem 2");
            this.Add(baseItm2);


            IQueryable<ItemBase> result = this.All<ItemBase>(1, 20);

            var enumRe = result.ToList();
            Console.Write(enumRe);


            IQueryable<TestItem> results = this.All<TestItem>(1, 20);

            var enumRes = results.ToList();
            Console.Write(enumRes);
        }
    }

    public class TestItem_ByName : AbstractIndexCreationTask<TestItem>
    {
        public TestItem_ByName()
        {
            Map = items => from item in items
                           select new
                           {
                               FirstName = item.Name
                           };
        }
    }

    public class ItemBase_ByName : AbstractIndexCreationTask<ItemBase>
    {
        public ItemBase_ByName()
        {
            Map = items => from item in items
                           select new
                           {
                               FirstName = item.Name
                           };
        }
    }

    public class TestItem : ItemBase
    {
        public int Size { get; set; }

        public TestItem(string id, int size, string name)
            : base(id, name)
        {
            this.Size = size;
        }

        public TestItem()
        {
            
        }
    }

    public class ItemBase : IStorable
    {
        public ItemBase(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public ItemBase()
        {
            
        }

        public string Id { get; set; }

        public string Name { get; set; }


    }
}