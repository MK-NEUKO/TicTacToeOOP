using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.Core
{
    public class GameBoard : IGameBoard
    {
        private readonly IList<GameBoardArea> _boardAreaList;

        public GameBoard(IList<GameBoardArea> boardAreaList)
        {
            _boardAreaList = boardAreaList;

        }

        public IList<GameBoardArea> BoardAreaList
        {
            get { return _boardAreaList; }
        }

        public string CheckForWinner()
        {
            throw new NotImplementedException();
        }

        public void PlaceASigne(int areaId)
        {
            throw new NotImplementedException();
        }
    }
}
