using System;
using System.Globalization;
using System.Windows.Data;

namespace MyLibrary.Converters
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (DateTime)value == DateTime.MinValue)
            {
                return FallbackValue;
            }

            return ((DateTime)value).ToString(Format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert が返却する DateTime のフォーマットを設定・取得します。
        /// デフォルトは "yyyy/MM/dd HH:mm" です。
        /// </summary>
        public string Format { get; set; } = "yyyy/MM/dd HH:mm";

        /// <summary>
        /// Convert に入力された DateTime が DateTime.Min と等価の場合、 value が null の場合に返却される文字列を設定・取得します。
        /// デフォルトは string.Empty です。
        /// </summary>
        public string FallbackValue { get; set; } = string.Empty;
    }
}