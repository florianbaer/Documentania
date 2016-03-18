// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationConfigurationService.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationConfigurationService.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Infrastructure.Services
{
    using System.Configuration;

    using Documentania.Infrastructure.Configuration;

    public class NavigationConfigurationService
    {
        public NavigationElementCollection GetNavigationConfiguration()
        {
            return
                ((NavigationViewConfigurationSection)
                 ConfigurationManager.GetSection("NavigationViewConfigurationSection")).NavigationElements;
        }
    }
}