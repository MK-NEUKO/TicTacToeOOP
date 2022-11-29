using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contarct;


namespace MichaelKoch.TicTacToe.Data.DataStoring
{
    public class GameBoardRepository : IGameBoardRepository
    {
        public List<GameBoardArea> LoadNewGameBoard()
        {
            return new List<GameBoardArea>
            {
                new GameBoardArea(0){RowIndex = 0, ColumnIndex = 0},
                new GameBoardArea(1){RowIndex = 0, ColumnIndex = 1},
                new GameBoardArea(2){RowIndex = 0, ColumnIndex = 2},
                new GameBoardArea(3){RowIndex = 1, ColumnIndex = 0},
                new GameBoardArea(4){RowIndex = 1, ColumnIndex = 1},
                new GameBoardArea(5){RowIndex = 1, ColumnIndex = 2},
                new GameBoardArea(6){RowIndex = 2, ColumnIndex = 0},
                new GameBoardArea(7){RowIndex = 2, ColumnIndex = 1},
                new GameBoardArea(8){RowIndex = 2, ColumnIndex = 2},
            };
        }


        public List<GameBoardArea> LoadLastGameBoard()
        {
            return new List<GameBoardArea>
            {
                new GameBoardArea(0){RowIndex = 0, IsStartNewGameAnimation = false, ColumnIndex = 0, Token = "X"},
                new GameBoardArea(1){RowIndex = 0, IsStartNewGameAnimation = false, ColumnIndex = 1, Token = "O"},
                new GameBoardArea(2){RowIndex = 0, IsStartNewGameAnimation = false, ColumnIndex = 2, Token = "X"},
                new GameBoardArea(3){RowIndex = 1, IsStartNewGameAnimation = false, ColumnIndex = 0, Token = "O"},
                new GameBoardArea(4){RowIndex = 1, IsStartNewGameAnimation = false, ColumnIndex = 1, Token = "X"},
                new GameBoardArea(5){RowIndex = 1, IsStartNewGameAnimation = false, ColumnIndex = 2, Token = "O"},
                new GameBoardArea(6){RowIndex = 2, IsStartNewGameAnimation = false, ColumnIndex = 0, Token = "X"},
                new GameBoardArea(7){RowIndex = 2, IsStartNewGameAnimation = false, ColumnIndex = 1, Token = "O"},
                new GameBoardArea(8){RowIndex = 2, IsStartNewGameAnimation = false, ColumnIndex = 2, Token = "X"},
            };
        }

        public void StoreGameBoard(List<GameBoardArea> gameBoard)
        {
            throw new NotImplementedException();
        }
    }
}
