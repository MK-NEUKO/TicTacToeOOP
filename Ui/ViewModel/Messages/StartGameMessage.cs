using CommunityToolkit.Mvvm.Messaging.Messages;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

internal class StartGameMessage : ValueChangedMessage<GameMenuViewModel>
{
    public StartGameMessage(GameMenuViewModel gameMenuViewModel) : base(gameMenuViewModel)
    {
    }
}