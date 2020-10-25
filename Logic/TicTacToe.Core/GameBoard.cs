using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.Core
{
    public class GameBoard : IGameBoard
    {
        private readonly IList<GameBoardArea> _boardAreaList;
        private bool _playerXIsWinner;
        private bool _playerOIsWinner;  


        public GameBoard(IList<GameBoardArea> boardAreaList)
        {
            _boardAreaList = boardAreaList;
        }

        public IList<GameBoardArea> BoardAreaList
        {
            get { return _boardAreaList; }
        }

        public bool PlayerXIsWinner
        {
            get { return _playerXIsWinner; }           
        }

        public bool PlayerOIsWinner
        {
            get { return _playerOIsWinner; }            
        }

        public void CheckForWinner()
        {
            for (int winConstellation = 0; winConstellation < 8; winConstellation++)
            {
                if (winConstellation == 0) CheckTheWinConstellation(0, 1, 2);
                if (winConstellation == 1) CheckTheWinConstellation(3, 4, 5);
                if (winConstellation == 2) CheckTheWinConstellation(6, 7, 8);
                if (winConstellation == 3) CheckTheWinConstellation(0, 3, 6);
                if (winConstellation == 4) CheckTheWinConstellation(1, 4, 7);
                if (winConstellation == 5) CheckTheWinConstellation(2, 5, 8);
                if (winConstellation == 6) CheckTheWinConstellation(0, 4, 8);
                if (winConstellation == 7) CheckTheWinConstellation(2, 4, 6);
            }
        }

        private void CheckTheWinConstellation(int areaIDOne, int areaIDTwo, int areaIDThree)
        {            
            string actualContent = _boardAreaList[areaIDOne].Area;
            actualContent += _boardAreaList[areaIDTwo].Area;
            actualContent += _boardAreaList[areaIDThree].Area;         

            if (actualContent == "XXX")         
                _playerXIsWinner = true;            
            else if (actualContent == "OOO")            
                _playerOIsWinner = true;                 
        }

        public void PlaceAToken(int areaID, string token)
        {
            _boardAreaList[areaID].Area = token;
        }
    }
}
