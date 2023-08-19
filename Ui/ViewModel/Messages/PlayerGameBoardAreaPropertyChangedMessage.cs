using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

public class PlayerGameBoardAreaPropertyChangedMessage : ValueChangedMessage<PlayerGameBoardAreaViewModel>
{
    public PlayerGameBoardAreaPropertyChangedMessage(PlayerGameBoardAreaViewModel value) : base(value)
    {
    }
}