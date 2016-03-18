using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentModule.Tests
{
    using System.Windows;
    using System.Windows.Controls;

    using Modules.Document.Extensions;

    [TestClass]
    public class WebBrowserExtensionTests
    {
        [TestMethod]
        [TestCategory("HappyCase")]
        [TestProperty("Created", "2016-03-18")]
        [TestProperty("Creator", "Florian Bär")]
        [TestCategory("WebBrowser")]
        public void WebBrowserExtensionTest()
        {
            // arrange
            DependencyObject dependencyObject = new WebBrowser() as DependencyObject;

            // act
            WebBrowserExtension.SetBindableSource(dependencyObject, "http://google.ch");

            // assert

        }
    }
}
