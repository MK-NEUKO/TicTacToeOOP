using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MichaelKoch.TicTacToe.Ui.WPFClient.ValueConverter
{
    public class AreaIdGridRowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value switch
        {
            >= 0 and < 3 => 0,
            >= 3 and < 6 => 1,
            >= 6 and < 9 => 2,
            _ => throw new ArgumentException("AreaIdGridRowConverter"),
        };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
