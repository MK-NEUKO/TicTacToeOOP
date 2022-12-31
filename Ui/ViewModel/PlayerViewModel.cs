using System.Security.AccessControl;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    public class PlayerViewModel : ObservableObject
    {
        private string? _name;

        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}
