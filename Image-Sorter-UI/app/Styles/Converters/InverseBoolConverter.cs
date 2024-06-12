using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace app.Styles.Converters;

/// <summary>
/// Converts a boolean true into false and vice versa
/// </summary>
public class InverseBoolConverter: IValueConverter
{
    /// <summary>
    /// Converts a boolean into its inverse
    /// </summary>
    /// <param name="value">boolean value to be converted</param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool choice) return !choice;
        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}