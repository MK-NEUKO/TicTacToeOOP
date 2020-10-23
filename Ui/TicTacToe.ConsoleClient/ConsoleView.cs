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

        public void ShowGameBoard()
        {
            string[] signes = new string[9];
            int index = 0;
            foreach (GameBoardArea area in _boardAreaList)
            {
                signes[index] = area.Signe;
                index++;
            }

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("     1   2   3   ");
            Console.WriteLine("   +---+---+---+ ");
            Console.WriteLine(" A | {0} | {1} | {2} | ", signes[0], signes[1], signes[2]);
            Console.WriteLine("   +---+---+---+ ");
            Console.WriteLine(" B | {0} | {1} | {2} | ", signes[3], signes[4], signes[5]);
            Console.WriteLine("   +---+---+---+ ");
            Console.WriteLine(" C | {0} | {1} | {2} | ", signes[6], signes[7], signes[8]);
            Console.WriteLine("   +---+---+---+ ");
            Console.ResetColor();
            Console.WriteLine();
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
