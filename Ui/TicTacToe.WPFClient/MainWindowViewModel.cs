using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;

        public MainWindowViewModel(IGameBoardViewModel gameBoardViewModel, IGameInfoViewModel gameInfoViewModel)
        {
            if (gameBoardViewModel == null) throw new ArgumentNullException("GameBoardViewModel");
            if (gameInfoViewModel == null) throw new ArgumentNullException("GameInfoViewModel");

            _gameBoardViewModel = gameBoardViewModel;
            _gameInfoViewModel = gameInfoViewModel;
        }

        public IGameBoardViewModel GameBoardViewModel => _gameBoardViewModel;
        public IGameInfoViewModel GameInfoViewModel => _gameInfoViewModel;
    }
}
