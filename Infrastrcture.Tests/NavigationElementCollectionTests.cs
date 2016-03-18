using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastrcture.Tests
{
    using System.Configuration;
    using System.Diagnostics;

    using Documentania.Infrastructure.Configuration;

    using ExAs;

    [TestClass]
    public class NavigationElementCollectionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void GetEnumeratorAtZero()
        {
            NavigationElementCollection collection = new NavigationElementCollection();
            NavigationElement navigationElement = collection[0];
        }

        [TestMethod]
        public void GetKeyTest()
        {
            NavigationElementCollection navigationElementCollection = ((NavigationViewConfigurationSection)ConfigurationManager.GetSection("NavigationViewConfigurationSection")).NavigationElements;
            navigationElementCollection.ExAssert(x => x.Member(m => m.Count).IsInRange(2, 2));
        }

        [TestMethod]
        [TestCategory("HappyCase")]
        [TestProperty("Created", "2016-03-18")]
        [TestProperty("Creator", "Florian Bär")]
        [TestCategory("NavigationConfiguration")]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void TryToGetUncorrectConfigurationNoKey()
        {
            // arrange
            ConfigurationFileMap fileMap = new ConfigurationFileMap($"{Environment.CurrentDirectory}/AppFail.config"); //Path to your config file
            // act
            var navigationElementCollection = ((NavigationViewConfigurationSection)ConfigurationManager.OpenMappedMachineConfiguration(fileMap).GetSection("NavigationViewConfigurationSection")).NavigationElements;
        }
    }
}
