// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationElement.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationElement.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Infrastructure.Configuration
{
    using System.Configuration;

    public class NavigationElement : ConfigurationElement
    {
        [ConfigurationProperty("Type", IsKey = true, IsRequired = true)]
        public string Type
        {
            get
            {
                return base["Type"] as string;
            }
            set
            {
                base["Type"] = value;
            }
        }

        [ConfigurationProperty("Assembly", IsRequired = true)]
        public string Assembly
        {
            get
            {
                return base["Assembly"] as string;
            }
            set
            {
                base["Assembly"] = value;
            }
        }
    }
}