// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Item.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'Item.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB.Tests.Utils
{
    using Documentania.Contracts;

    public class Item : IStorable
    {
        public Item(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Item()
        {
        }

        public string Name { get; set; }

        public string Id { get; set; }
    }
}