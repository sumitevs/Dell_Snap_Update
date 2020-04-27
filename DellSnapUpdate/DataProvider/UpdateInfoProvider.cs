using DellSnapUpdate.API_Helpers;
using DellSnapUpdate.Model;
using DellSnapUpdate.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;

namespace DellSnapUpdate.DataProvider
{
    public class UpdateInfoProvider : IUpdateInfoProvider
    {
        //Getting the Inventory.xml and giving it as an input
        //to the API, getting back the list of updates
        public async Task<List<UpdateInfo>> GetSwbUpdatesAsync()
        {
            List<UpdateInfo> updatesInfoList = null;
            using (var client = new HttpClient())
            {
                //IP of the azure VM in cloud
                client.BaseAddress = new Uri("http://137.117.96.234/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var userDataPath = UserDataPaths.GetDefault();
                var desktopPath = userDataPath.Desktop;
                var folderPath = desktopPath + @"\IC";

                var storageFolder = await StorageFolder.GetFolderFromPathAsync(folderPath);
                var file = await storageFolder.GetFileAsync("ICJson.json");

                //Reading the xml from the file stream
                string icReport;
                using (Stream fileStream = await file.OpenStreamForReadAsync())
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    icReport = await streamReader.ReadToEndAsync();
                }

                //Enabling SSL on the API might not work and throw invalid certificate error
                //Exception: "The certificate authority is invalid or incorrect"
                var response = await client.PostAsJsonAsync("api/PlatformInfo/SwbUpdatesJSON", icReport);

                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStringAsync();
                    updatesInfoList = JsonConvert.DeserializeObject<List<UpdateInfo>>(stream);
                }

            }

            return updatesInfoList;
        }
    }
}
