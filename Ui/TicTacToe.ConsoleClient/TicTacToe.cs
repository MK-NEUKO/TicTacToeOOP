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
            _playerX.Name = "Hal";
            _playerO.Name = "Aimimax";
            
            int counter = 0;
            do
            {
                while (!_board.PlayerXIsWinner && !_board.PlayerOIsWinner && !_board.GameIsTie)
                {
                    _view.ShowTitle();
                    _view.DrawGameBoard();
                    _view.DrawInfoBoard();
                    /////////////////
                    //Test AI
                    /////////////////
                    _aimimax.ShowAITest();
                    ////////////////////////////
                    
                    //_view.ShowWinner();                
                    _board.PlaceAToken(_view.AskPlayerForInput(), _playerControler.GiveTheRightToken());
                    _playerControler.ChangePlayer();
                    _board.CheckForWinner();                  
                    Console.Clear();                   
                }
                GivePoints();
                _board.ResetGameBoard();
                counter++;
                if (counter == 10)
                {
                    _view.ShowTitle();
                    _view.DrawInfoBoard();
                }
                
            } while (counter < 10);
            Console.ReadKey();
        } 
        
        private void GivePoints()
        {
            if (_board.PlayerXIsWinner)
                _playerX.Points++;
            if (_board.PlayerOIsWinner)
                _playerO.Points++;
            if (_board.GameIsTie)
                _view.Tie++;
        }
    }
}
