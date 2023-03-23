using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

public class ContinueGameMessage : ValueChangedMessage<int>
{
    public ContinueGameMessage(int value) : base(value)
    {
    }
}