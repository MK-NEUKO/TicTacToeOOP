using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

public class OverridePlayerGameBoardAreaDataChangedMessage : ValueChangedMessage<PlayerGameBoardAreaViewModel>
{
    public OverridePlayerGameBoardAreaDataChangedMessage(PlayerGameBoardAreaViewModel currentArea) : base(currentArea)
    {
    }
}