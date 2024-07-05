using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Stock_Trading_App_WPF.Converters
{
    public class RefreshIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string sent = (string)value;

            if (sent == "S")
                return "C:\\Users\\IAmTheWizard\\source\\repos\\Stock_Trading_App_WPF\\Stock_Trading_App_WPF\\Assets\\red-rect-right.png";
            else
                return "C:\\Users\\IAmTheWizard\\source\\repos\\Stock_Trading_App_WPF\\Stock_Trading_App_WPF\\Assets\\red-rect-left.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
