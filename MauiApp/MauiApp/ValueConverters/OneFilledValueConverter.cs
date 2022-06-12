using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.ValueConverters
{
    public class OneFilledValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueOne = value as string;
            string valueTwo = parameter as string;

            return !string.IsNullOrEmpty(valueOne) || !string.IsNullOrEmpty(valueTwo);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
