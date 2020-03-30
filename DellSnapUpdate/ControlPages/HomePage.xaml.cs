using DellSnapUpdate.DataProvider;
using DellSnapUpdate.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DellSnapUpdate.ControlPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private HomeViewModel homeViewModel;
        public HomePage()
        {

            homeViewModel = new HomeViewModel(new SystemInfoProvider());
            this.Loaded += HomeInfoLoaded;
            this.InitializeComponent();
        }

        private async void HomeInfoLoaded(object sender, RoutedEventArgs e)
        {
            await homeViewModel.LoadAsync();
        }
    }
}
