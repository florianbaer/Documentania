namespace Infrastructure.UnitTests
{
    using Documentania.Infrastructure.Logger;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Prism.Logging;

    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        [TestCategory("HappyCase")]
        [TestProperty("Created", "2016-03-18")]
        [TestProperty("Creator", "Florian Bär")]
        [TestCategory("Logger")]
        public void LogDocumentaniaTest()
        {
            // arrange
            log4net.Config.XmlConfigurator.Configure();
            DocumentaniaLogger logger = new DocumentaniaLogger();

            // act
#pragma warning disable CS0618 // Type or member is obsolete

            logger.Log("Debug", Category.Debug, Priority.Low);
            logger.Log("Debug", Category.Debug, Priority.Medium);
            logger.Log("Debug", Category.Debug, Priority.High);

            logger.Log("Info", Category.Info, Priority.Low);
            logger.Log("Info", Category.Info, Priority.Medium);
            logger.Log("Info", Category.Info, Priority.High);

            logger.Log("Warn", Category.Warn, Priority.Low);
            logger.Log("Warn", Category.Warn, Priority.Medium);
            logger.Log("Warn", Category.Warn, Priority.High);

            logger.Log("Exception", Category.Exception, Priority.Low);
            logger.Log("Exception", Category.Exception, Priority.Medium);
            logger.Log("Exception", Category.Exception, Priority.High);
            
#pragma warning restore CS0618 // Type or member is obsolete

            // assert

        }
    }
}
