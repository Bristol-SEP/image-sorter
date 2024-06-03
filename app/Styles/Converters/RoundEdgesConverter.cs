using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace app.Styles.Converters;

/// <summary>
/// A converter which returns half the height for ellipse corners
/// </summary>
public class RoundEdgesConverter: IValueConverter
{
    /// <summary>
    /// Converter which takes the height of an object and ellipses the corners
    /// </summary>
    /// <param name="value">Height of object</param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns>Half the height to be used for corners</returns>
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