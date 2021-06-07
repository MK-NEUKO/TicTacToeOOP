using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contarct;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore
{
    public class GameBoard : IGameBoard
    {
        private readonly IGameBoardRepository _gameBoardRepository;
        private List<GameBoardArea> _gameBoardAreaList;
        private bool _isPlayerXWinner;
        private bool _isPlayerOWinner;
        private bool _isGameTie;
        private readonly int[,] _winConstellations;
        


       
        public GameBoard(IGameBoardRepository gameBoardRepository)
        {
            _gameBoardRepository = gameBoardRepository ?? throw new ArgumentNullException(nameof(gameBoardRepository));
            _gameBoardAreaList = _gameBoardRepository.LoadNewGameBoard();
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

        public bool IsPlayerXWinner => _isPlayerXWinner;
        public bool IsPlayerOWinner => _isPlayerOWinner;
        public bool IsGameTie => _isGameTie;
        public IReadOnlyList<GameBoardArea> GameBoardAreaList => _gameBoardAreaList.AsReadOnly();


        public void ShowStartAnimation() => _gameBoardAreaList.ForEach(area => area.IsAnimated = true);

        public void CheckGameBoardState()
        {
            CheckForWinner();
            CheckForGameIsATie();
            if (_isPlayerXWinner || _isPlayerOWinner)            
                ShowWinner();
        }

        private void CheckForWinner()
        {
            var numberOfWinnconstellations = _winConstellations.GetLength(0);
            for (int i = 0; i < numberOfWinnconstellations; i++)
            {
                string actualContent = _gameBoardAreaList[_winConstellations[i, 0]].Area;
                actualContent += _gameBoardAreaList[_winConstellations[i, 1]].Area;
                actualContent += _gameBoardAreaList[_winConstellations[i, 2]].Area;
        		
        		if(actualContent == "XXX")
                {
                    _isPlayerXWinner = true;
                    _gameBoardAreaList[_winConstellations[i, 0]].IsWinArea = true;
                    _gameBoardAreaList[_winConstellations[i, 1]].IsWinArea = true;
                    _gameBoardAreaList[_winConstellations[i, 2]].IsWinArea = true;
                }
     	
        		if(actualContent == "OOO")
                {
                    _isPlayerOWinner = true;
                    _gameBoardAreaList[_winConstellations[i, 0]].IsWinArea = true;
                    _gameBoardAreaList[_winConstellations[i, 1]].IsWinArea = true;
                    _gameBoardAreaList[_winConstellations[i, 2]].IsWinArea = true;
                }
        	}
        }

        private void CheckForGameIsATie()
        {
            if (_isPlayerXWinner || _isPlayerOWinner)
            {
                return;
            }

            foreach (var area in _gameBoardAreaList)
            {
                if (area.Area == " ")
                {
                    return;
                }
            }
            _isGameTie = true;
        }

        private void ShowWinner()
        {
            foreach (var area in _gameBoardAreaList)
            {
                if (!area.IsWinArea)
                {
                    area.IsAnimated = false;
                }
            }
        }

        public void PlaceAToken(int areaID, string token)
        {
            // TODO Exception auslösen wenn: übergebene Parameter nicht initialisiert sind, oder das Feld bereits besetzt ist.
            // TODO Eventuell eine Eigene Exception erstellen, aus Übungszwecken, da sonst nicht erforderlich (AreaIsOccupiedException).
            //if (_boardAreaList[areaID].AreaHasToken)
            //    AreaIsOccupied();

            _gameBoardAreaList[areaID].Area = token;
            _gameBoardAreaList[areaID].AreaHasToken = true;
        }

        public void ResetGameBoard()
        {
            foreach (var area in _gameBoardAreaList)
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
