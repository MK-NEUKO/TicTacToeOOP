using System;

namespace NEUKO.TicTacToe.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Objekte erstellen
            TestData testDataSet = new TestData();
            // Eingaben für die Testkonfiguration holen
            testDataSet.GetTestData();
            // Testkonfiguraton Anzeigen
            testDataSet.ShowTestData();
            // Test fahren, dabei den Suchbaum visualisieren.

            Console.ReadLine();
        }            
    }
}
