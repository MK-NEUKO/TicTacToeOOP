using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Composition root


            // TODO Erzeugung des Spielfelds mit Factory-Pattern? (Factory-Pattern lernen)!
            //GameBoard board = new GameBoard(boardAreaList)

            ConsoleView view = new ConsoleView();
            TicTacToe tictactoe = new TicTacToe(view);


            tictactoe.Play();
        }
    }


    public class TicTacToe
    {
        public ConsoleView View { get; set; }

        public TicTacToe(ConsoleView view)
        {
            this.View = view;
        }

        public void Play()
        {
            View.ShowTitle();
            View.ShowMenu();
        }
    }


    public class ConsoleView
    {
        public void ShowTitle()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("TicTacToe Console   +++MK-NEUKO+++ ");
            Console.WriteLine("---------------------------------- ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Menu: Beenden = (ENDE) | Neues Spiel = (NEU) | Ja = (J) | Nein = (N) ");
            Console.ResetColor();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("Eingebe..:");
            Console.ResetColor();
            Console.Write(" ");
            string userInput = Console.ReadLine();
            CheckUserInput(userInput);
        }

        private void CheckUserInput(string userInput)
        {

        }
    }
}
