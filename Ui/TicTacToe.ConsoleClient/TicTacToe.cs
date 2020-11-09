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
        private bool getSettings;

        public TicTacToe(IGameBoard board, IPlayerController playerController, IPlayer playerX, IPlayer playerO, DisplayView display, QueryView query, IAI aimimax)
        {
            _board = board;
            _playerControler = playerController;
            _playerX = playerX;
            _playerO = playerO;
            _aimimax = aimimax;
            _display = display;
            _query = query;           
        }



        public void Play()
        {
            _playerO.Name = "Aimimax";
            getSettings = true;
            
            int counter = 0;
            do
            {
                if (getSettings)
                    _query.GetSettings();
                
                if (_query.GetDefaultSettings)
                    _query.AskForDefaultSettings();

                if (_query.GetAdvancedSettings)
                    _query.AskForAdvancedSettings();

                while (!_board.PlayerXIsWinner && !_board.PlayerOIsWinner && !_board.GameIsTie)
                {
                    _display.ResetConsole();
                    _display.ShowTitle();
                    _display.DrawGameBoard();
                    _display.DrawInfoBoard();
                    /////////////////
                    //Test AI
                    /////////////////
                    //_aimimax.ShowAITest();
                    ////////////////////////////                                                    
                    _board.PlaceAToken(_query.AskPlayerForInput(), _playerControler.GiveTheRightToken());
                    _playerControler.ChangePlayer();
                    _board.CheckForWinner();
                    //Console.ReadKey();
                    //Console.Clear();                   
                }
                _playerControler.GivePoints();
                _display.ShowTitle();                
                _display.DrawGameBoard();
                _display.ShowWinner();
                _display.DrawInfoBoard();
                _playerControler.ChangePlayer();
                _board.ResetGameBoard();
                counter++;
                
                
            } while (counter < 10);
            Console.ReadKey();
        } 
        
        
    }
}
