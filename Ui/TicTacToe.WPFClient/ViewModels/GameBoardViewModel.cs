using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NEUKO.TicTacToe.WPFClient
{
    public class GameBoardViewModel : ViewModelBase, IGameBoardViewModel
    {
        private readonly IGameBoard _gameBoard;
        private readonly IList<GameBoardArea> _gameBoardAreaList;
        private readonly IList<PlaceATokenCommand> _placeATokenCommands;

        public ICommand InitializeGameCommand { get; }
        

        public GameBoardViewModel(IGameBoard gameBoard, IList<PlaceATokenCommand> placeATokenCommands)
        {
            if (placeATokenCommands == null) throw new ArgumentNullException("PlaceATokenCommands");

            _gameBoard = gameBoard;
            _gameBoardAreaList = gameBoard.GameBoardAreaList;
            _placeATokenCommands = placeATokenCommands;

            InitializeGameCommand = new RelayCommand(InitializeGame, CanInitializeGame);                      
        }

        private bool CanInitializeGame()
        {
            return true;
        }

        private void InitializeGame(object obj)
        {
            foreach (var area in _gameBoardAreaList)
            {
                area.Area = "X";
            }
        }

        public IList<GameBoardArea> GameBoardAreaList => _gameBoardAreaList;

        public IList<PlaceATokenCommand> PlaceATokenCommands => _placeATokenCommands;
    }
}
