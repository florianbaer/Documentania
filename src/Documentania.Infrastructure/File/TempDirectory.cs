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

        public TempDirectory() : this(true)
        {
        }

        public TempDirectory(bool deleteOnDispose)
        {
            this.FilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(this.FilePath);
            this.DelteOnDispose = deleteOnDispose;
        }

        ~TempDirectory()
        {
            this.Dispose(false);
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.DelteOnDispose)
                {
                    Directory.Delete(this.FilePath, true);
                }
            }
        }

        public override string ToString()
        {
            return this.FilePath;
        }
    }
}