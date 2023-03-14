using System.Windows;
using Windows.Devices.PointOfService;
using MichaelKoch.TicTacToe.Ui.ViewModel;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public class GameOverDialog : WindowService
{
    private readonly IAbstractFactory<GameOverDialogControl> _conteFactory;

    public GameOverDialog(IAbstractFactory<DialogWindow> dialogAbstractFactory,
                          IAbstractFactory<GameOverDialogControl> conteFactory) : base(dialogAbstractFactory)
    {
        _conteFactory = conteFactory;
    }

    public override FrameworkElement CreateContent(object viewModel)
    {
        var content = _conteFactory.Create();
        content.DataContext = viewModel;

        return content;
    }

}