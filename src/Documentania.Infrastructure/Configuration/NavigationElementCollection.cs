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
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using Microsoft.Practices.Unity.Utility;

    [ConfigurationCollection(typeof(NavigationElement), AddItemName = "NavigationElement")]
    public class NavigationElementCollection : ConfigurationElementCollection, IEnumerable<NavigationElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new NavigationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            Guard.ArgumentNotNull(element, "element");
            var navigationElement = element as NavigationElement;

            if (navigationElement == null)
            {
                throw new InvalidCastException($"Passed element {element.GetType()} can not be casted to {typeof(NavigationElement)}.");
            }

            return navigationElement.Type;
        }

        public NavigationElement this[int index] => this.BaseGet(index) as NavigationElement;

        public new IEnumerator<NavigationElement> GetEnumerator()
        {
            return ( from i in Enumerable.Range( 0, this.Count )
                     select this[i] )
                    .GetEnumerator();
        }
    }
}