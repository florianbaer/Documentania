// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationConfigurationServiceTest.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationConfigurationServiceTest.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Infrastrcture.Tests
{
    using Documentania.Infrastructure.Configuration;
    using Documentania.Infrastructure.Services;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

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