using DellSnapUpdate.Base;

namespace DellSnapUpdate.Model
{
    public class SystemInfo : Observable
    {
        private string modelName;
        private string serviceTag;
        private string lastCheck;

        public string ModelName
        {
            get => modelName;
            set
            {
                modelName = value;
                OnPropertyChanged();
            }
        }
        public string ServiceTag
        {
            get => serviceTag;
            set
            {
                serviceTag = value;
                OnPropertyChanged();
            }
        }
        public string LastCheck
        {
            get => lastCheck;
            set
            {
                lastCheck = value;
                OnPropertyChanged();
            }
        }
    }

}
