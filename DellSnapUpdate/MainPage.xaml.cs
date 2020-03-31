using DellSnapUpdate.ControlPages;
using DellSnapUpdate.Controls;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DellSnapUpdate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Setting default selection to Navigation
            NavView.SelectedItem = NavView.MenuItems.ElementAt(0);
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            //Frame rootFrame = (Frame)rootPage.FindName("rootFrame"); ;

            if (args.IsSettingsSelected)
            {
                //ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {
                    case "Home":
                        Type targetPageType = typeof(HomePage);
                        ContentFrame.Navigate(targetPageType);
                        break;
                    case "About":
                        NavView.Header = "About Snap Update...";
                        ContentFrame.Navigate(typeof(AboutPage));
                        break;
                    case "Update":
                        NavView.Header = "Update through Snap Update...";
                        ContentFrame.Navigate(typeof(UpdatePage));
                        break;
                    case "Configure":
                        NavView.Header = "Configure Snap Update...";
                        ContentFrame.Navigate(typeof(ConfigurePage));
                        break;

                }
            }

        }
    }
}
