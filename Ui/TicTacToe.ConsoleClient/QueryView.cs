using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class QueryView
    {
        private readonly IList<GameBoardArea> _boardAreaList;
        private readonly IGameBoard _board;
        private readonly IPlayer _playerX;
        private readonly IPlayer _playerO;
        private readonly IPlayerController _playerController;
        private readonly IAI _aimimax;
        private readonly QueryValidation _validation;
        private readonly QueryDisplay _queryDisplay;
        private readonly QueryConverter _inputConverter;
        private bool _getMainSettings;
        private bool _getDefaultSettings;
        private bool _getAdvancedSettings;
        private bool _playerWillContinue;

        public QueryView(IList<GameBoardArea> boardAreaList, IGameBoard board, IPlayer playerX, IPlayer playerO, IPlayerController playerController, IAI aimimax, QueryValidation validation, QueryDisplay queryDisplay, QueryConverter inputConverter)
        {
            _boardAreaList = boardAreaList;
            _board = board;
            _playerX = playerX;
            _playerO = playerO;
            _playerController = playerController;
            _aimimax = aimimax;
            _validation = validation;
            _queryDisplay = queryDisplay;
            _inputConverter = inputConverter;
            _getMainSettings = true;
        }

        public bool GetDefaultSettings { get => _getDefaultSettings; set => _getDefaultSettings = value; }
        public bool GetAdvancedSettings { get => _getAdvancedSettings; set => _getAdvancedSettings = value; }
        public bool GetMainSettings { get => _getMainSettings; set => _getMainSettings = value; }
        public bool PlayerWillContinue { get => _playerWillContinue; set => _playerWillContinue = value; }

        public void GetSettings()
        {
            bool repeatQuery;

            _queryDisplay.ShowMenuGetSettings();
            do
            {
                
                string userInput = _queryDisplay.GetInputQuery();
                if (userInput == "1")
                {
                    _getDefaultSettings = true;
                    _getAdvancedSettings = false;
                    repeatQuery = false;
                }
                else if (userInput == "2")
                {
                    _getAdvancedSettings = true;
                    _getDefaultSettings = false;
                    repeatQuery = false;
                }
                else
                {
                    _queryDisplay.ShowWhenWrongInput(" Falsche Eingabe, bitte wähle '1' oder '2'! ");
                    repeatQuery = true;
                }
            } while (repeatQuery);

            Console.Clear();
        }

        public void AskForDefaultSettings()
        {
            _queryDisplay.ShowMenuAskForDefaultSettings();

            AskPlayerForName(_playerX);

            _playerX.InAction = true;
            _playerX.IsHuman = true;
            _playerX.MaximumDepth = 0;
            _playerO.Name = "Aimimax";
            _playerO.IsHuman = false;

            AskPlayerForDiffecultyLevel(_playerO);
        }

        private void AskPlayerForName(IPlayer askedPlayer)
        {
            bool repeatQuery;

            do
            {                
                string userInput = _queryDisplay.GetInputQuery(askedPlayer, "Bitte wähle einen Namen, Gültig sind a-Z, 0-9 und Leerzeichen");
                if (_validation.ValidatePlayerName(userInput))
                {
                    askedPlayer.Name = userInput;
                    repeatQuery = false;
                }
                else
                {
                    _queryDisplay.ShowWhenWrongInput(" Falsche Eingabe, erlaubt sind 14 Zeichen (A-Z, a-z, 0-9, Leerzeichen). ");
                    repeatQuery = true;
                }
            } while (repeatQuery);
            Console.WriteLine();
        }

        private void AskPlayerForDiffecultyLevel(IPlayer askedPlayer)
        {
            bool repeatQuery;
            _queryDisplay.ShowMenuAskPlayerForDiffecultyLevel();            

            do
            {                
                string userInput = _queryDisplay.GetInputQuery(askedPlayer);
                if (userInput == "1")
                {
                    askedPlayer.MaximumDepth = 1;
                    repeatQuery = false;
                }
                else if (userInput == "2")
                {
                    askedPlayer.MaximumDepth = 2;
                    repeatQuery = false;
                }
                else if (userInput == "3")
                {
                    askedPlayer.MaximumDepth = 3;
                    repeatQuery = false;
                }
                else if (userInput == "4")
                {
                    askedPlayer.MaximumDepth = 5;
                    repeatQuery = false;
                }
                else
                {
                    _queryDisplay.ShowWhenWrongInput(" Falsche Eingabe, wähle die Menupunkte mit den Zahlen (1-4). ");
                    repeatQuery = true;
                }  
                
            } while (repeatQuery);
        }

        public void AskForAdvancedSettings()
        {
            _queryDisplay.ShowMenuAskForAdvancedSettings();

            AskPlayerForHumanOrAI(_playerX);
            if (_playerX.IsHuman)
            {
                _playerX.MaximumDepth = 0;
                AskPlayerForName(_playerX);
            }
            else
            {
                _playerX.Name = "Aimimax";
                AskPlayerForDiffecultyLevel(_playerX);
            }


            AskPlayerForHumanOrAI(_playerO);
            if (_playerO.IsHuman)
            {
                _playerX.MaximumDepth = 0;
                AskPlayerForName(_playerO);
            }
            else
            {
                _playerO.Name = "HAL";
                AskPlayerForDiffecultyLevel(_playerO);
            }
        }               

        private void AskPlayerForHumanOrAI(IPlayer askedPlayer)
        {
            bool repeatQuery;
            _queryDisplay.ShowMenuAskPlayerForHumanOrAi(askedPlayer);
            
            do
            {                
                string userInput = _queryDisplay.GetInputQuery(askedPlayer);
                if (userInput == "1")
                {
                    askedPlayer.IsHuman = true;
                    repeatQuery = false;
                }
                else if (userInput == "2")
                {
                    askedPlayer.IsHuman = false;
                    repeatQuery = false;
                }
                else
                {
                    _queryDisplay.ShowWhenWrongInput(" Falsche Eingabe, bitte wähle '1' oder '2'! ");
                    repeatQuery = true;
                }
            } while (repeatQuery);
        }

        public void AskForContinue()
        {
            bool repeatQuery;
            _queryDisplay.ShowMenuAskForContinue();
            
            do
            {                
                string userInput = _queryDisplay.GetInputQuery();
                if (userInput == "1")
                {
                    _getMainSettings = false;
                    _getDefaultSettings = false;
                    _getAdvancedSettings = false;
                    _playerWillContinue = true;
                    repeatQuery = false;
                }
                else if (userInput == "2")
                {
                    _getMainSettings = true;
                    _playerWillContinue = true;
                    _playerController.ResetPlayers();
                    repeatQuery = false;
                }
                else
                {
                    _queryDisplay.ShowWhenWrongInput(" Falsche Eingabe, bitte wähle '1' oder '2'! ");
                    repeatQuery = true;
                }
            } while (repeatQuery);

            Console.Clear();
        }

        public int AskPlayerForInput()
        {
            string userInput;
            int areaID;
            bool wrongInput;

            do
            {
                if ((_playerX.InAction && _playerX.IsHuman) || (_playerO.InAction && _playerO.IsHuman))
                {
                    userInput = GetAreaIDFromHuman();
                    areaID = _inputConverter.ConvertUserInput(userInput);
                }
                else                
                    areaID = GetAreaIDFromAimimax();

                wrongInput = _validation.ValidateAreaID(areaID);          

            } while (wrongInput);

            return areaID;
        }       

        private int GetAreaIDFromAimimax()
        {
            _aimimax.GetAMove();
            if (_playerX.InAction)
                return _aimimax.AreaIDForX;
            if (_playerO.InAction)
                return _aimimax.AreaIDForO;
            else
                return -1;
        }

        private string GetAreaIDFromHuman()
        {            
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            if(_playerX.InAction)
                Console.WriteLine($"PlayerX: {_playerX.Name} ");
            if(_playerO.InAction)
                Console.WriteLine($"PlayerO: {_playerO.Name} ");
            Console.Write("Eingsbe..:");
            Console.ResetColor();
            Console.Write(" ");
            string userInput = Console.ReadLine();
            Console.WriteLine();         
            
            return userInput;
        }
     
        
    }
}
