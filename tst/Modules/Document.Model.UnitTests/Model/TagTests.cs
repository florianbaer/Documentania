using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Document.Model.UnitTests.Model
{
    using Document.Model.Models;

    using ExAs;

    [TestClass]
    public class TagTests
    {
        [TestMethod]
        [TestCategory("PropertyTests")]
        [TestCategory("DocumentModule")]
        [TestCategory("Tag")]
        [TestProperty("Created", "2016-06-16")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void PropertyTest()
        {
            const string Value = "Test Tag";
            const string Name = "TestTag";
            const string Id = "Id";
            Tag tag = new Tag() { Id = Id, Value = Value, Name = Name };

            tag.ExAssert(t => t.Member(x => x.Value).IsEqualTo(Value).Member(x => x.Name).IsEqualTo(Name).Member(x => x.Id).IsEqualTo(Id));
        }
    }
}
