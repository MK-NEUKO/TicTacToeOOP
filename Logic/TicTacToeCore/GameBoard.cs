using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contarct;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore
{
    // TODO Dokumentation erstellen, (Summary, etc.).

    //public delegate void AreaIsOccupiedEventHandler();

    public class GameBoard : IGameBoard
    {
        #region Events
        //public event AreaIsOccupiedEventHandler AreaIsOccupied;
        #endregion

        #region Felder       
        private readonly IGameBoardRepository _gameBoardRepository;
        private readonly IList<GameBoardArea> _gameBoardAreaList;
        private bool _isPlayerXWinner;
        private bool _isPlayerOWinner;
        private bool _isGameTie;
        private readonly int[,] _winConstellations;
        #endregion


        #region Konstruktor
        // TODO Standardkonstruktor erstellen, (Konstruktorverkettung üben).
        public GameBoard(IGameBoardRepository gameBoardRepository)
        {            
            _gameBoardRepository = gameBoardRepository;
            _gameBoardAreaList = _gameBoardRepository.GameBoardAreaList;
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
        public bool IsPlayerXWinner { get => _isPlayerXWinner; }
        public bool IsPlayerOWinner { get => _isPlayerOWinner; }
        public bool IsGameTie { get => _isGameTie; }
        public IList<GameBoardArea> GameBoardAreaList { get => _gameBoardAreaList; }
        #endregion


        public void CheckGameBoardState()
        {
            CheckForWinner();
            CheckForGameIsATie();
            if (_isPlayerXWinner || _isPlayerOWinner)            
                ShowWinner();
        }

        private void CheckForWinner()
        {
        	for(int i = 0; i < _winConstellations.GetLength(0); i++)
        	{                
        		string actualContent = _gameBoardRepository.GameBoardAreaList[_winConstellations[i,0]].Area;
        		actualContent += _gameBoardRepository.GameBoardAreaList[_winConstellations[i,1]].Area;
        		actualContent += _gameBoardRepository.GameBoardAreaList[_winConstellations[i,2]].Area;
        		
        		if(actualContent == "XXX")
                {
                    _isPlayerXWinner = true;
                    _gameBoardRepository.GameBoardAreaList[_winConstellations[i, 0]].IsWinArea = true;
                    _gameBoardRepository.GameBoardAreaList[_winConstellations[i, 1]].IsWinArea = true;
                    _gameBoardRepository.GameBoardAreaList[_winConstellations[i, 2]].IsWinArea = true;
                }        			
     	
        		if(actualContent == "OOO")
                {
                    _isPlayerOWinner = true;
                    _gameBoardRepository.GameBoardAreaList[_winConstellations[i, 0]].IsWinArea = true;
                    _gameBoardRepository.GameBoardAreaList[_winConstellations[i, 1]].IsWinArea = true;
                    _gameBoardRepository.GameBoardAreaList[_winConstellations[i, 2]].IsWinArea = true;
                }        			
        	}            
        }
        
        private void CheckForGameIsATie()
        {
            if (_isPlayerXWinner || _isPlayerOWinner)
                return;

            foreach (var area in _gameBoardRepository.GameBoardAreaList)
            {
                if (area.Area == " ")
                    return;
            }
            _isGameTie = true;
        }

        private void ShowWinner()
        {
            foreach (var area in _gameBoardRepository.GameBoardAreaList)
            {
                if (!area.IsWinArea)               
                    area.IsShown = false;
            }
        }

        public void PlaceAToken(int areaID, string token)
        {
            // TODO Exception auslösen wenn: übergebene Parameter nicht initialisiert sind, oder das Feld bereits besetzt ist.
            // TODO Eventuell eine Eigene Exception erstellen, aus Übungszwecken, da sonst nicht erforderlich (AreaIsOccupiedException).
            //if (_boardAreaList[areaID].AreaHasToken)
            //    AreaIsOccupied();

            _gameBoardRepository.GameBoardAreaList[areaID].Area = token;
            _gameBoardRepository.GameBoardAreaList[areaID].AreaHasToken = true;
        }

        public void ResetGameBoard()
        {
            foreach (var area in _gameBoardRepository.GameBoardAreaList)
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
