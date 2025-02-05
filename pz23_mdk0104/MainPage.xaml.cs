using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.UI.Interop;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace pz23_mdk0104
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<string> bookmarks = new List<string>();

        public MainPage()
        {
            this.InitializeComponent();
        }


        private void goBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigateToUrl(addressBar.Text);
        }

        private void addressBar_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                NavigateToUrl(addressBar.Text);
            }
        }

        private void NavigateToUrl(string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }
            webView.Navigate(new Uri(url));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentUrl = addressBar.Text;
            if (!string.IsNullOrWhiteSpace(currentUrl) && !bookmarks.Contains(currentUrl))
            {
                bookmarks.Add(currentUrl);
                AddBookmarkToFlyout(currentUrl);
            }
        }

        private void AddBookmarkToFlyout(string url)
        {
            var menuItem = new MenuFlyoutItem { Text = url };
            menuItem.Click += (s, e) => NavigateToUrl(url);
            bookmarksFlyout.Items.Add(menuItem);
        }
    }
}
