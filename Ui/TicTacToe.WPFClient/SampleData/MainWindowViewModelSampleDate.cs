using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class MainWindowViewModelSampleDate : IMainWindowViewModel
    {
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;
        private readonly IMenuViewModel _menuViewModel;

        public MainWindowViewModelSampleDate()
        {
            _gameBoardViewModel = new GameBoardViewModelSampleData();
            _gameInfoViewModel = new GameInfoViewModelSampleData();
            _menuViewModel = new MenuViewModelSampleData();
        }

        public IGameBoardViewModel GameBoardViewModel { get => _gameBoardViewModel; }
        public IGameInfoViewModel GameInfoViewModel { get => _gameInfoViewModel; }
        public IMenuViewModel MenuViewModel { get => _menuViewModel; }
    }
}
