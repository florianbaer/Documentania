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
    using Documentania;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BootstrapperTests
    {
        [TestMethod]
        [Ignore]
        public void StartUpBootstrapperTest()
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}