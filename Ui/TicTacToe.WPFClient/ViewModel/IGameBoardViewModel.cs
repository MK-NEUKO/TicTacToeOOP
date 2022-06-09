using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public interface IGameBoardViewModel
    {
        List<GameBoardArea> GameBoardAreaList { get; }
        IReadOnlyList<PlaceATokenCommand> PlaceATokenCommands { get; }
        void InitializeLastGameBoard();
        void InitializeNewGameBoard();
        void ShowStartAnimation(bool isNewGame);
        void LoadLastGameBoard();
    }
}
