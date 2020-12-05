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
        private bool _getMainSettings;
        private bool _getDefaultSettings;
        private bool _getAdvancedSettings;
        private bool _playerWillContinue;

        public QueryView(IList<GameBoardArea> boardAreaList, IGameBoard board, IPlayer playerX, IPlayer playerO, IPlayerController playerController, IAI aimimax)
        {
            _boardAreaList = boardAreaList;
            _board = board;
            _playerX = playerX;
            _playerO = playerO;
            _playerController = playerController;
            _aimimax = aimimax;
            _getMainSettings = true;
        }

        public bool GetDefaultSettings { get => _getDefaultSettings; set => _getDefaultSettings = value; }
        public bool GetAdvancedSettings { get => _getAdvancedSettings; set => _getAdvancedSettings = value; }
        public bool GetMainSettings { get => _getMainSettings; set => _getMainSettings = value; }
        public bool PlayerWillContinue { get => _playerWillContinue; set => _playerWillContinue = value; }

        public void GetSettings()
        {
            bool repeatQuery;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Willkommen im Spiel TicTacToe ");
            Console.WriteLine(" ----------------------------- ");
            Console.WriteLine(" Standart Einstellungen...: 1  ");
            Console.WriteLine(" Erweiterte Einstellungen.: 2  ");
            Console.ResetColor();
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(" Eingabe.:");
                Console.ResetColor();
                Console.Write(" ");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    _getDefaultSettings = true;
                    _getAdvancedSettings = false;
                    repeatQuery = false;
                }
                else if (userInput == "2")
                {
                    _getAdvancedSettings = true;
                    repeatQuery = false;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Falsche Eingabe, bitte wähle '1' oder '2'! ");
                    Console.ResetColor();
                    Console.WriteLine();

                    repeatQuery = true;
                }
            } while (repeatQuery);

            Console.Clear();
        }

        internal void AskForDefaultSettings()
        {
            //bool repeatQuery;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Standart Einstellungen                                                    ");
            Console.WriteLine(" ------------------------------------------------------------------------- ");
            Console.WriteLine(" Grundeinstellungen: - Spieler 'O' ist der Computergegner.                 ");
            Console.WriteLine("                     - Der Computergegner hat den Namen Aimimax.           ");
            Console.WriteLine("                     - Als Erstes wird nach dem Namen von PlayerX gefragt. ");
            Console.WriteLine("                     - Als Zweites nach dem Schwierigkeitsgrad.            ");
            Console.WriteLine();


            AskPlayerForName(_playerX);

            _playerX.InAction = true;
            _playerX.IsHuman = true;
            _playerX.MaximumDepth = 0;
            _playerO.Name = "Aimimax";
            _playerO.IsHuman = false;

            AskPlayerForDiffecultyLevel(_playerO);
        }

        public void AskForAdvancedSettings()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Erweiterte Einstellungen                                           ");
            Console.WriteLine(" ------------------------------------------------------------------ ");
            Console.WriteLine(" - PlayerX, sowie PlayerO können nach belieben konfiguriert werden. ");
            Console.WriteLine();

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

        private void AskPlayerForDiffecultyLevel(IPlayer askedPlayer)
        {
            bool repeatQuery;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Schwierigkeitsgrad ");
            Console.WriteLine(" ------------------ ");
            Console.WriteLine(" Leicht......: 1    ");
            Console.WriteLine(" Normal......: 2    ");
            Console.WriteLine(" Schwer......: 3    ");
            Console.WriteLine(" Unbesiegbar.: 4    ");
            Console.WriteLine(" #### Hinweis!!!    -die Grade sind nicht genau abgestimmt, bitte probieren ### ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            do
            {
                Console.WriteLine($" Schwierigkeitsgrad für {askedPlayer.Name} ");
                Console.Write(" Eingabe.:");
                Console.ResetColor();
                Console.Write(" ");
                string userInput = Console.ReadLine();
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
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Falsche Eingabe, wähle die Menupunkte mit den Zahlen (1-4). ");
                    Console.ResetColor();
                    Console.WriteLine();
                    repeatQuery = true;
                }
                Console.ResetColor();

            } while (repeatQuery);
        }

        private void AskPlayerForName(IPlayer askedPlayer)
        {
            bool repeatQuery;

            do
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" {askedPlayer.Name}, wähle einen Namen, erlaubt sind 14 Zeichen ###noch nicht Implementiert:(A-Z, a-z, 0-9)###. ");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(" Eingabe.:");
                Console.ResetColor();
                Console.Write(" ");
                string userInput = Console.ReadLine();
                if (String.IsNullOrEmpty(userInput) || userInput.Length > 14 /*|| IsValidAlphaNumericString(userInput)*/)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Falsche Eingabe, erlaubt sind 14 Zeichen ###noch nicht Implementiert:(A-Z, a-z, 0-9)###. ");
                    Console.ResetColor();
                    Console.WriteLine();

                    repeatQuery = true;
                }
                else
                {
                    askedPlayer.Name = userInput;
                    repeatQuery = false;
                }
            } while (repeatQuery);
            Console.WriteLine();
        }

        //private bool IsValidAlphaNumericString(string userInput)
        //{
        //    Regex pattern = new Regex(@"[a-zA-Z0-9]");
        //    return pattern.IsMatch(userInput.Trim());
        //}

        private void AskPlayerForHumanOrAI(IPlayer askedPlayer)
        {
            bool repeatQuery;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($" Einstellungen für {askedPlayer.Name} ");
            Console.WriteLine(" ------------------------- ");
            Console.WriteLine(" Mensch...: 1 ");
            Console.WriteLine(" Computer.: 2 ");


            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(" Eingabe.:");
                Console.ResetColor();
                Console.Write(" ");
                string userInput = Console.ReadLine();
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
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Falsche Eingabe, bitte wähle '1' oder '2'! ");
                    Console.ResetColor();
                    Console.WriteLine();

                    repeatQuery = true;
                }
            } while (repeatQuery);
        }

        public void AskForContinue()
        {
            bool repeatQuery;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Noch ein Spiel?     ");
            Console.WriteLine(" ------------------- ");
            Console.WriteLine(" Weiter Spielen.: 1  ");
            Console.WriteLine(" Einstellungen..: 2  ");
            Console.ResetColor();
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(" Eingabe.:");
                Console.ResetColor();
                Console.Write(" ");
                string userInput = Console.ReadLine();
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
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Falsche Eingabe, bitte wähle '1' oder '2'! ");
                    Console.ResetColor();
                    Console.WriteLine();

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
                    areaID = ConvertUserInput(userInput);
                }
                else                
                    areaID = GetAreaIDFromAimimax();

                wrongInput = ValidateAreaID(areaID);          

            } while (wrongInput);

            return areaID;
        }

        private bool ValidateAreaID(int areaID)
        {

            if (areaID < 0 || areaID > 8)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ungültige Eingabe, gültige Eingabe währe z.B. 'B1' od. 'c2'!");
                Console.ResetColor();
                Console.WriteLine();
                return true;
            }
            else if (_boardAreaList[areaID].AreaHasToken)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Das Feld ist bereits besetzt!");
                Console.ResetColor();
                Console.WriteLine();
                return true;
            }
            else
                return false;
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
     
        private int ConvertUserInput(string userInput)
        {
            userInput = userInput.ToUpper();
            switch (userInput)
            {
                case "A1":
                    return 0;
                case "A2":
                    return 1;
                case "A3":
                    return 2;
                case "B1":
                    return 3;
                case "B2":
                    return 4;
                case "B3":
                    return 5;
                case "C1":
                    return 6;
                case "C2":
                    return 7;
                case "C3":
                    return 8;

            }
            return 9;
        }
    }
}
