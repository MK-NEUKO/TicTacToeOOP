using System;
using System.Text;
using System.Windows.Input;
using System.Collections.Generic;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public class GameBoardViewModel : ViewModelBase, IGameBoardViewModel
    {
        private readonly IGameBoard _gameBoard;
        private readonly IGamePlay _gamePlay;
        private List<GameBoardArea> _gameBoardAreaList;
        private List<PlaceATokenCommand> _placeATokenCommands;
        private bool _isAnimationCompleted;
        private bool _isGameDecided;
        private bool _userWantsToContinue;

        public GameBoardViewModel(IGameBoard gameBoard, IGamePlay gamePlay)
        {
            _gameBoard = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));
            _gamePlay = gamePlay ?? throw new ArgumentNullException(nameof(gamePlay));
            _gameBoardAreaList = _gameBoard.GameBoardAreaList;
            _placeATokenCommands = CreatePlaceATokenCommands();
            ContinueCommand = new RelayCommand(ContinueExecute, ContinueCanExecute);
            StartGameAnimationCompletedCommand = new RelayCommand(StartanimationCompletedExecute);
        }

        private void StartanimationCompletedExecute(object obj) => InitializeNewGameBoard();    
        

        public IReadOnlyList<PlaceATokenCommand> PlaceATokenCommands => _placeATokenCommands.AsReadOnly();
        public ICommand ContinueCommand { get; }
        public ICommand StartGameAnimationCompletedCommand { get; }

        public List<GameBoardArea> GameBoardAreaList
        {
            get => _gameBoardAreaList;
            private set
            {
                _gameBoardAreaList = value;
                OnPropertyChanged();
            }
            
        }
        
        

        public bool IsGameDecided
        {
            get => _isGameDecided;
            set
            {
                _isGameDecided = value;
                OnPropertyChanged();
            }
        }

        public bool UserWantsToContinue
        {
            get => _userWantsToContinue;
            set
            {
                _userWantsToContinue = value;
                OnPropertyChanged();
            }
        }

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

        private bool ContinueCanExecute()
        {
            return true;
        }

        private void ContinueExecute(object obj)
        {
            _gamePlay.SetupNextGame();
            IsGameDecided = false;
            CheckHowItIsPlayed();
        }

        private bool PlaceATokenCanExecute(int areaID)
        {
            var canExecute = _isAnimationCompleted
                             && !(_gameBoard.IsPlayerXWinner || _gameBoard.IsPlayerOWinner)
                             && !_gameBoard.IsGameTie
                             && !_gameBoardAreaList[areaID].IsOccupied;
            if (canExecute)
            {
                return true;
            }
            return false;
        }

        private void PlaceATokenExecute(int areaID)
        {
            _gamePlay.MakeAMove(areaID);
            _gamePlay.MakePossibleNextMove();
            if (_gameBoard.IsPlayerXWinner || _gameBoard.IsPlayerOWinner || _gameBoard.IsGameTie)
            {
                IsGameDecided = true;
            }
        }

        public void InitializeNewGameBoard()
        {
            _isAnimationCompleted = true;
            CommandManager.InvalidateRequerySuggested();
            CheckHowItIsPlayed();
        }

        public void InitializeLastGameBoard()
        {
            
        }

        private void CheckHowItIsPlayed()
        {
            if (_gamePlay.IsAIBattle())
            {
                _gamePlay.EnterAIBattleLoop();
                IsGameDecided = true;
            }
            else
            {
                _gamePlay.MakePossibleNextMove();
            }
        }

        public void ShowStartAnimation(bool isNewGame)
        {
            _gameBoard.ShowStartAnimation(isNewGame);
        }

        public void LoadLastGameBoard()
        {
            _gameBoard.LoadLastGameBoard();
            GameBoardAreaList = _gameBoard.GameBoardAreaList;
        }
    }
}
