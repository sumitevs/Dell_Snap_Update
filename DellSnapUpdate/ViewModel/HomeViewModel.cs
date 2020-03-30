using DellSnapUpdate.DataProvider;
using DellSnapUpdate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellSnapUpdate.ViewModel
{
    class HomeViewModel
    {
        public SystemInfo SystemInfo { get; }

        public ISystemInfoProvider _systemInfoProvider;

        public HomeViewModel(ISystemInfoProvider systemInfoProvider)
        {
            SystemInfo = new SystemInfo();
            _systemInfoProvider = systemInfoProvider;
        }

        public async Task LoadAsync()
        {
            var systemInfoItem = await _systemInfoProvider.LoadSystemInfoAsync();
            SystemInfo.ModelName = systemInfoItem.ModelName;
            SystemInfo.ServiceTag = systemInfoItem.ServiceTag;
            SystemInfo.LastCheck = systemInfoItem.LastCheck;
        }
    }
}
