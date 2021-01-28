using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Objekte erstellen
            UserInput userInput = new UserInput();
            MiniMax minimax = new MiniMax(userInput);
            VisualMiniMax visualMinimax = new VisualMiniMax(userInput, minimax);

            // Test fahren, dabei den Suchbaum visualisieren.
            visualMinimax.VisualizeMiniMaxAlgorithem();

            Console.ReadLine();
        }            
    }
}
