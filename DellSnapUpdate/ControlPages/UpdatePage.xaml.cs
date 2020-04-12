using DellSnapUpdate.DataProvider;
using DellSnapUpdate.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.UI.Core;
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
    public sealed partial class UpdatePage : Page
    {
        public UpdateViewModel ViewModel { get; set; }
        //Core Dispatcher for getting the UI thread
        private static CoreDispatcher _coreDispatcher;
        //Delegating the Contents Changed event handler for the folder listener
        public delegate void ListenerEventHandler(IStorageQueryResultBase sender, object args);

        public UpdatePage()
        {

            ViewModel = new UpdateViewModel();
            this.InitializeComponent();
            this.Loaded += UpdatePage_Loaded;
            _coreDispatcher = Window.Current.Dispatcher;
        }


        private async void UpdatePage_Loaded(object sender, RoutedEventArgs e)
        {
            var listenerEventHandler = new ListenerEventHandler(resultSet_ContentsChanged);
            await ViewModel.ConfigureFolderListener(listenerEventHandler);

        }

        //Triggered when we hit the Scan Button on the Update Page
        private async void ButtonScan_Click(object sender, RoutedEventArgs e)
        {
            //Launching exe to generate IC Report
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("ICGroup");

            ViewModel.IsLoading = true;
            loadingText.Visibility = Visibility.Visible;
            scanStack.Visibility = Visibility.Collapsed;
        }

        //Triggerred when we hit the Update Button after selecting the updates
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var updateInfos = driverList.ViewModel.UpdateInfos;
            var checkedUpdate = updateInfos.Where(dr => dr.IsChecked == true).ToList();
        }

        //Event Handler for the folder listener
        private async void resultSet_ContentsChanged(IStorageQueryResultBase sender, object args)
        {
            await driverList.ViewModel.LoadAsync();

            //CoreDispatcher for running in UI thread
            //Properties touching the UI should be updated with the UI thread
            await _coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ViewModel.IsLoading = false;

                driverList.Visibility = Visibility.Visible;
                updateStack.Visibility = Visibility.Visible;
                loadingText.Visibility = Visibility.Collapsed;
            });

        }
    }
}
