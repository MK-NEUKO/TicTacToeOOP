using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
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

        public DisplayView(IList<GameBoardArea> boardAreaList, IGameBoard board, IPlayer playerX, IPlayer playerO, IPlayerController playerController, IAI aimimax)
        {
            _boardAreaList = boardAreaList;
            _board = board;
            _playerX = playerX;
            _playerO = playerO;
            _playerController = playerController;
            _aimimax = aimimax;
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

        public void ShowGameBoard()
        {
            if (_board.IsPlayerXWinner || _board.IsPlayerOWinner)
            {
                ShowGameBoardWhenWon();
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



        private void ShowGameBoardWhenWon()
        {           
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("     1   2   3   ");
            Console.WriteLine("   +---+---+---+ "); 
            
            // Erste Zeile vom Spielfeld
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

            // Zweite Zeile vom Spielfeld
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

            // Dritte Zeile vom Spielfeld
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

        public void ShowInfoBoard()
        {
            string[] playerStatus = new string[2] { "Computer", "Mensch" };            
            string pointsPlayerX = _playerX.Points.ToString();
            string pointsPlayerO = _playerO.Points.ToString();
            string gameIsTie = _playerController.GameIsTie.ToString();
            string[] diffecultyLevel = new string[6] { "Relativ", "Leicht", "Normal", "Schwer", " ", "UNBESIEGBAR" };
                

            // WhenWon Zeile

            // Erste Zeile
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" +-------------------------------------------+ ");
            Console.Write(" | ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($" Player'X' {playerStatus[Convert.ToInt32 (_playerX.IsHuman)].PadLeft(8)} | {playerStatus[Convert.ToInt32(_playerO.IsHuman)].PadRight(8)} Player'O' ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" | ");

            // Zwischenzeile
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" +-");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("--------------------|--------------------");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-+ ");
            

            // Zweite Zeile
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" | ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($" {_playerX.Name.PadRight(14, '.')} {pointsPlayerX.PadLeft(3)} | {pointsPlayerO.PadRight(3)} {_playerO.Name.PadLeft(14, '.')} ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" | ");

            // Zwischenzeile
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" +-");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-+ ");

            // Dritte Zeile
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" | ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($" Unentschieden      {gameIsTie.PadRight(21)}");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" | ");

            // Zwischenzeile
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" +-");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-+ ");

            // Vierte Zeile
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" | ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($" {diffecultyLevel[_playerX.MaximumDepth].PadRight(18)} | {diffecultyLevel[_playerO.MaximumDepth].PadRight(18)} ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" | ");


            // Letzte Zeile
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" +-------------------------------------------+ ");                                  
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowWinner()
        {                    
            Console.BackgroundColor = ConsoleColor.DarkRed;
            if (_board.IsPlayerXWinner)
                Console.WriteLine("{0} hat gewonnen!!!", _playerX.Name);
            else if (_board.IsPlayerOWinner)               
                Console.WriteLine("{0} hat gewonnen!!!", _playerO.Name);
            Console.ResetColor();            
        }
    }
}
