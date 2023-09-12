using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

public class ContinueGameMessage : ValueChangedMessage<bool>
{
    public ContinueGameMessage(bool isContinued) : base(isContinued)
    {
    }
}