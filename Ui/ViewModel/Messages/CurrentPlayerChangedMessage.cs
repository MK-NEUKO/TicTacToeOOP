using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

internal class CurrentPlayerChangedMessage : ValueChangedMessage<PlayerViewModel>
{
    public CurrentPlayerChangedMessage(PlayerViewModel value) : base(value)
    {
    }
}