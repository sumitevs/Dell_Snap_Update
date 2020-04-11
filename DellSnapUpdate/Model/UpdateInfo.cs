using DellSnapUpdate.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellSnapUpdate.Model
{
    public class UpdateInfo : Observable
    {
        private string name;
        private string size;
        private string releaseDate;
        private string criticality;
        private bool isChecked;

        //public string Swpart_Id_Rev { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Size
        {
            get => size;
            set
            {
                size = value;
                OnPropertyChanged();
            }
        }
        public string ReleaseDate
        {
            get => releaseDate;
            set
            {
                releaseDate = value;
                OnPropertyChanged();
            }
        }
        public string Criticality
        {
            get => criticality;
            set
            {
                criticality = value;
                OnPropertyChanged();
            }
        }

        public bool IsChecked
        {
            get => isChecked; set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        }
    }
}
