using System;
using System.Windows;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public class GetSecureQueryDialog : WindowService<IGetSecureQueryDialogViewModel>
{
    private readonly IAbstractFactory<GetSecureDialogControl> _contentFactory;

    public GetSecureQueryDialog(IAbstractFactory<DialogWindow> dialogAbstractFactory, Func<MainWindow> owner,
                                IAbstractFactory<GetSecureDialogControl> contentFactory) : base(dialogAbstractFactory, owner)
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