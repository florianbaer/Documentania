namespace DocumentModule.Tests
{
    using System;
    using System.Collections.Generic;

    using ExAs;

    using Modules.Document;

    using NUnit.Framework;

    [TestFixture]
    public class DocumentTests
    {
        [Test]
        public void PropertyTest()
        {
            Tag tagToAssert = new Tag() { Id = "Tag", Value = "Tag" };

            Document document = new Document()
                                    {
                                        Path = "Path",
                                        Tags = new List<Tag>() { tagToAssert },
                                        DateReceived = DateTime.Now,
                                        Id = "Document"
                                    };

            document.ExAssert(x => x.Member(m => m.Id).IsEqualTo(document.Id)
                                    .Member(m => m.DateReceived).IsOnSameDayAs(document.DateReceived)
                                    .Member(m => m.Path).IsEqualTo(document.Path)
                                    .Member(m => m.Tags[0]).Fulfills(n => n.Member(v => v.Id).IsEqualTo(tagToAssert.Id)
                                                                           .Member(v => v.Value).IsEqualTo(tagToAssert.Value)));
        }
    }
}