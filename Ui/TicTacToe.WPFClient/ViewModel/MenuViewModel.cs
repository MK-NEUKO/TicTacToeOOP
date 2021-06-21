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
        private IReadOnlyList<Player> _playerListOnRibbon;
        
        private bool _userChoosesStartNewGame;
        private bool _userChoosesStartLastGame;


        public MenuViewModel(IGameBoardViewModel gameBoardViewModel,
                             IGameInfoViewModel gameInfoViewModel,
                             IPlayerController playerController)
        {
            _gameBoardViewModel = gameBoardViewModel ?? throw new ArgumentNullException(nameof(gameBoardViewModel));
            _gameInfoViewModel = gameInfoViewModel ?? throw new ArgumentNullException(nameof(gameInfoViewModel));
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
            

            StartGameCommand = new RelayCommand(StartGameExecute, StartGameCanExecute);
            StartNewGameCommand = new RelayCommand(UserChoosesStartNewGameExecute, UserChoosesStartNewGameCanExecute);
            StartLastGameCommand = new RelayCommand(UserChoosesStartLastGameExecute, UserChoosesStartLastGameCanExecute);
        }

        public ICommand StartGameCommand { get; }
        public ICommand StartNewGameCommand { get; }
        public ICommand StartLastGameCommand { get; }
        public IReadOnlyList<Player> PlayerListOnRibbon => _playerListOnRibbon;
        public bool UserChoosesStartNewGame { get => _userChoosesStartNewGame; set => _userChoosesStartNewGame = value; }
        public bool UserChoosesStartLastGame { get => _userChoosesStartLastGame; set => _userChoosesStartLastGame = value; }

        private bool UserChoosesStartLastGameCanExecute()
        {
            return true;
        }

        private void UserChoosesStartLastGameExecute(object obj)
        {
            _userChoosesStartLastGame = true;
            _userChoosesStartNewGame = false;
            
        }

        private bool UserChoosesStartNewGameCanExecute()
        {
           return true;
        }

        private void UserChoosesStartNewGameExecute(object obj)
        {
            _userChoosesStartNewGame = true;
            _userChoosesStartLastGame = false;
            
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
