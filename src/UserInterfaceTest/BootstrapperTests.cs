using System;
using NUnit.Framework;
using UserInterface.Bootstrapper;

namespace UserInterfaceTest
{
    [TestFixture]
    public class BootstrapperTests
    {
        [Test]
        public void StartUpBootstrapperTest()
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.StartUp();
        }
    }
}