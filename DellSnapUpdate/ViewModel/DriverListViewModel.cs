using DellSnapUpdate.DataProvider;
using DellSnapUpdate.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace DellSnapUpdate.ViewModel
{
    public class DriverListViewModel
    {
        private IUpdateInfoProvider _updateInfoProvider;
        public ObservableCollection<UpdateInfo> UpdateInfos { get; }

        //Core Dispatcher for running certain code in UI thread
        private static CoreDispatcher _coreDispatcher;

        public DriverListViewModel(IUpdateInfoProvider updateDataProvider)
        {
            _updateInfoProvider = updateDataProvider;
            UpdateInfos = new ObservableCollection<UpdateInfo>();
            _coreDispatcher = Window.Current.Dispatcher;
        }

        //Get the Updates with API call and update UpdateInfos
        public async Task LoadAsync()
        {

            var updates = await Task.Run(() => new UpdateInfoProvider().GetSwbUpdatesAsync());

            var isUIThread = _coreDispatcher.HasThreadAccess;

            await _coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                UpdateInfos.Clear();
                foreach (var update in updates)
                {
                    UpdateInfos.Add(update);
                }

            });

        }
    }
}
