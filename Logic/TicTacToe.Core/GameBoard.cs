using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public struct WinConstellation
    {

    }

    public class GameBoard : IGameBoard
    {
        private readonly IList<GameBoardArea> _boardAreaList;
        private bool _playerXIsWinner;
        private bool _playerOIsWinner;
        private bool _gameIsTie;
        private readonly int[,] _winConstellation;        


        public GameBoard(IList<GameBoardArea> boardAreaList)
        {
            _boardAreaList = boardAreaList;
            _winConstellation = new int[8, 3]
            {
                {0,1,2}, /*  +---+---+---+  */
                {3,4,5}, /*  | 0 | 1 | 2 |  */
                {6,7,8}, /*  +---+---+---+  */
                {0,3,6}, /*  | 3 | 4 | 5 |  */
                {1,4,7}, /*  +---+---+---+  */
                {2,5,8}, /*  | 6 | 7 | 8 |  */
                {0,4,8}, /*  +---+---+---+  */
                {2,4,6},
            };
        }

        public IList<GameBoardArea> BoardAreaList { get => _boardAreaList; }

        public bool PlayerXIsWinner { get => _playerXIsWinner; }

        public bool PlayerOIsWinner { get => _playerOIsWinner; }

        public bool GameIsTie { get => _gameIsTie; }

        public void CheckGameBoardState()
        {
            CheckForWinner();
            IsGameTie();
        }

        private void CheckForWinner()
        {
        	for(int i = 0; i < _winConstellation.GetLength(0); i++)
        	{                
        		string actualContent = _boardAreaList[_winConstellation[i,0]].Area;
        		actualContent += _boardAreaList[_winConstellation[i,1]].Area;
        		actualContent += _boardAreaList[_winConstellation[i,2]].Area;
        		
        		if(actualContent == "XXX")
                {
                    _playerXIsWinner = true;
                    _boardAreaList[_winConstellation[i, 0]].IsWinArea = true;
                    _boardAreaList[_winConstellation[i, 1]].IsWinArea = true;
                    _boardAreaList[_winConstellation[i, 2]].IsWinArea = true;
                }        			
     	
        		if(actualContent == "OOO")
                {
                    _playerOIsWinner = true;
                    _boardAreaList[_winConstellation[i, 0]].IsWinArea = true;
                    _boardAreaList[_winConstellation[i, 1]].IsWinArea = true;
                    _boardAreaList[_winConstellation[i, 2]].IsWinArea = true;
                }        			
        	}            
        }
        
        private void IsGameTie()
        {
            if (_playerXIsWinner || _playerOIsWinner)
                return;

            foreach (GameBoardArea area in _boardAreaList)
            {
                if (area.Area == " ")
                    return;
            }
            _gameIsTie = true;
        }

        public void PlaceAToken(int areaID, string token)
        {
            _boardAreaList[areaID].Area = token;
            _boardAreaList[areaID].AreaHasToken = true;
        }

        public void ResetGameBoard()
        {
            foreach (GameBoardArea area in _boardAreaList)
            {
                area.Area = " ";
                area.AreaHasToken = false;
                area.IsWinArea = false;
            }
            _playerXIsWinner = false;
            _playerOIsWinner = false;
            _gameIsTie = false;
        }
    }
}
