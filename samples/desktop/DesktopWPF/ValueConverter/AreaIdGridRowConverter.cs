using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.ValueConverter
{
    public class AreaIdGridRowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value switch
        {
            0 or 1 or 2 => 0,
            3 or 4 or 5 => 1,
            6 or 7 or 8 => 3,
            _ => throw new InvalidOperationException(nameof(AreaIdGridRowConverter))
        };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
