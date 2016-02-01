// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BootstrapperTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'BootstrapperTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace UserInterface.Tests
{
    [TestFixture]
    [Ignore("Bootstrapper testing is not necessary")]
    public class BootstrapperTests
    {
        [Test]
        public void StartUpBootstrapperTest()
        {
            Bootstrapper.Bootstrapper bootstrapper = new Bootstrapper.Bootstrapper();
            bootstrapper.Run();
        }
    }
}