// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentModuleTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentModuleTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DocumentModule.Tests
{
    using Documentania.Infrastructure;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Modules.Document;
    using Modules.Document.Views;

    using Moq;

    using Prism.Regions;

    [TestClass]
    public class DocumentModuleTests
    {
        [TestMethod]
        [TestCategory("HappyCase")]
        [TestCategory("Modules")]
        [TestCategory("DocumentModule")]
        [TestProperty("Created", "2016-03-17")]
        [TestProperty("Creator", "baerf")]
        public void DocumentModuleInitializeTest()
        {
            Mock<IServiceLocator> locatorMock = new Mock<IServiceLocator>();
            Mock<IUnityContainer> unityMock = new Mock<IUnityContainer>();
            Mock<IRegionManager> regionManagerMock = new Mock<IRegionManager>();

            locatorMock.Setup(x => x.GetInstance<IUnityContainer>()).Returns(unityMock.Object);
            locatorMock.Setup(x => x.GetInstance<IRegionManager>()).Returns(regionManagerMock.Object);

            DocumentModule module = new DocumentModule(locatorMock.Object);
            module.Initialize();

            // Views
            regionManagerMock.Verify(x => x.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(AllDocumentsView)));
            regionManagerMock.Verify(
                x => x.RegisterViewWithRegion(RegionNames.SubNavigationRegion, typeof(DocumentsSubMenuView)));
        }
    }
}