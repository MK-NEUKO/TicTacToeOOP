using NEUKO.TicTacToe.Core;
using System;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class TicTacToe
    {
        private readonly IGameBoard _board;
        private readonly IPlayerController _playerControler;
        private readonly IPlayer _playerX;
        private readonly IPlayer _playerO;
        private readonly IAI _aimimax;
        private readonly ConsoleView _view;

        public TicTacToe(IGameBoard board, IPlayerController playerController, IPlayer playerX, IPlayer playerO, ConsoleView view , IAI aimimax)
        {
            _board = board;
            _playerControler = playerController;
            _playerX = playerX;
            _playerO = playerO;
            _aimimax = aimimax;
            _view = view;
        }



        public void Play()
        {
            _playerX.Name = "1234567890";
            _playerO.Name = "12345";
            _playerO.Points = "12";
            _playerO.Points = "7";
            int counter = 0;
            while (!_board.PlayerXIsWinner || !_board.PlayerOIsWinner)
            {
                _board.CheckForWinner();
                _view.ShowTitle();
                _view.DrawGameBoard();
                /////////////////
                //Test AI
                /////////////////
                _aimimax.ShowAITest();
                ////////////////////////////
                _view.DrawInfoBoard();              
                _view.ShowWinner();                
                _board.PlaceAToken(_view.AskPlayerForInput(), _playerControler.GiveTheRightToken());                
                _playerControler.ChangePlayer();
                Console.Clear();
                counter++;
            }
        }    
    }
}
