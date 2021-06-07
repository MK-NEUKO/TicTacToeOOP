using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public class GameBoardViewModel : ViewModelBase, IGameBoardViewModel
    {
        private readonly IGameBoard _gameBoard;
        private IReadOnlyList<GameBoardArea> _gameBoardAreaList;
        private List<PlaceATokenCommand> _placeATokenCommands;

        public GameBoardViewModel(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));
            _gameBoardAreaList = _gameBoard.GameBoardAreaList;
            _placeATokenCommands = CreatePlaceATokenCommands();
        }

        public IReadOnlyList<GameBoardArea> GameBoardAreaList => _gameBoardAreaList;
        public IReadOnlyList<PlaceATokenCommand> PlaceATokenCommands => _placeATokenCommands.AsReadOnly();


        private List<PlaceATokenCommand> CreatePlaceATokenCommands()
        {
            _placeATokenCommands = new List<PlaceATokenCommand>();
            int numberOfCommands = 9;
            for (int areaID = 0; areaID < numberOfCommands; areaID++)
            {
                _placeATokenCommands.Add(new PlaceATokenCommand(areaID, PlaceAToken, CanPlaceAToken));
                _placeATokenCommands[areaID].RowIndex = _gameBoardAreaList[areaID].RowIndex;
                _placeATokenCommands[areaID].ColumnIndex = _gameBoardAreaList[areaID].ColumnIndex;
            }

            return _placeATokenCommands;
        }

        private bool CanPlaceAToken()
        {
            return true;
        }

        private void PlaceAToken(int areaID)
        {
            _gameBoard.PlaceAToken(areaID, "X");
        }

        public void InitializeNewGameBoard()
        {
            
        }

        public void InitializeLastGameBoard()
        {
            throw new NotImplementedException();
        }

        public void ShowStartAnimation()
        {
            _gameBoard.ShowStartAnimation();
        }

        
    }
}
