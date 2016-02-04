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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [Ignore]
    public class BootstrapperTests
    {
        [TestMethod]
        public void StartUpBootstrapperTest()
        {
            Bootstrapper.Bootstrapper bootstrapper = new Bootstrapper.Bootstrapper();
            bootstrapper.Run();
        }
    }
}