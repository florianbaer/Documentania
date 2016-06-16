using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Document.Model.UnitTests.Filtering
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Document.Model.Filter;
    using Document.Model.Models;

    using ExAs;

    [TestClass]
    public class AllDocumentsFilterTests
    {
        [TestMethod]
        [TestCategory("DocumentModule")]
        [TestCategory("Filter")]
        [TestProperty("Created", "2016-06-16")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void ReturnAllDocumentsTest()
        {
            ICollection<Document> documents = new List<Document>();

            documents.Add(
                new Document
                    {
                        Path = "Path",
                        Tags = new List<Tag> { new Tag() {Id = "1", Name = "1", Value = "1"} },
                        DateReceived = new DateTime(2014, 03, 13, 19, 24, 00),
                        Id = "Document",
                        Name = "MyDocument",
                        Imported = new DateTime(2014, 03, 13, 19, 24, 00)
                    });

            documents.Add(
                new Document
                {
                    Path = "Path2",
                    Tags = new List<Tag> { new Tag() { Id = "2", Name = "2", Value = "2" } },
                    DateReceived = new DateTime(2013, 03, 13, 19, 24, 00),
                    Id = "Document2",
                    Name = "MyDocument2",
                    Imported = new DateTime(2013, 03, 13, 19, 24, 00)
                });

            AllDocumentsFilter filter = new AllDocumentsFilter();
            ICollection<Document> result = filter.Execute(documents);

            result.ExAssert(m => m.Member(x => x.Count).IsEqualTo(2).Member(x => x.ElementAt(0)).Fulfills(t => t.Member(x => x.Id).IsEqualTo(documents.ElementAt(0).Id)));
        }
    }
}
