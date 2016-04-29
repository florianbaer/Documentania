// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="TagTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'TagTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DocumentModule.Tests
{
    using Documentania.Infrastructure.Models;

    using ExAs;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Modules.Document;

    [TestClass]
    public class TagTests
    {
        [TestMethod]
        [TestCategory("PropertyTests")]
        [TestCategory("DocumentModule")]
        [TestProperty("Created", "2016-03-17")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void PropertyTest()
        {
            Tag tagToAssert = new Tag { Id = "Tag", Value = "Tag" };

            tagToAssert.ExAssert(
                x => x.Member(m => m.Id).IsEqualTo(tagToAssert.Id).Member(m => m.Value).IsEqualTo(tagToAssert.Value));
        }
    }
}