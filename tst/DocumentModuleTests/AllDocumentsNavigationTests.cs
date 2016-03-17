using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentModule.Tests
{
    using ExAs;

    using Modules.Document.Navigation;

    using Moq;

    using Prism.Regions;

    [TestClass]
    public class AllDocumentsNavigationTests
    {
        private const string AllDocumentsTitle = "All Documents";

        [TestMethod]
        public void PropertyTest()
        {
            AllDocumentsNavigation navigation = new AllDocumentsNavigation();
            Mock<IRegionManager> regionManagerMock = new Mock<IRegionManager>();
            regionManagerMock.Setup(x => x.RequestNavigate(It.IsAny<string>(), It.IsAny<Uri>()));
            
            navigation.SetRegionManager(regionManagerMock.Object);
            navigation.NavigateTo();
            navigation.ExAssert(x => x.Member(m => m.Title).IsEqualTo(AllDocumentsTitle));
            regionManagerMock.Verify(x => x.RequestNavigate(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
