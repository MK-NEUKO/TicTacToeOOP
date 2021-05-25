using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NEUKO.TicTacToe.WPFClient
{
    public interface IGameBoardViewModel
    {
        IList<GameBoardArea> GameBoardAreaList { get; }
        IList<PlaceATokenCommand> PlaceATokenCommands { get; }
        ICommand InitializeGameCommand { get; }
    }
}
