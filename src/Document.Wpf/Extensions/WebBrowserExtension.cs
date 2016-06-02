// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="WebBrowserExtension.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'WebBrowserExtension.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Document.Wpf.Extensions
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public class WebBrowserExtension
    {
        public static readonly DependencyProperty BindableSourceProperty =
            DependencyProperty.RegisterAttached(
                "BindableSource",
                typeof(object),
                typeof(WebBrowserExtension),
                new UIPropertyMetadata(null, BindableSourcePropertyChanged));

        public static object GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        public static void SetBindableSource(DependencyObject obj, object value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        public static void BindableSourcePropertyChanged(DependencyObject webBrowser, DependencyPropertyChangedEventArgs eventArgs)
        {
            WebBrowser browser = webBrowser as WebBrowser;

            if (browser == null)
            {
                return;
            }

            Uri uri = null;

            if (eventArgs.NewValue is string)
            {
                var uriString = eventArgs.NewValue as string;
                uri = string.IsNullOrWhiteSpace(uriString) ? null : new Uri(uriString);
            }
            else if (eventArgs.NewValue is Uri)
            {
                uri = eventArgs.NewValue as Uri;
            }
            browser.Navigate(@uri);
        }
    }
}