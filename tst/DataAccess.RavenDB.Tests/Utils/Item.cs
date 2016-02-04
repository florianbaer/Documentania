using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RavenDB.Tests.Utils
{
    using System.Security.RightsManagement;

    using Documentania.Interfaces;

    public class Item : IStorable
    {
        public Item(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Name { get; set; }

        public string Id { get; set; }
    }
}
