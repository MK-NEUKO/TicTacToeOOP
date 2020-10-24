using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class ConsoleView
    {
        private readonly IList<GameBoardArea> _boardAreaList;
        private readonly IPlayer _playerX;
        private readonly IPlayer _playerO;

        public ConsoleView(IList<GameBoardArea> boardAreaList, IPlayer playerX, IPlayer playerO)
        {
            _boardAreaList = boardAreaList;
            _playerX = playerX;
            _playerO = playerO;
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
            Console.WriteLine(" A | {0} | {1} | {2} | ", _boardAreaList[0].Signe, _boardAreaList[1].Signe, _boardAreaList[2].Signe);           
            Console.WriteLine("   +---+---+---+ ");
            Console.WriteLine(" B | {0} | {1} | {2} | ", _boardAreaList[3].Signe, _boardAreaList[4].Signe, _boardAreaList[5].Signe);
            Console.WriteLine("   +---+---+---+ ");
            Console.WriteLine(" C | {0} | {1} | {2} | ", _boardAreaList[6].Signe, _boardAreaList[7].Signe, _boardAreaList[8].Signe);
            Console.WriteLine("   +---+---+---+ ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void DrawInfoBoard()
        {
            Console.WriteLine("PlayerX: {0} | Mensch", _playerX.Name);
            Console.WriteLine("PlayerO: {0} | Computer", _playerO.Name);
            Console.WriteLine("Punktestand: (X) 12 : 4 (O) || 5 Unentschieden");
            Console.WriteLine();
        }

        public void DrawGameBoardAtWin()
        {

        }

        public void AskGameSettings()
        {

        }

        public int AskPlayerForInput(string player, string name)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("{0}: {1}", player, name);
            Console.Write("Eingsbe..:");
            Console.ResetColor();
            Console.Write(" ");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            return ConvertUserInput(userInput);
        }

        private int ConvertUserInput(string input)
        {
            input = input.ToUpper();
            switch (input)
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

        }
    }
}
