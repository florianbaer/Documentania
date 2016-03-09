using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentania.Infrastructure.Services
{
    using System.Configuration;

    using Documentania.Infrastructure.Configuration;

    public class NavigationConfigurationService
    {
        public NavigationElementCollection GetNavigationConfiguration()
        {
            var section = (NavigationViewConfigurationSection)ConfigurationManager.GetSection("NavigationViewConfigurationSection");
            return section.NavigationElements;
        }
    }
}
