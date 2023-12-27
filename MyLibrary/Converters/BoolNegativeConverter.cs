using System;
using System.Globalization;
using System.Windows.Data;

namespace MyLibrary.Converters
{
    public class BoolNegativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is not (bool and true);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is not (bool and true);
        }
    }
}