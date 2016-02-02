// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IStorable.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'IStorable.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.Interfaces
{
    public interface IStorable
    {
        void Store(bool withRelation);
    }
}