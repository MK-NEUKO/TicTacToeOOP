﻿using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class QueryView
    {
        private readonly IList<GameBoardArea> _boardAreaList;
        private readonly IGameBoard _board;
        private readonly IPlayer _playerX;
        private readonly IPlayer _playerO;
        private readonly IAI _aimimax;
        private bool _getMainSettings;
        private bool _getDefaultSettings;
        private bool _getAdvancedSettings;
        private bool _playerWillContinue;

        public QueryView(IList<GameBoardArea> boardAreaList, IGameBoard board, IPlayer playerX, IPlayer playerO, IAI aimimax)
        {
            _boardAreaList = boardAreaList;
            _board = board;
            _playerX = playerX;
            _playerO = playerO;
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
            bool repeatQuery;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Standart Einstellungen                                                    ");
            Console.WriteLine(" ------------------------------------------------------------------------- ");
            Console.WriteLine(" Grundeinstellungen: - Spieler 'O' ist der Computergegner.                 ");
            Console.WriteLine("                     - Der Computergegner hat den Namen Aimimax.           ");
            Console.WriteLine("                     - Als Erstes wird nach dem Namen von PlayerX gefragt. ");
            Console.WriteLine("                     - Als Zweites nach dem Schwierigkeitsgrad.            ");
            Console.WriteLine();                     

            do
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(" PlayerX, wähle einen Namen, erlaubt sind (A-Z, a-z, 0-9). ");
                Console.BackgroundColor = ConsoleColor.DarkBlue;                
                Console.Write(" Eingabe.:");
                Console.ResetColor();
                Console.Write(" ");
                string userInput = Console.ReadLine();
                if (String.IsNullOrEmpty(userInput))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Falsche Eingabe, erlaubt sind (A-Z, a-z, 0-9). ");
                    Console.ResetColor();
                    Console.WriteLine();

                    repeatQuery = true;
                }
                else
                {
                    _playerX.Name = userInput;
                    _playerX.IsHuman = true;
                    repeatQuery = false;
                }
            } while (repeatQuery);
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Schwierigkeitsgrad ");
            Console.WriteLine(" ------------------ ");
            Console.WriteLine(" Leicht......: 1    ");
            Console.WriteLine(" Normal......: 2    ");
            Console.WriteLine(" Schwer......: 3    ");
            Console.WriteLine(" Unbesiegbar.: 4    ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            do
            {
                Console.Write(" Eingabe.:");
                Console.ResetColor();
                Console.Write(" ");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    _aimimax.MaximumDepth = 0;
                    repeatQuery = false;
                }
                else if (userInput == "2")
                {
                    _aimimax.MaximumDepth = 1;
                    repeatQuery = false;
                }
                else if (userInput == "3")
                {
                    _aimimax.MaximumDepth = 2;
                    repeatQuery = false;
                }
                else if (userInput == "4")
                {
                    _aimimax.MaximumDepth = 5;
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

            // Noch fehlende Grundeinstellungen
            _playerX.InAction = true;
            _playerX.IsHuman = true;
            _playerO.Name = "Aimimax";
            _playerO.IsHuman = false;
        }

        public void AskForAdvancedSettings()
        {
            bool repeatQuery;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Erweiterte Einstellungen                                           ");
            Console.WriteLine(" ------------------------------------------------------------------ ");
            Console.WriteLine(" - PlayerX, sowie PlayerO können nach belieben konfiguriert werden. ");            
            Console.WriteLine();

            // 1. Frage ob PlayerX = Coputer oder Mensch, dann den Namen, dann wenn Computer, Schwiereigkeitsgrad?
            AskPlayerForHumanOrAI(_playerX);
            AskPlayerForName(_playerX);
            AskPlayerForDiffecultyLevel(_playerX);
            // 2. Frage ob PlayerO = Coputer oder Mensch, dann den Namen, dann wenn Computer, Schwiereigkeitsgrad?
            
        }

        private void AskPlayerForDiffecultyLevel(IPlayer askedPlayer)
        {
            throw new NotImplementedException();
        }

        private void AskPlayerForName(IPlayer askedPlayer)
        {
            throw new NotImplementedException();
        }

        private void AskPlayerForHumanOrAI(IPlayer askedPlayer)
        {
            bool repeatQuery;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Mensch oder Computer ");
            Console.WriteLine(" -------------------- ");
            Console.WriteLine(" Mensch...: 1 ");
            Console.WriteLine(" Computer.: 2 ");
            Console.WriteLine();

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

        internal void AskForContinue()
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
            int areaID = 0;
            bool wrongInput = true;

            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                if (_playerX.InAction)
                    Console.WriteLine("PlayerX: {0} ", _playerX.Name);
                //else
                //    Console.WriteLine("PlayerO: {0} ", _playerO.Name);
                Console.Write("Eingsbe..:");
                Console.ResetColor();
                Console.Write(" ");
                //if (_playerX.InAction)
                //{
                //    _aimimax.GetAreaIDForX();
                //    Console.WriteLine(_aimimax.AreaIDForX);
                //    //Console.ReadKey();
                //    areaID = _aimimax.AreaIDForX;
                //}
                if (_playerO.InAction)
                {
                    _aimimax.GetAreaIDForO();
                    Console.WriteLine(_aimimax.AreaIDForO);
                    //Console.ReadKey();
                    return _aimimax.AreaIDForO;
                }

                userInput = Console.ReadLine();
                Console.WriteLine();
                areaID = ConvertUserInput(userInput);


                if (areaID < 0 || areaID > 8)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ungültige Eingabe, gültige Eingabe währe z.B. 'B1' od. 'c2'!");
                    Console.ResetColor();
                    Console.WriteLine();
                    wrongInput = true;
                }
                else if (_boardAreaList[areaID].AreaHasToken)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Das Feld ist bereits besetzt!");
                    Console.ResetColor();
                    Console.WriteLine();
                    wrongInput = true;
                }
                else
                    wrongInput = false;

            } while (wrongInput);

            return areaID;
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