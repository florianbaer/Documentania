// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BootstrapperTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'BootstrapperTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace UserInterfaceTest
{
    using NUnit.Framework;

    using UserInterface.Bootstrapper;

    [TestFixture]
    [Ignore("Bootstrapper testing is not necessary")]
    public class BootstrapperTests
    {
        [Test]
        public void StartUpBootstrapperTest()
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}