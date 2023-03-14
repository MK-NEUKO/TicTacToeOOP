using System.Windows;
using Windows.Devices.PointOfService;
using MichaelKoch.TicTacToe.Ui.ViewModel;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public class GameOverDialog : WindowService
{
    private readonly GameOverDialogControl _content = new GameOverDialogControl();

    public override FrameworkElement CreateContent()
    {
        _content.DataContext = new GameOverDialogViewModel();
        return _content;
    }
}