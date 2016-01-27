using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Sqlite.Entities;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using ExAs;
using ExAs.Results;

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
            var doc = new Document()
            {
                Imported = new DateTime(2014, 03, 13),
                Path = "Baden",
                DocumentTags =
                                  new List<DocumentTag>()
            };

            var docTag = new DocumentTag() { Tag = new Tag() { Name = "BGF" }, Document = doc };

            doc.DocumentTags.Add(docTag);

            db.Documents.Add(doc);

            doc = new Document()
                          {
                              Imported = new DateTime(1997, 04, 28),
                              Path = "Oberrohrdorf",
                              DocumentTags =
                                  new List<DocumentTag>()
                          };
            docTag = new DocumentTag() { Tag = new Tag() { Name = "Love" } ,Document = doc};
            doc.DocumentTags.Add(docTag);
            db.Documents.Add(doc);

            db.SaveChanges();
        }

        [Test]
        public void DocumentMemberVerification()
        {
            using (var db = new DocumentaniaContext())
            {
                Document firstDocument = db.Documents.Where(x => x.Path == "Oberrohrdorf").FirstOrDefault();

                firstDocument.ExAssert(r => r.Member(x => x.Path).IsEqualTo("Oberrohrdorf")
                    .Member(x => x.Imported).IsOnSameDayAs(new DateTime(1997, 04, 28))
                    .Member(x => x.DocumentTags.FirstOrDefault().Tag).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Love")));

                Document secondDocument = db.Documents.FirstOrDefault(x => x.Path == "Baden");

                secondDocument.ExAssert(r => r.Member(x => x.Path).IsEqualTo("Baden")
                         .Member(x => x.Imported).IsOnSameDayAs(new DateTime(2014, 3, 13))
                         .Member(x => x.DocumentTags.FirstOrDefault().Tag).Fulfills(n => n.Member(x => x.Name).IsEqualTo("BGF")));
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            File.Delete("Documentania.db");
        }
    }
}
