﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationViewConfigurationSection.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationViewConfigurationSection.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.Infrastructure.Configuration
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    public class NavigationViewConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("NavigationElements", IsRequired = true)]
        public NavigationElementCollection NavigationElements
        {
            get
            {
                return base["NavigationElements"] as NavigationElementCollection;
            }
        }
    }
}