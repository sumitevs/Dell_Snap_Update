using DellSnapUpdate.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Search;
using static DellSnapUpdate.ControlPages.UpdatePage;

namespace DellSnapUpdate.ViewModel
{
    public class UpdateViewModel : Observable
    {
        private bool isLoading;

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        //Adding Folder Listener for xml files
        //Triggers on Create, Delete and Modify
        public async Task ConfigureFolderListener(ListenerEventHandler listenerEventHandler)
        {
            //Add capability "broadFileSystemAccess" in Package.appxmanifest  
            //In Settings -> Privacy -> File System grant access to this App
            var storageFolder = await StorageFolder.GetFolderFromPathAsync(@"C:\Users\Debopriya_Bhattachar\Desktop\ic\IC");
            var supportedExtension = new List<string> { ".xml" };
            QueryOptions option = new QueryOptions(CommonFileQuery.DefaultQuery, supportedExtension);
            option.FolderDepth = FolderDepth.Shallow;
            option.IndexerOption = IndexerOption.UseIndexerWhenAvailable;
            StorageFileQueryResult resultSet = storageFolder.CreateFileQueryWithOptions(option);

            //Event only fires after GetFilesAsync has been called atleast once
            await resultSet.GetFilesAsync(0, 1);
            resultSet.ContentsChanged += new TypedEventHandler<IStorageQueryResultBase, object>(listenerEventHandler);
        }
    }
}
