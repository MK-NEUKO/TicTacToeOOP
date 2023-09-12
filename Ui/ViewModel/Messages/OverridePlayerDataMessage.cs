using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

internal class OverridePlayerDataMessage : ValueChangedMessage<PlayerViewModel>
{
    public OverridePlayerDataMessage(PlayerViewModel currentPlayer) : base(currentPlayer)
    {
    }
}