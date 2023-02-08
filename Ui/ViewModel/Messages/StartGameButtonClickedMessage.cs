using CommunityToolkit.Mvvm.Messaging.Messages;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

internal class StartGameButtonClickedMessage : ValueChangedMessage<List<IPlayerViewModel>>
{
    public StartGameButtonClickedMessage(List<IPlayerViewModel> playerList) : base(playerList)
    {
    }
}