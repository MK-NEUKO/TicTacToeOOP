using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class ConsoleView
    {
        private readonly IList<GameBoardArea> _boardAreaList;
        private readonly IGameBoard _board;
        private readonly IPlayer _playerX;
        private readonly IPlayer _playerO;
        private readonly IAI _aimimax;
        private int _tie;
        private bool _wrongUserInput;
        private bool _getStandardSettings;
        private bool _getAdvancedSettings;

        public ConsoleView(IList<GameBoardArea> boardAreaList, IGameBoard board, IPlayer playerX, IPlayer playerO, IAI aimimax)
        {
            _boardAreaList = boardAreaList;
            _board = board;
            _playerX = playerX;
            _playerO = playerO;
            _aimimax = aimimax;
            _tie = 0;
            _wrongUserInput = true;
        }

        public bool WrongUserInput
        {
            get { return _wrongUserInput; }
        }

        public int Tie { get => _tie; set => _tie = value; }
        public bool GetStandardSettings { get => _getStandardSettings; }
        public bool GetAdvancedSettings { get => _getAdvancedSettings; }

        public void ShowTitle()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" TicTacToe   +++MK-NEUKO+++ ");
            Console.WriteLine(" -------------------------- ");
            Console.ResetColor();
            Console.WriteLine();
        }

        internal void AskForAdvancedSettings()
        {
            Console.WriteLine("Ad Settings");
        }

        internal void AskForStandartSettings()
        {
            bool repeatQuery;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Standart Einstellungen                                                   ");
            Console.WriteLine(" ------------------------------------------------------------------------ ");
            Console.WriteLine(" Grundeinstellungen: - Spieler 'O' ist der Computergegner.                ");
            Console.WriteLine("                     - Der Schwirigkeitsgrad ist wählbar.                 ");
            Console.WriteLine("                     - Nach jeder Partie wechselt der Beginnende Spieler. ");
            Console.WriteLine("                     - Spieler 'X' kann eine Namen eingeben.              ");
            Console.ResetColor();

            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("Name.:");
                Console.ResetColor();
                Console.Write(" ");
                string userInput = Console.ReadLine();
                if (String.IsNullOrEmpty(userInput))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Falsche Eingabe, ...");
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
            Console.WriteLine(" Unbesiegbar.: 3    ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            do
            {
                Console.Write("Name.:");
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
                    _aimimax.MaximumDepth = 2;
                    repeatQuery = false;
                }
                else if (userInput == "3")
                {
                    _aimimax.MaximumDepth = 5;
                    repeatQuery = false;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Falsche Eingabe, ...");
                    Console.ResetColor();
                    Console.WriteLine();
                    repeatQuery = true;
                }
                Console.ResetColor();
         
            } while (repeatQuery);
            

        }

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
                    _getStandardSettings = true;
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

        public void DrawGameBoard()
        {
            if (_board.PlayerXIsWinner || _board.PlayerOIsWinner)
            {
                DrawGameBoardWhenWon();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("     1   2   3   ");
                Console.WriteLine("   +---+---+---+ ");
                Console.WriteLine(" A | {0} | {1} | {2} | ", _boardAreaList[0].Area, _boardAreaList[1].Area, _boardAreaList[2].Area);
                Console.WriteLine("   +---+---+---+ ");
                Console.WriteLine(" B | {0} | {1} | {2} | ", _boardAreaList[3].Area, _boardAreaList[4].Area, _boardAreaList[5].Area);
                Console.WriteLine("   +---+---+---+ ");
                Console.WriteLine(" C | {0} | {1} | {2} | ", _boardAreaList[6].Area, _boardAreaList[7].Area, _boardAreaList[8].Area);
                Console.WriteLine("   +---+---+---+ ");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public void DrawInfoBoard()
        {
            string px = _playerX.Points.ToString();
            string po = _playerO.Points.ToString();
            string unentschieden = _tie.ToString();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("PlayerX: {0} | Computer ", _playerX.Name.PadRight(10, '.'));
            Console.WriteLine("PlayerO: {0} | Computer ", _playerO.Name.PadRight(10, '.'));
            Console.ResetColor();
            Console.WriteLine("-----------------------------------");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("   {0} {1}:{2} {3} ", _playerX.Name.PadLeft(10), px.PadLeft(3),/*_playerX.Points.PadLeft(3), _playerO.Points.PadRight(3),*/po.PadRight(3), _playerO.Name.PadRight(10) );
            Console.WriteLine("Unentschieden:   {0} ", unentschieden.PadRight(15));
            Console.WriteLine("Suchtiefe = {0}                    ", _aimimax.MaximumDepth);
            Console.ResetColor();
            Console.WriteLine();
        }

        private void DrawGameBoardWhenWon()
        {
            //string[] beginningBoardLine = new string[3]
            //{
            //    " A |",
            //    " B |",
            //    " C |"
            //};

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("     1   2   3   ");
            Console.WriteLine("   +---+---+---+ ");

            //for (int line = 0; line < 3; line++)
            //{
            //    Console.WriteLine(beginningBoardLine[line]);
            //    for (int area = line; area < area + 3; area++)
            //    {

            //    }

            //}

            Console.Write(" A |");

            for (int i = 0; i < 3; i++)
            {
                if (_boardAreaList[i].IsWinArea)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" " + _boardAreaList[i].Area + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(" " + _boardAreaList[i].Area + " ");
                }
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("|");
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" ");  
            
            Console.WriteLine("   +---+---+---+ ");
            Console.Write(" B |");

            for (int i = 3; i < 6; i++)
            {
                if (_boardAreaList[i].IsWinArea)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" " + _boardAreaList[i].Area + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(" " + _boardAreaList[i].Area + " ");
                }
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("|");
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" ");

            Console.WriteLine("   +---+---+---+ ");
            Console.Write(" C |");

            for (int i = 6; i < 9; i++)
            {
                if (_boardAreaList[i].IsWinArea)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" " + _boardAreaList[i].Area + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(" " + _boardAreaList[i].Area + " ");
                }
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("|");
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" ");

            Console.WriteLine("   +---+---+---+ ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void AskGameSettings()
        {

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
                    Console.ReadKey();
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

        public void ShowWinner()
        {
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
        }
    }
}
