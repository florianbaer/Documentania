using Raven.Client;

namespace DataAccess.RavenDB.Tests.Utils
{
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
