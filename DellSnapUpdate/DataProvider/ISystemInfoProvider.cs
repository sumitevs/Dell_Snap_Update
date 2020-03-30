using DellSnapUpdate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellSnapUpdate.DataProvider
{
    public interface ISystemInfoProvider
    {
        Task<SystemInfo> LoadSystemInfoAsync();
    }
}
