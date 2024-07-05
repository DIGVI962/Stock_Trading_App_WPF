using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Stock_Trading_App_WPF.Converters
{
    public class Wk52HighLowConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Assuming values[0] is Wk52High and values[1] is wk52Low
            if (values.Length == 2 && values[0] != null && values[1] != null)
            {
                string wk52High = values[0].ToString();
                string wk52Low = values[1].ToString();

                // Format the output as needed, for example:
                return $"{wk52High}/{wk52Low}";
            }

            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
