using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DellSnapUpdate.Formatters
{
    public class StringFormatConverter : IValueConverter
    {
        public string StringFormat { get; set; }

        //Convert size in bytes to MB
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!String.IsNullOrEmpty(StringFormat))
            {
                var val = double.Parse(value.ToString());
                val = val / Math.Pow(10, 6); //Converting bytes to MB
                var str = val.ToString("0.00");
                value = str;
                return String.Format(StringFormat, value);
            }


            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
