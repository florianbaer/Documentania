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
    using System.Net.Mime;
    using System.Runtime.Hosting;
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
            Bootstrapper bootstrapper = new Bootstrapper();

            // assert
            ILog log = LogManager.GetLogger(typeof(BootstrapperTests));
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
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
            Application.Current.Shutdown();
        }
    }
}