using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Document.Model.UnitTests
{
    using ExAs;
    using TemplateEngine;

    [TestClass]
    public class DocumentTemplateTests
    {
        [TestMethod]
        public void DocumentTemplateTest()
        {
            DocumentTemplate template = new DocumentTemplate.DocumentTemplateBuilder("Test Document Typ").AddProperty("Added", DateTime.Now).Construct();

            template.ExAssert(m => m.Member(x => x.Name).IsEqualTo("Test Document Typ").Member(x => x.Properties.Count).IsEqualTo(1));
        }
    }
}
