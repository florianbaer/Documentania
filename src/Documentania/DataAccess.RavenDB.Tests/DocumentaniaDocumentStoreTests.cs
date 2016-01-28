using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.RavenDB.Tests
{
    using System.Security.Policy;
    
    using NUnit.Framework;

    using Raven.Client;

    using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

    /// <summary>
    /// Summary description for DocumentaniaDocumentStoreTests
    /// </summary>
    [TestFixture]
    public class DocumentaniaDocumentStoreTests
    {
        [Test]
        public void TestCreateDocumentAndReadIt()
        {
            using (IDocumentStore store = new DocumentaniaDocumentStore("http://tromwn5930:8080/", "Documentania")) 
            {
                store.Initialize(); // initializes document store, by connecting to server and downloading various configurations

                using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
                {
                    Document document = new Document() { Imported = DateTime.Now, Path = "asdf" };

                    session.Store(document); // stores employee in session, assigning it to a collection `Employees`
                    string documentId = document.Id; // Session.Store will assign Id to employee, if it is not set

                    session.SaveChanges(); // sends all changes to server

                    // Session implements Unit of Work pattern,
                    // therefore employee instance would be the same and no server call will be made
                    Document loadedEmployee = session.Load<Document>(documentId);
                    Assert.Equals(document, loadedEmployee);
                }
            }
        }
      
    }
}
