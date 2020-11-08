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
        private readonly DisplayView _display;
        private readonly QueryView _query;
        private readonly ConsoleView _view;
        private bool getSettings;

        public TicTacToe(IGameBoard board, IPlayerController playerController, IPlayer playerX, IPlayer playerO, DisplayView display, QueryView query, ConsoleView view , IAI aimimax)
        {
            _board = board;
            _playerControler = playerController;
            _playerX = playerX;
            _playerO = playerO;
            _aimimax = aimimax;
            _display = display;
            _query = query;
            _view = view;
        }



        public void Play()
        {
            _playerX.Name = "Hal";
            _playerO.Name = "Aimimax";
            getSettings = true;
            
            int counter = 0;
            do
            {
                if (getSettings)
                    _view.GetSettings();
                
                if (_view.GetStandardSettings)
                    _view.AskForStandartSettings();

                if (_view.GetAdvancedSettings)
                    _view.AskForAdvancedSettings();

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
                    _board.PlaceAToken(_view.AskPlayerForInput(), _playerControler.GiveTheRightToken());
                    _playerControler.ChangePlayer();
                    _board.CheckForWinner();
                    //Console.ReadKey();
                    Console.Clear();                   
                }
                GivePoints();
                _view.ShowTitle();                
                _view.DrawGameBoard();
                _view.ShowWinner();
                _view.DrawInfoBoard();
                _playerControler.ChangePlayer();
                _board.ResetGameBoard();
                counter++;
                
                
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
