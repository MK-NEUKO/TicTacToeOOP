using CommunityToolkit.Mvvm.Messaging.Messages;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;
    
public class GameBoardAreaWasClickedMessage : ValueChangedMessage<int>
{
    public GameBoardAreaWasClickedMessage(int value) : base(value)
    {
    }
}