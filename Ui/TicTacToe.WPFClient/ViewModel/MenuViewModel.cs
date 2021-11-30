using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{

    public class MenuViewModel : IMenuViewModel
    {
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;
        private readonly IPlayerController _playerController;
        private Player _playerX;
        private Player _playerO;
        
        private bool _userChoosesStartNewGame;
        private bool _userChoosesStartLastGame;


        public MenuViewModel(IGameBoardViewModel gameBoardViewModel,
                             IGameInfoViewModel gameInfoViewModel,
                             IPlayerController playerController)
        {
            _gameBoardViewModel = gameBoardViewModel ?? throw new ArgumentNullException(nameof(gameBoardViewModel));
            _gameInfoViewModel = gameInfoViewModel ?? throw new ArgumentNullException(nameof(gameInfoViewModel));
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
            _playerX = _playerController.PlayerX;
            _playerO = _playerController.PlayerO;

            StartGameCommand = new RelayCommand(StartGameExecute, StartGameCanExecute);
            StartNewGameCommand = new RelayCommand(StartNewGameExecute, StartNewGameCanExecute);
            PlayerSelectStartLastGame = new RelayCommand(PlayerSelectStartLastGameExecute, PlayerSelecttartLastGameCanExecute);
        }

        public ICommand StartGameCommand { get; }
        public ICommand StartNewGameCommand { get; }
        public ICommand PlayerSelectStartLastGame { get; }
        public bool UserChoosesStartNewGame { get => _userChoosesStartNewGame; set => _userChoosesStartNewGame = value; }
        public bool UserChoosesStartLastGame { get => _userChoosesStartLastGame; set => _userChoosesStartLastGame = value; }
        public Player PlayerX { get => _playerX; set => _playerX = value; }
        public Player PlayerO { get => _playerO; set => _playerO = value; }

        private bool StartNewGameCanExecute()
        {
            return true;
        }

        private void StartNewGameExecute(object obj)
        {
            _userChoosesStartNewGame = true;
            _userChoosesStartLastGame = false;
            
        }

        private bool PlayerSelecttartLastGameCanExecute()
        {
            return true;
        }

        private void PlayerSelectStartLastGameExecute(object obj)
        {
            _userChoosesStartLastGame = true;
            _userChoosesStartNewGame = false;
            _playerController.GetLastPlayerList();
            _gameBoardViewModel.InitializeLastGameBoard();
            _gameInfoViewModel.RenewInfoBoard();
            
        }


        private bool StartGameCanExecute()
        {
            if (_userChoosesStartNewGame || _userChoosesStartLastGame)
            {
                return true;
            }
            return false;
        }

        private void StartGameExecute(object obj)
        {
            _gameBoardViewModel.ShowStartAnimation();
        }

    }
}
