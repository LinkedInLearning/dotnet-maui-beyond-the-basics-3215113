using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.ValueConverters
{
    public class OneFilledValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0) return null;

            string valueOne = values[0] as string;
            string valueTwo = values[1] as string;
            return !string.IsNullOrEmpty(valueOne) ||
                !string.IsNullOrEmpty(valueTwo);

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
