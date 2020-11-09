using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class DisplayView
    {
        private readonly IList<GameBoardArea> _boardAreaList;
        private readonly IGameBoard _board;
        private readonly IPlayer _playerX;
        private readonly IPlayer _playerO;
        private readonly IPlayerController _playerController;
        private readonly IAI _aimimax;
        private bool _wrongUserInput;

        public DisplayView(IList<GameBoardArea> boardAreaList, IGameBoard board, IPlayer playerX, IPlayer playerO, IPlayerController playerController, IAI aimimax)
        {
            _boardAreaList = boardAreaList;
            _board = board;
            _playerX = playerX;
            _playerO = playerO;
            _playerController = playerController;
            _aimimax = aimimax;
            _wrongUserInput = true;
        }

        public void ResetConsole()
        {
            Console.Clear();
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

        public void DrawInfoBoard()
        {
            string px = _playerX.Points.ToString();
            string po = _playerO.Points.ToString();
            string unentschieden = _playerController.GameIsTie.ToString();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("PlayerX: {0} | Computer ", _playerX.Name.PadRight(10, '.'));
            Console.WriteLine("PlayerO: {0} | Computer ", _playerO.Name.PadRight(10, '.'));
            Console.ResetColor();
            Console.WriteLine("-----------------------------------");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("   {0} {1}:{2} {3} ", _playerX.Name.PadLeft(10), px.PadLeft(3),/*_playerX.Points.PadLeft(3), _playerO.Points.PadRight(3),*/po.PadRight(3), _playerO.Name.PadRight(10));
            Console.WriteLine("Unentschieden:   {0} ", unentschieden.PadRight(15));
            Console.WriteLine("Suchtiefe = {0}                    ", _aimimax.MaximumDepth);
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowWinner()
        {                    
            Console.BackgroundColor = ConsoleColor.DarkRed;
            if (_board.PlayerXIsWinner)
                Console.WriteLine("{0} hat gewonnen!!!", _playerX.Name);
            else if (_board.PlayerOIsWinner)               
                Console.WriteLine("{0} hat gewonnen!!!", _playerO.Name);
            Console.ResetColor();            
        }
    }
}
