using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastrcture.Tests
{
    using Documentania.Infrastructure.Configuration;
    using Documentania.Infrastructure.Services;

    [TestClass]
    public class NavigationConfigurationServiceTest
    {
        private const int ExpectedElements = 2;

        [TestMethod]
        public void NavigateToTest()
        {
            NavigationConfigurationService service = new NavigationConfigurationService();
            NavigationElementCollection navigationElementCollection = service.GetNavigationConfiguration();
            Assert.AreEqual(ExpectedElements, navigationElementCollection.Count);
        }
    }
}
