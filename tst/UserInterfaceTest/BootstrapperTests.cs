// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BootstrapperTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'BootstrapperTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace UserInterface.Tests
{
    using System.Windows;

    using Documentania;

    using ExAs;

    using log4net;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BootstrapperTests
    {
        [TestMethod]
        [TestCategory("HappyCase")]
        [TestProperty("Created", "2016-03-18")]
        [TestProperty("Creator", "Florian Bär")]
        [TestCategory("Bootstrapper")]
        public void CreateInstanceOfBootstrapperTest()
        {
            // act
            var bootstrapper = new Bootstrapper();

            // assert
            var log = LogManager.GetLogger(typeof(BootstrapperTests));
            log.ExAssert(x => x.IsNotNull());
        }

        [TestMethod]
        [TestCategory("HappyCase")]
        [TestProperty("Created", "2016-03-18")]
        [TestProperty("Creator", "Florian Bär")]
        [TestCategory("Bootstrapper")]
        public void RunBootstrapperTest()
        {
            // act
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
            Application.Current.Shutdown();
        }
    }
}