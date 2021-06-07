using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IMenuViewModel _menuViewModel;
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;
        private readonly IGameBoard _gameBoard;
        private readonly IPlayerController _playerController;
        private readonly IAI _aimimax;

        public ICommand InitializeGameCommand { get; }

        public MainWindowViewModel(IMenuViewModel menuViewModel,
                                   IGameBoardViewModel gameBoardViewModel, 
                                   IGameInfoViewModel gameInfoViewModel, 
                                   IGameBoard gameBoard, 
                                   IPlayerController playerController,
                                   IAI aimimax)
        {
            _menuViewModel = menuViewModel ?? throw new ArgumentNullException(nameof(menuViewModel));
            _gameBoardViewModel = gameBoardViewModel ?? throw new ArgumentNullException(nameof(gameBoardViewModel));
            _gameInfoViewModel = gameInfoViewModel ?? throw new ArgumentNullException(nameof(gameInfoViewModel));
            _gameBoard = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));
            _playerController = playerController;
            _aimimax = aimimax;

            InitializeGameCommand = new RelayCommand(InitializeGameExecute, InitializeGameCanExecute);
        }

        private bool InitializeGameCanExecute()
        {
            return true;
        }

        private void InitializeGameExecute(object obj)
        {
            if (_menuViewModel.UserChoosesStartNewGame)
            {
                _gameBoardViewModel.InitializeNewGameBoard();
            }
        }

        public IGameBoardViewModel GameBoardViewModel => _gameBoardViewModel;
        public IGameInfoViewModel GameInfoViewModel => _gameInfoViewModel;
        public IMenuViewModel MenuViewModel => _menuViewModel;
    }
}