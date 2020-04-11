using DellSnapUpdate.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DellSnapUpdate.DataProvider
{
    public interface IUpdateInfoProvider
    {
        Task<List<UpdateInfo>> GetSwbUpdatesAsync();
    }
}