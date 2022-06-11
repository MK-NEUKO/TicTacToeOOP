using System.Collections.Generic;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

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
