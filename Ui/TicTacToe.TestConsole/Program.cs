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
            // Eingaben für die Testkonfiguration holen
            testData.GetTestData();
            // Testkonfiguraton Anzeigen
            testData.ShowTestData();
            Console.WriteLine($" Evatuate(): {minimax.Evaluate()}");
            // Test fahren, dabei den Suchbaum visualisieren.

            Console.ReadLine();
        }            
    }
}
