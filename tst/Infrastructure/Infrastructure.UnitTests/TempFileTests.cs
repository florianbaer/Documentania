using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.UnitTests
{
    using System.IO;

    using Documentania.Infrastructure.File;

    [TestClass]
    public class TempFileTests
    {
        [TestMethod]
        [TestCategory("TempDirectory")]
        [TestCategory("Infrastructure")]
        [TestProperty("Created", "2016-06-21")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void CreateTempFileAndDeleteAfterDisposing()
        {
            string tempFilePath;

            using (var tempFile = new TempDirectory())
            {
                tempFilePath = tempFile.FilePath;
                Assert.IsTrue(Directory.Exists(tempFilePath));
            }

            Assert.IsFalse(Directory.Exists(tempFilePath));
        }

        [TestMethod]
        [TestCategory("TempDirectory")]
        [TestCategory("Infrastructure")]
        [TestProperty("Created", "2016-06-21")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void CreateTempFileAndStayAfterDisposing()
        {
            string tempFilePath;

            using (var tempFile = new TempDirectory(false))
            {
                tempFilePath = tempFile.FilePath;
                Assert.IsTrue(Directory.Exists(tempFilePath));
            }

            Assert.IsTrue(Directory.Exists(tempFilePath));
        }

        [TestMethod]
        [TestCategory("TempDirectory")]
        [TestCategory("Infrastructure")]
        [TestProperty("Created", "2016-06-21")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void CreateTempFileWithoutUsingStatement()
        {
            var tempFile = new TempDirectory();
            Assert.IsTrue(Directory.Exists(tempFile.FilePath));
        }

        [TestMethod]
        [TestCategory("TempDirectory")]
        [TestCategory("Infrastructure")]
        [TestProperty("Created", "2016-06-21")]
        [TestProperty("Creator", "baerf")]
        [TestCategory("HappyCase")]
        public void CreateTempFileWithoutUsingStatementSetToNull()
        {
            var tempFile = new TempDirectory();

            string filePath = tempFile.FilePath;
            Assert.IsTrue(Directory.Exists(filePath));
            tempFile = null;

            Assert.IsTrue(Directory.Exists(filePath));
        }
    }
}
