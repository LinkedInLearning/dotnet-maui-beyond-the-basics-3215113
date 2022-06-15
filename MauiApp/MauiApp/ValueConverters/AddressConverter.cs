using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.ValueConverters
{
    public class AddressConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            const string errorMessage = "Unable to retrieve address";
            if (values == null || values.Length != 3)
            {
                return errorMessage;
            }
            string city = values[0] as string;
            string state = values[1] as string;
            string postalCode = values[2] as string;

            if (city == null && state == null && postalCode == null)
            {
                return errorMessage;
            }

            return $"{city}, {state} {postalCode}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
