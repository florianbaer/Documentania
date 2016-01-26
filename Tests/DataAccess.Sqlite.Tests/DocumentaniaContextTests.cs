using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Sqlite.Tests
{
    using System.IO;
    using System.Runtime.CompilerServices;

    using ExAs;

    [TestClass]
    public class DocumentaniaContextTests
    {
        [TestInitialize]
        public void TestsInitialize()
        {
            using (var db = new DocumentaniaContext())
            {
                db.Database.EnsureCreated();
            }
        }

        [TestMethod]
        public void DatabaseIsCreated_Under_Documentania_DB()
        {
            File.Exists("Documentania.db").Evaluate(x => x);
        }
    }
}
