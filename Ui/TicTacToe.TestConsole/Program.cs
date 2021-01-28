using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Objekte erstellen
            TestDateInput testDataInput = new TestDateInput();
            MiniMax minimax = new MiniMax(testDataInput);
            VisualMiniMax visualMinimax = new VisualMiniMax(testDataInput, minimax);

            // Test fahren, dabei den Suchbaum visualisieren.
            visualMinimax.VisualizeMiniMaxAlgorithem();

            Console.ReadLine();
        }            
    }
}
