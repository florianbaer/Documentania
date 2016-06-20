// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FastZipProvider.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'FastZipProvider.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model.DocumentStorage.Archiver
{
    using Document.Model.Interface;

    using ICSharpCode.SharpZipLib.Zip;

    public class FastZipProvider : IZipProvider
    {
        public void Extract(string fileName, string directoryName, string fileFilter)
        {
            FastZip fastZip = new FastZip();
            fastZip.ExtractZip(fileName, directoryName, fileFilter);
        }
    }
}