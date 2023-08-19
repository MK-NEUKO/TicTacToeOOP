using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

internal class PlayerPropertyChangedMessage : ValueChangedMessage<PlayerViewModel>
{
    public PlayerPropertyChangedMessage(PlayerViewModel value) : base(value)
    {
    }
}