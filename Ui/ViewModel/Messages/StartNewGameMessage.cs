using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

public class StartNewGameMessage : ValueChangedMessage<bool>
{
    public StartNewGameMessage(bool isStartNewGame) : base(isStartNewGame)
    {
    }
}