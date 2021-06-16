using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public class GameBoardViewModel : IGameBoardViewModel
    {
        private readonly IGameBoard _gameBoard;
        private readonly IGamePlay _gamePlay;
        private IReadOnlyList<GameBoardArea> _gameBoardAreaList;
        private List<PlaceATokenCommand> _placeATokenCommands;
        private bool _isAnimationCompleted;

        public GameBoardViewModel(IGameBoard gameBoard, IGamePlay gamePlay)
        {
            _gameBoard = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));
            _gamePlay = gamePlay ?? throw new ArgumentNullException(nameof(gamePlay));
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
                _placeATokenCommands.Add(new PlaceATokenCommand(areaID, PlaceATokenExecute, PlaceATokenCanExecute));
                _placeATokenCommands[areaID].RowIndex = _gameBoardAreaList[areaID].RowIndex;
                _placeATokenCommands[areaID].ColumnIndex = _gameBoardAreaList[areaID].ColumnIndex;
            }

            return _placeATokenCommands;
        }

        private bool PlaceATokenCanExecute()
        {
            if (_isAnimationCompleted)
            {
                return true;
            }
            return false;
        }

        private void PlaceATokenExecute(int areaID)
        {
            _gamePlay.TakeAMove(areaID);
        }

        public void InitializeNewGameBoard()
        {
            _isAnimationCompleted = true;
            CommandManager.InvalidateRequerySuggested();
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
