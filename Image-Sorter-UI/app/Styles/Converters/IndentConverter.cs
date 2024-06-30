using System;
using System.Globalization;
using app.Model;
using Avalonia;
using Avalonia.Data.Converters;

namespace app.Styles.Converters;

/// <summary>
/// A converter which indents <see cref="DirectoryItem"/> depending on their <see cref="DirectoryItem.Level"/>
/// </summary>
public class IndentConverter: IValueConverter
{
    /// <summary>
    /// Multiplies the <see cref="DirectoryItem.Level"/> by 20 and converts to a padding
    /// </summary>
    /// <param name="value">The priority level</param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns>A padding</returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is int priorityLevel) return new Thickness(priorityLevel * 20, 0, 0, 0);
        return new Thickness(100,0,0,0);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}