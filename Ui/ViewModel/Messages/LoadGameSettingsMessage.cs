using CommunityToolkit.Mvvm.Messaging.Messages;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

public class LoadGameSettingsMessage : ValueChangedMessage<SaveGame>
{
    public LoadGameSettingsMessage(SaveGame gameSettings) : base(gameSettings)
    {
    }
}