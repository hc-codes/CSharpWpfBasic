using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfValueConvterter.Converters
{
    public class TextToBrushesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var user = (string)value;
            if (user.ToLower() == "hari")
                return Brushes.Green;
            else if (user.ToLower() == "kavya")
                return Brushes.Yellow;
            else if (user.ToLower() == "ajai")
                return Brushes.Red;
            else
                return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
