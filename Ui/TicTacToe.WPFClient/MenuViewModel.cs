using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NEUKO.TicTacToe.WPFClient
{

    public class MenuViewModel : IMenuViewModel
    {
        private readonly IGameBoard _gameBoard;

        public ICommand StartGameCommand { get; }
        public MenuViewModel(IGameBoard gameBoard)
        {
            if (gameBoard == null) throw new ArgumentNullException("GameBoard");

            _gameBoard = gameBoard;

            StartGameCommand = new RelayCommand(StartGame, CanStartGame);
        }

        private bool CanStartGame()
        {
            return true;
        }

        private void StartGame(object obj)
        {
            foreach (var area in _gameBoard.BoardAreaList)
            {
                if (area.IsShown)
                    area.IsShown = false;
                else
                    area.IsShown = true;
            }
        }

    }
}
