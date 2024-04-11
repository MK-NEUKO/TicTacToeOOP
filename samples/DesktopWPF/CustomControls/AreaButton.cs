using System.Windows;
using System.Windows.Controls.Primitives;

namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.CustomControls;

public class AreaButton : ToggleButton
{
    public static readonly DependencyProperty CanShowIsOccupiedProperty = DependencyProperty.Register(
        nameof(CanShowIsOccupied), typeof(bool),
        typeof(AreaButton), new PropertyMetadata(default(bool))
        );

    public bool CanShowIsOccupied
    {
        get => (bool)GetValue(CanShowIsOccupiedProperty);
        set => SetValue(CanShowIsOccupiedProperty, value);
    }
}