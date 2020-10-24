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
        private readonly ConsoleView _view;

        public TicTacToe(IGameBoard board, IPlayerController playerController, IPlayer playerX, IPlayer playerO, ConsoleView view)
        {
            _board = board;
            _playerControler = playerController;
            _playerX = playerX;
            _playerO = playerO;
            _view = view;
        }

        public void Play()
        {
            _playerX.Name = "Horst";
            _playerO.Name = "Jochen";
            int counter = 0;
            while (counter < 10)
            {
                _view.ShowTitle();
                _view.DrawGameBoard();
                _view.DrawInfoBoard();
                _board.CheckForWinner();
                if (_board.PlayerXIsWinner)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("{0} hat gewonnen!!!", _playerX.Name);
                    Console.ResetColor();
                }
                else if (_board.PlayerOIsWinner)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("{0} hat gewonnen!!!", _playerO.Name);
                    Console.ResetColor();
                }
                if (_playerX.InAction)
                    _board.PlaceASigne(_view.AskPlayerForInput("PlayerX", _playerX.Name), "X");
                else
                    _board.PlaceASigne(_view.AskPlayerForInput("PlayerO", _playerO.Name), "O");
                _playerControler.ChangePlayer();
                Console.Clear();
                counter++;
            }
        }    
    }
}
