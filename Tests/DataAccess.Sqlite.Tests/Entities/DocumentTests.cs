using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Sqlite.Entities;
using System.IO;

namespace DataAccess.Sqlite.Tests.Entities
{
    [TestFixture]
    public class DocumentTests
    {
        [OneTimeSetUp]
        public void SetupDataForMemberVerification()
        {
            using (var db = new DocumentaniaContext())
            {
                db.Database.EnsureCreated();
                SetupTestEnvironment(db);
            }
        }

        private static void SetupTestEnvironment(DocumentaniaContext db)
        {
            db.Documents.Add(new Document()
            {
                Imported = new DateTime(2014, 03, 13, 19, 24, 20),
                Path = "TestPath",
                Tags = new List<Tag>()
                {
                    new Tag()
                    {
                        Name = "Fun"
                    }
                }
            });

            db.Documents.Add(new Document()
            {
                Imported = new DateTime(1997, 04, 28),
                Path = "Oberrohrdorf",
                Tags = new List<Tag>()
                {
                    new Tag()
                    {
                        Name = "Love"
                    }
                }
            });
        }

        [Test]
        public void DocumentMemberVerification()
        {
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            File.Delete("Documentania.db");
        }
    }
}
