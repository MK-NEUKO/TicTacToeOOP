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
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;
        private readonly IMenuViewModel _menuViewModel;

        public MainWindowViewModel(IGameBoardViewModel gameBoardViewModel,
                                   IGameInfoViewModel gameInfoViewModel,
                                   IMenuViewModel menuViewModel)
        {
            _gameBoardViewModel = gameBoardViewModel ?? throw new ArgumentNullException(nameof(gameBoardViewModel));
            _gameInfoViewModel = gameInfoViewModel ?? throw new ArgumentNullException(nameof(gameInfoViewModel));
            _menuViewModel = menuViewModel ?? throw new ArgumentNullException(nameof(menuViewModel));
        }

        public IGameBoardViewModel GameBoardViewModel { get => _gameBoardViewModel; }
        public IGameInfoViewModel GameInfoViewModel { get => _gameInfoViewModel; }
        public IMenuViewModel MenuViewModel { get => _menuViewModel; }
    }
}