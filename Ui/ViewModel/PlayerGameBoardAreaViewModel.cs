using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    public class PlayerGameBoardAreaViewModel : ViewModelBase
    {
        private readonly PlayerGameBoardArea _innerPlayerGameBoardArea;

        public PlayerGameBoardAreaViewModel(PlayerGameBoardArea innerPlayerGameBoardArea)
        {
            _innerPlayerGameBoardArea = innerPlayerGameBoardArea;
        }

        public string Token
        {
            get => _innerPlayerGameBoardArea.Token;
            set
            {
                _innerPlayerGameBoardArea.Token = value;
                OnPropertyChanged();
            }
        }
    }
}
