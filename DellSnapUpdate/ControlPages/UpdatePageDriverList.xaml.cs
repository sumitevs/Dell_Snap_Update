using DellSnapUpdate.DataProvider;
using DellSnapUpdate.ViewModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DellSnapUpdate.ControlPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdatePageDriverList : Page
    {
        public DriverListViewModel ViewModel { get; set; }
        public UpdatePageDriverList()
        {
            ViewModel = new DriverListViewModel(new UpdateInfoProvider());
            this.InitializeComponent();
            //this.Loaded += UpdatePageDriverList_Loaded;
        }

        private async void UpdatePageDriverList_Loaded(object sender, RoutedEventArgs e)
        {
            //ViewModel.LoadDummyAsync();
            //await ViewModel.LoadAsync();

        }
    }
}
