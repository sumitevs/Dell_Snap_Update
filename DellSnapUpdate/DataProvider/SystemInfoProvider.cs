using DellSnapUpdate.Model;
using System.Threading.Tasks;

namespace DellSnapUpdate.DataProvider
{
    class SystemInfoProvider : ISystemInfoProvider
    {
        public async Task<SystemInfo> LoadSystemInfoAsync()
        {
            //need to run query to get this data
            //return dummy data for time being
            return new SystemInfo() { ServiceTag = "FY091X2", ModelName = "Precision 5530", LastCheck = "21st March" };
        }


    }
}
