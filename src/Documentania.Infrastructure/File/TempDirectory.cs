// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="TempDirectory.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'TempDirectory.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.Infrastructure.File
{
    using System;
    using System.IO;

    public class TempDirectory : IDisposable
    {
        public string FilePath { get; set; }
        public bool DelteOnDispose { get; set; }


        public TempDirectory(bool deleteOnDispose = true)
        {
            this.FilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(this.FilePath);
            this.DelteOnDispose = deleteOnDispose;
        }

        public void Dispose()
        {
            if (this.DelteOnDispose)
            {
                Directory.Delete(this.FilePath, true);
            }
        }

        public override string ToString()
        {
            return this.FilePath;
        }
    }
}