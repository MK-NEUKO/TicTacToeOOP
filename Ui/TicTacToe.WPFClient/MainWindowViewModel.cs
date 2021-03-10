using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NEUKO.TicTacToe.WPFClient
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;
        private readonly IGameBoard _gameBoard;
        private readonly IPlayerController _playerController;

        public MainWindowViewModel(IGameBoardViewModel gameBoardViewModel, IGameInfoViewModel gameInfoViewModel, 
                                   IGameBoard gameBoard, IPlayerController playerController)
        {
            if (gameBoardViewModel == null) throw new ArgumentNullException("GameBoardViewModel");
            if (gameInfoViewModel == null) throw new ArgumentNullException("GameInfoViewModel");

            _gameBoardViewModel = gameBoardViewModel;
            _gameInfoViewModel = gameInfoViewModel;
            _gameBoard = gameBoard;
            _playerController = playerController;
        }

        public void PlayAMove(int areaID)
        {
            _gameBoard.PlaceAToken(areaID, _playerController.GiveCurrentToken());
            _gameBoard.CheckGameBoardState();
            if (!(_gameBoard.IsPlayerXWinner || _gameBoard.IsPlayerOWinner || _gameBoard.IsGameTie))
            {
                ShowWinner();
            }
            _playerController.ChangePlayer();
        }

        private void ShowWinner()
        {
            
        }

        public IGameBoardViewModel GameBoardViewModel => _gameBoardViewModel;
        public IGameInfoViewModel GameInfoViewModel => _gameInfoViewModel;
    }
}