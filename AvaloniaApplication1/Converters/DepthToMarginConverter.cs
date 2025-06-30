using Avalonia.Data.Converters;
using System;
using System.Globalization;
using Avalonia;

namespace AvaloniaApplication1.Converters
{
    public class DepthToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int depth)
            {
                return new Thickness(depth * 12, 0, 0, 0);
            }
            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}