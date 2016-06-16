// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentModuleTests.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentModuleTests.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.Model.UnitTests
{
    using Document.Model;
    using Document.Model.DocumentStorage.Archiver;
    using Document.Model.Interface;

    using Documentania.SplashScreen.Events;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Prism.Events;

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
            Mock<IEventAggregator> eventAggreagatorMock = new Mock<IEventAggregator>();

            locatorMock.Setup(x => x.GetInstance<IUnityContainer>()).Returns(unityMock.Object);
            locatorMock.Setup(x => x.GetInstance<IEventAggregator>()).Returns(eventAggreagatorMock.Object);

            eventAggreagatorMock.Setup(x => x.GetEvent<MessageUpdateEvent>()).Returns(new MessageUpdateEvent());
            
            DocumentModelModule module = new DocumentModelModule(locatorMock.Object);
            module.Initialize();
        }
    }
}