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
        private bool _wrongUserInput;

        public ConsoleView(IList<GameBoardArea> boardAreaList, IGameBoard board, IPlayer playerX, IPlayer playerO)
        {
            _boardAreaList = boardAreaList;
            _board = board;
            _playerX = playerX;
            _playerO = playerO;
            _wrongUserInput = true;
        }

        public bool WrongUserInput
        {
            get { return _wrongUserInput; }
        }

        public void ShowTitle()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" TicTacToe   +++MK-NEUKO+++ ");
            Console.WriteLine(" -------------------------- ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void DrawGameBoard()
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

        public void DrawInfoBoard()
        {
            string px = "12";
            string po = "7";
            string unentschieden = "5";
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("PlayerX: {0} | Mensch   ", _playerX.Name.PadRight(10, '.'));
            Console.WriteLine("PlayerO: {0} | Computer ", _playerO.Name.PadRight(10, '.'));
            Console.ResetColor();
            Console.WriteLine("----------------------------------------");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Punkte:   {0} {1}:{2} {3} ", _playerX.Name.PadLeft(10), px.PadLeft(3),/*_playerX.Points.PadLeft(3), _playerO.Points.PadRight(3),*/po.PadRight(3), _playerO.Name.PadRight(10) );
            Console.WriteLine("Unentschieden:          {0} ", unentschieden.PadRight(15));
            Console.ResetColor();
            Console.WriteLine();
        }

        public void DrawGameBoardAtWin()
        {

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
                    Console.WriteLine("PlayerX: {0}", _playerX.Name);
                else
                    Console.WriteLine("PlayerO: {0}", _playerO.Name);
                Console.Write("Eingsbe..:");
                Console.ResetColor();
                Console.Write(" ");
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
