using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NEUKO.TicTacToe.Core
{
    public class GameBoard : IGameBoard
    {
        private readonly IList<GameBoardArea> _boardAreaList;
        private bool _playerXIsWinner;
        private bool _playerOIsWinner;
        private int _evaluationValue;
        private const int _maximizerValue = 10;
        private const int _minimizerValue = -10;


        public GameBoard(IList<GameBoardArea> boardAreaList)
        {
            _boardAreaList = boardAreaList;
        }

        public int Evaluation
        {
            get { return _evaluationValue; }
            set { _evaluationValue = value; }
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


        // Eine wietere Idee für die Gewinnerermittlung
        // Das Array kommt in den Konstruktor und ein Feld wird erstellt
        /*
        int[,] _winConstellation = new int[8,3]
        	{
        		{0,1,2},  +---+---+---+
        		{3,4,5},  | 0 | 1 | 2 |
        		{6,7,8},  +---+---+---+
        		{0,3,6},  | 3 | 4 | 5 |
        		{1,4,7},  +---+---+---+
        		{2,5,8},  | 6 | 7 | 8 | 
        		{0,4,8},  +---+---+---+
        		{2,4,6},  
        	};                
        }


        public void CheckForWinner()
        {
        	for(int i = 0; i < 8; i++)
        	{
        		string actualContent = "";
        		actualContent = _boardAreaList[_winConstellation[i,0]].Signe;
        		actualContent += _boardAreaList[_winConstellation[i,1]].Signe;
        		actualContent += _boardAreaList[_winConstellation[i,2]].Signe;
        		
        		if(actualContent == "XXX")
        			_playerXIsWinner = true;
     	
        		if(actualContent == "OOO")
        			_playerOIsWinner = true;
        	}
        }
        */

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
            {
                _playerXIsWinner = true;
                _evaluationValue = _maximizerValue;
            }
            else if (actualContent == "OOO")
            {
                _playerOIsWinner = true;
                _evaluationValue = _minimizerValue;
            }
                                
        }

        public void PlaceAToken(int areaID, string token)
        {
            _boardAreaList[areaID].Area = token;
            _boardAreaList[areaID].AreaHasToken = true;
        }
    }
}
