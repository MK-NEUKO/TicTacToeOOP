using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerGameBoardViewModel : IPlayerGameBoardViewModel
{
    public PlayerGameBoardViewModel(IGameBoardAreaFactory gameBoardAreaFactory)
    {
        Areas = gameBoardAreaFactory.CreateAreas();
    }

    public List<IPlayerGameBoardAreaViewModel> Areas { get; }

    [RelayCommand]
    public void GameBoardStartAnimationCompleted()
    {
        Areas.ForEach(area =>
        {
            area.IsInGame = true;
            area.IsStartNewGameAnimation = false;
            area.IsStartSaveGameAnimation = false;
        });
        WeakReferenceMessenger.Default.Send(new GameBoardStartAnimationCompletedMessage(this));
    }
}