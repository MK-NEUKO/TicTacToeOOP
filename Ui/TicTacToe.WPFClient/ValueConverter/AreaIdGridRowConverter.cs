using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Navigation;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.ValueConverter
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
