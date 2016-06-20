// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IZipProvider.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IZipProvider.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model.Interface
{
    public interface IZipProvider
    {
        void Extract(string fileName, string directoryName, string fileFilter);
    }
}