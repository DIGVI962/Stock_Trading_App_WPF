using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Stock_Trading_App_WPF.Converters
{
    public class FavouriteIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isFav = (string)value;

            if(isFav == "N")
            {
                return "C:\\Users\\IAmTheWizard\\source\\repos\\Stock_Trading_App_WPF\\Stock_Trading_App_WPF\\Assets\\heart.png";
            }
            else
            {
                return "C:\\Users\\IAmTheWizard\\source\\repos\\Stock_Trading_App_WPF\\Stock_Trading_App_WPF\\Assets\\heart-red-fill.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
