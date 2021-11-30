using System;
using System.Text;
using System.Windows.Input;
using System.Collections.Generic;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IMenuViewModel _menuViewModel;
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;
        private readonly IGamePlay _gamePlay;
        private readonly IPlayerController _playerController;

        public ICommand InitializeGameCommand { get; }

        public MainWindowViewModel(IMenuViewModel menuViewModel,
                                   IGameBoardViewModel gameBoardViewModel,
                                   IGameInfoViewModel gameInfoViewModel,
                                   IGamePlay gamePlay,
                                   IPlayerController playerController)
        {
            _menuViewModel = menuViewModel ?? throw new ArgumentNullException(nameof(menuViewModel));
            _gameBoardViewModel = gameBoardViewModel ?? throw new ArgumentNullException(nameof(gameBoardViewModel));
            _gameInfoViewModel = gameInfoViewModel ?? throw new ArgumentNullException(nameof(gameInfoViewModel));
            _gamePlay = gamePlay ?? throw new ArgumentNullException(nameof(gamePlay));
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
        }

        public IGameBoardViewModel GameBoardViewModel => _gameBoardViewModel;
        public IGameInfoViewModel GameInfoViewModel => _gameInfoViewModel;
        public IMenuViewModel MenuViewModel => _menuViewModel;
    }
}