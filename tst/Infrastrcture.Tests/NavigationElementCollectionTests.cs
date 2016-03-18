// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationElementCollectionTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationElementCollectionTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Infrastrcture.Tests
{
    using System;
    using System.Configuration;

    using Documentania.Infrastructure.Configuration;

    using ExAs;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            NavigationElementCollection navigationElementCollection =
                ((NavigationViewConfigurationSection)
                 ConfigurationManager.GetSection("NavigationViewConfigurationSection")).NavigationElements;
            navigationElementCollection.ExAssert(x => x.Member(m => m.Count).IsInRange(2, 2));
        }

        [TestMethod]
        [TestCategory("HappyCase")]
        [TestProperty("Created", "2016-03-18")]
        [TestProperty("Creator", "Florian Bär")]
        [TestCategory("NavigationConfiguration")]
        [DeploymentItem("AppFail.config")]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void TryToGetUncorrectConfigurationNoKey()
        {
            // arrange
            ConfigurationFileMap fileMap = new ConfigurationFileMap($"{Environment.CurrentDirectory}/AppFail.config");
                //Path to your config file
            // act
            var navigationElementCollection =
                ((NavigationViewConfigurationSection)
                 ConfigurationManager.OpenMappedMachineConfiguration(fileMap)
                     .GetSection("NavigationViewConfigurationSection")).NavigationElements;
        }
    }
}