using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    [INotifyPropertyChanged]
    public partial class PlayerGameBoardAreaViewModel
    {
        private readonly PlayerGameBoardArea _innerPlayerGameBoardArea;

        public PlayerGameBoardAreaViewModel(PlayerGameBoardArea innerPlayerGameBoardArea)
        {
            _innerPlayerGameBoardArea = innerPlayerGameBoardArea;
        }

        [ObservableProperty] private string _token;
        //{
        //    get => _innerPlayerGameBoardArea.Token;
        //    set
        //    {
        //        _innerPlayerGameBoardArea.Token = value;
        //        OnPropertyChanged();
        //    }
        //}
    }
}
