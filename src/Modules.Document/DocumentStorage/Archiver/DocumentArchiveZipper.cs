// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentArchiveZipper.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentArchiveZipper.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.DocumentStorage.Archiver
{
    using System.Collections.Generic;
    using System.IO;

    using ICSharpCode.SharpZipLib.Zip;

    public class DocumentArchiveZipper
    {
        private readonly string baseDirectory = string.Empty;

        public DocumentArchiveZipper(string path)
        {
            this.baseDirectory = path;
        }

        public void CreateArchive(string documentName, ICollection<string> archiveFiles)
        {
            using (ZipFile zip = ZipFile.Create(Path.Combine(this.baseDirectory, documentName + ".document")))
            {
                zip.BeginUpdate();
                foreach (var archiveFile in archiveFiles)
                {
                    zip.Add(archiveFile, Path.GetFileName(archiveFile));
                }
                zip.CommitUpdate();
            }
        }
    }
}