using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace HierarchicalTreeDataGridSample.Converters;

/// <summary>
/// Converts a conservation status to a background color.
/// </summary>
public class ConservationStatusColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string status || string.IsNullOrEmpty(status))
            return new SolidColorBrush(Colors.Gray);

        return status.ToLower() switch
        {
            string s when s.Contains("extinct") => new SolidColorBrush(Colors.Black),
            string s when s.Contains("critically endangered") => new SolidColorBrush(Color.Parse("#D62828")), // Red
            string s when s.Contains("endangered") => new SolidColorBrush(Color.Parse("#F77F00")), // Orange
            string s when s.Contains("vulnerable") => new SolidColorBrush(Color.Parse("#FCBF49")), // Yellow
            string s when s.Contains("near threatened") => new SolidColorBrush(Color.Parse("#90BE6D")), // Light Green
            string s when s.Contains("least concern") => new SolidColorBrush(Color.Parse("#43AA8B")), // Green
            _ => new SolidColorBrush(Colors.Gray)
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
