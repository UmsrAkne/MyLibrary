using System;
using System.Globalization;
using System.Windows.Data;

namespace MyLibrary.Converters
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || ((TimeSpan)value) == TimeSpan.Zero)
            {
                return FallbackValue;
            }

            return ((TimeSpan)value).ToString(Format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert が返却する TimeSpan のフォーマットを設定・取得します。
        /// デフォルトは @"hh\:mm\:ss" です。
        /// </summary>
        public string Format { get; set; } = @"hh\:mm\:ss";

        /// <summary>
        /// Convert に入力された TimeSpan が TimeSpan.Zero と等価の場合、 value が null の場合に返却される文字列を設定・取得します。
        /// デフォルトは string.Empty です。
        /// </summary>
        public string FallbackValue { get; set; } = string.Empty;
    }
}