using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MichaelKoch.TicTacToe.Ui.WPFClient.ValueConverter
{
    public class AreaIdGridColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value switch
        { 
            0 or 3 or 6 => 0,
            1 or 4 or 7 => 1,
            2 or 5 or 8 => 2,
            _ => throw new ArgumentException("AreaIdGridColumnConverter")
        };
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
