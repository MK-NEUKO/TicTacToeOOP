using System;
using System.Windows;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public class GameOverDialog : WindowService
{
    private readonly IAbstractFactory<GameOverDialogControl> _contentFactory;
    
    public GameOverDialog(IAbstractFactory<DialogWindow> dialogAbstractFactory, Func<MainWindow> owner,
                          IAbstractFactory<GameOverDialogControl> contentFactory) : base(dialogAbstractFactory, owner)
    {
        _contentFactory = contentFactory;
    }

    public override FrameworkElement CreateContent(object viewModel)
    {
        var content = _contentFactory.Create();
        content.DataContext = viewModel;

        return content;
    }

}