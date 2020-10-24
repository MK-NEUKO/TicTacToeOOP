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
            for (int i = 0; i < 8; i++)
            {
                if (i == 0) CheckWinningConstellation(0, 1, 2);
                if (i == 1) CheckWinningConstellation(3, 4, 5);
                if (i == 2) CheckWinningConstellation(6, 7, 8);
                if (i == 3) CheckWinningConstellation(0, 3, 6);
                if (i == 4) CheckWinningConstellation(1, 4, 7);
                if (i == 5) CheckWinningConstellation(2, 5, 8);
                if (i == 6) CheckWinningConstellation(0, 4, 8);
                if (i == 7) CheckWinningConstellation(2, 4, 6);
            }
        }

        private void CheckWinningConstellation(int idOne, int idTwo, int idThree)
        {            
            string actualSignes = _boardAreaList[idOne].Signe;
            actualSignes += _boardAreaList[idTwo].Signe;
            actualSignes += _boardAreaList[idThree].Signe;         

            if (actualSignes == "XXX")         
                _playerXIsWinner = true;            
            else if (actualSignes == "OOO")            
                _playerOIsWinner = true;                 
        }

        public void PlaceASigne(int areaId, string signe)
        {
            GameBoardArea boardArea = _boardAreaList[areaId];
            boardArea.Signe = signe;
        }
    }
}
