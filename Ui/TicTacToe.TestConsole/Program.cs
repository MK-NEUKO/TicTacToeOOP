using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Objekte erstellen
            List<string> testGameBoard = new List<string>();
            TestData testData = new TestData(testGameBoard);
            MiniMax minimax = new MiniMax(testData);
            VisualMiniMax visualMinimax = new VisualMiniMax(testData, minimax);

            // Test fahren, dabei den Suchbaum visualisieren.
            visualMinimax.VisualizeMiniMaxAlgorithem();

            Console.ReadLine();
        }            
    }
}
