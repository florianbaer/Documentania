// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DatabaseEnvironment.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DatabaseEnvironment.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.RavenDB.Tests.Utils
{
    using Raven.Client;

    public class DatabaseEnvironment
    {
        public static void DropDatabase()
        {
            using (IDocumentStore store = new DocumentaniaDocumentStore("http://localhost:1303", "Documentania"))
            {
                store.Initialize();
                store.DatabaseCommands.GlobalAdmin.DeleteDatabase("Documentania", true);
            }
        }
    }
}