// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationElementCollection.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationElementCollection.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.Infrastructure.Configuration
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    [ConfigurationCollection(typeof(NavigationElement), AddItemName = "NavigationElement")]
    public class NavigationElementCollection : ConfigurationElementCollection, IEnumerable<NavigationElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new NavigationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var navigationElement = element as NavigationElement;
            if (navigationElement != null)
            {
                return navigationElement.Type;
            }
            else
            {
                return null;
            }
        }

        public NavigationElement this[int index]
        {
            get
            {
                return BaseGet(index) as NavigationElement;
            }
        }
        
        public IEnumerator<NavigationElement> GetEnumerator()
        {
            return ( from i in Enumerable.Range( 0, this.Count )
                     select this[i] )
                    .GetEnumerator();
        }
    }
}