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

        public TicTacToe(IGameBoard board, IPlayerController playerController, IPlayer playerX, IPlayer playerO, DisplayView display, QueryView query, IAI aimimax)
        {
            _board = board;
            _playerControler = playerController;
            _playerX = playerX;
            _playerO = playerO;            
            _display = display;
            _query = query;
            _aimimax = aimimax;
        }



        public void Play()
        {                                
            do
            {
                if (_query.GetMainSettings)
                    _query.GetSettings();
                
                if (_query.GetDefaultSettings)
                    _query.AskForDefaultSettings();

                if (_query.GetAdvancedSettings)
                    _query.AskForAdvancedSettings();

                while (!_board.PlayerXIsWinner && !_board.PlayerOIsWinner && !_board.GameIsTie)
                {
                    _display.ResetConsole();
                    _display.ShowTitle();
                    _display.ShowGameBoard();
                    _display.ShowInfoBoard();                                                                     
                    _board.PlaceAToken(_query.AskPlayerForInput(), _playerControler.GiveTheRightToken());
                    _playerControler.ChangePlayer();
                    _board.CheckGameBoardState();                                      
                }
                _display.ResetConsole();
                _playerControler.GivePoints();
                _display.ShowTitle();                
                _display.ShowGameBoard();
                _display.ShowWinner();
                _display.ShowInfoBoard();
                //_playerControler.ChangePlayer();
                _board.ResetGameBoard();
                _query.AskForContinue();                
                
            } while (_query.PlayerWillContinue);           
        }        
    }
}
