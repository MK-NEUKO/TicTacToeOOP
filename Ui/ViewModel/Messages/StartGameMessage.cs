using CommunityToolkit.Mvvm.Messaging.Messages;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

internal class StartGameMessage : ValueChangedMessage<List<IPlayerViewModel>>
{
    public StartGameMessage(List<IPlayerViewModel> playerList) : base(playerList)
    {
    }
}