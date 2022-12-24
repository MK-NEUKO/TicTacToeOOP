using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    [INotifyPropertyChanged]
    public partial class PlayerGameBoardAreaViewModel : IPlayerGameBoardAreaViewModel
    {
        public PlayerGameBoardAreaViewModel(int id)
        {
            _id = id;
            _token = " ";
        }

        [ObservableProperty] private int _id;
        [ObservableProperty] private string _token;
        [ObservableProperty] private bool _isWinArea;
        [ObservableProperty] private bool _isStartNewGameAnimation;
        [ObservableProperty] private bool _isStartSaveGameAnimation;

        [RelayCommand]
        private void AreaWasClicked()
        {
            throw new NotImplementedException();
        }
    }
}
