using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    // TODO Dokumentation erstellen, (Summary, etc.).

    //public delegate void AreaIsOccupiedEventHandler();

    public class GameBoard : IGameBoard
    {
        #region Events
        //public event AreaIsOccupiedEventHandler AreaIsOccupied;
        #endregion

        #region Felder
        private readonly IList<GameBoardArea> _boardAreaList;
        private bool _isPlayerXWinner;
        private bool _isPlayerOWinner;
        private bool _isGameTie;
        private readonly int[,] _winConstellations;
        #endregion


        #region Konstruktor
        // TODO Standardkonstruktor erstellen, (Konstruktorverkettung üben).
        public GameBoard(IList<GameBoardArea> boardAreaList)
        {
            _boardAreaList = boardAreaList;
            _winConstellations = new int[8, 3]
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
        #endregion

        #region Eigenschaften
        public IList<GameBoardArea> BoardAreaList { get => _boardAreaList; }
        public bool IsPlayerXWinner { get => _isPlayerXWinner; }
        public bool IsPlayerOWinner { get => _isPlayerOWinner; }
        public bool IsGameTie { get => _isGameTie; }
        #endregion


        public void CheckGameBoardState()
        {
            CheckForWinner();
            CheckForGameIsATie();
        }

        private void CheckForWinner()
        {
        	for(int i = 0; i < _winConstellations.GetLength(0); i++)
        	{                
        		string actualContent = _boardAreaList[_winConstellations[i,0]].Area;
        		actualContent += _boardAreaList[_winConstellations[i,1]].Area;
        		actualContent += _boardAreaList[_winConstellations[i,2]].Area;
        		
        		if(actualContent == "XXX")
                {
                    _isPlayerXWinner = true;
                    _boardAreaList[_winConstellations[i, 0]].IsWinArea = true;
                    _boardAreaList[_winConstellations[i, 1]].IsWinArea = true;
                    _boardAreaList[_winConstellations[i, 2]].IsWinArea = true;
                }        			
     	
        		if(actualContent == "OOO")
                {
                    _isPlayerOWinner = true;
                    _boardAreaList[_winConstellations[i, 0]].IsWinArea = true;
                    _boardAreaList[_winConstellations[i, 1]].IsWinArea = true;
                    _boardAreaList[_winConstellations[i, 2]].IsWinArea = true;
                }        			
        	}            
        }
        
        private void CheckForGameIsATie()
        {
            if (_isPlayerXWinner || _isPlayerOWinner)
                return;

            foreach (GameBoardArea area in _boardAreaList)
            {
                if (area.Area == " ")
                    return;
            }
            _isGameTie = true;
        }

        public void PlaceAToken(int areaID, string token)
        {
            // TODO Exception auslösen wenn: übergebene Parameter nicht initialisiert sind, oder das Feld bereits besetzt ist.
            // TODO Eventuell eine Eigene Exception erstellen, aus Übungszwecken, da sonst nicht erforderlich (AreaIsOccupiedException).
            //if (_boardAreaList[areaID].AreaHasToken)
            //    AreaIsOccupied();

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
            _isPlayerXWinner = false;
            _isPlayerOWinner = false;
            _isGameTie = false;
        }
    }
}
