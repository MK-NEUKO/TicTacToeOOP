using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

public class PauseGameMessage : ValueChangedMessage<bool>
{
    public PauseGameMessage(bool isInGame) : base(isInGame)
    {
    }
}