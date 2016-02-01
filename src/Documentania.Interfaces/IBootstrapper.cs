// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IBootstrapper.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IBootstrapper.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Interfaces
{
    public interface IBootstrapper
    {
        void ShutDown();

        void StartUp();
    }
}