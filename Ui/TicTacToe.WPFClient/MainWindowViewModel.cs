using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NEUKO.TicTacToe.WPFClient
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IMenuViewModel _menuViewModel;
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;
        private readonly IGameBoard _gameBoard;
        private readonly IPlayerController _playerController;
        private readonly IAI _aimimax;        

        public MainWindowViewModel(IMenuViewModel menuViewModel,
                                   IGameBoardViewModel gameBoardViewModel, 
                                   IGameInfoViewModel gameInfoViewModel, 
                                   IGameBoard gameBoard, 
                                   IPlayerController playerController,
                                   IAI aimimax)
        {
            if (menuViewModel == null) throw new ArgumentNullException("MenuViewModel");
            if (gameBoardViewModel == null) throw new ArgumentNullException("GameBoardViewModel");
            if (gameInfoViewModel == null) throw new ArgumentNullException("GameInfoViewModel");
            if (gameBoard == null) throw new ArgumentNullException("GameBoard");
            if (playerController == null) throw new ArgumentNullException("PlayerController");
            if (aimimax == null) throw new ArgumentNullException("Aimimax");

            _menuViewModel = menuViewModel;
            _gameBoardViewModel = gameBoardViewModel;
            _gameInfoViewModel = gameInfoViewModel;
            _gameBoard = gameBoard;
            _playerController = playerController;
            _aimimax = aimimax;            
        }       

        public void PlayAMove(int areaID)
        {
            _gameBoard.PlaceAToken(areaID, _playerController.GiveCurrentToken());
            _gameBoard.CheckGameBoardState();
            _playerController.ChangePlayer();
            _aimimax.GetAMove();
            _gameBoard.PlaceAToken(_aimimax.AreaIDForO, _playerController.GiveCurrentToken());
            _gameBoard.CheckGameBoardState();
            _playerController.ChangePlayer();
            //_playerController.SetWinner();
        }


        public IGameBoardViewModel GameBoardViewModel => _gameBoardViewModel;
        public IGameInfoViewModel GameInfoViewModel => _gameInfoViewModel;
        public IMenuViewModel MenuViewModel => _menuViewModel;
    }
}