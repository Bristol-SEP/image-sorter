using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace app.Styles.Converters;

public class RoundEdgesConverter: IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double state) return state / 2;
        return 0;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
 
}