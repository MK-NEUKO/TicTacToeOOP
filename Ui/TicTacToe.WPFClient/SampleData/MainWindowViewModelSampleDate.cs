using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class MainWindowViewModelSampleDate
    {
        private readonly GameBoardViewModelSampleData _gameBoardViewModel;
        private readonly GameInfoViewModelSampleData _gameInfoViewModel;
        private readonly MenuViewModelSampleData _menuViewModel;

        public MainWindowViewModelSampleDate()
        {
            _gameBoardViewModel = new GameBoardViewModelSampleData();
            _gameInfoViewModel = new GameInfoViewModelSampleData();
            _menuViewModel = new MenuViewModelSampleData();
        }

        public GameBoardViewModelSampleData GameBoardViewModel { get => _gameBoardViewModel; }
        public GameInfoViewModelSampleData GameInfoViewModel { get => _gameInfoViewModel; }
        public MenuViewModelSampleData MenuViewModel { get => _menuViewModel; }
    }
}
