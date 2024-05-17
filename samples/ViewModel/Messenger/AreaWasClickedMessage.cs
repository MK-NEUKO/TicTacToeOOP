using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Samples.ViewModel.Messenger;

public class AreaWasClickedMessage : ValueChangedMessage<GameBoardAreaViewModel>
{
    public AreaWasClickedMessage(GameBoardAreaViewModel value) : base(value)
    {
    }
}