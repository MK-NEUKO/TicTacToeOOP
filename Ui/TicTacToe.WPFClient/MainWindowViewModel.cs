using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IGameBoardViewModel _gameBoardViewModel;

        public MainWindowViewModel(IGameBoardViewModel gameBoardViewModel)
        {
            _gameBoardViewModel = gameBoardViewModel;
        }

        public IGameBoardViewModel GameBoardViewModel => _gameBoardViewModel;
    }
}
