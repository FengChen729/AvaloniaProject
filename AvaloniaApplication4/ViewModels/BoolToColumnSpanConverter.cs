using System;
using System.ComponentModel;
using System.Globalization;
using Avalonia.Data.Converters;

namespace AvaloniaApplication4.ViewModels;

public class BoolToColumnSpanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool isHorizontal && isHorizontal ? 2 : 1;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null; // 不支持双向绑定 
    }
}
