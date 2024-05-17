using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Demo.XamlUi.Model;

namespace Demo.XamlUi.Converters;

public class GenderConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            Gender.Male => "M",
            Gender.Female => "F",
            Gender.Other => "O",
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            "M" => Gender.Male,
            "F" => Gender.Female,
            "O" => Gender.Other
        };
    }
}