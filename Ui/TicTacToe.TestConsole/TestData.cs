using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    class TestData
    {
        private List<string> _testGameBoardList;

        public TestData()
        {

        }

        public List<string> TestGameBoardList { get => _testGameBoardList; set => _testGameBoardList = value; }

        public void GetTestData()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" Visual-AI-TicTacToe                                     ");
            Console.WriteLine("-------------------------------------------------------- ");
            Console.WriteLine(" Visuelle Darstellung eines Suchbaums im Spiel TicTacToe ");
            Console.ResetColor();
            string userInput = GetTestDataGameBoard();
            KreateTestGameBoardList(userInput);
            GetTestDataPlayer();
        }        

        private string GetTestDataGameBoard()
        {
            Console.WriteLine();
            Console.WriteLine("Eingabe der Testdaten:");
            Console.WriteLine();
            Console.WriteLine("  1|2|3                    X| |X");
            Console.WriteLine("  -+-+-                    -+-+-");
            Console.WriteLine("  4|5|6    Zum Beispiel    X|O|     =>  <X,-,X,X,O,-,-,O,O>");
            Console.WriteLine("  -+-+-                    -+-+-");
            Console.WriteLine("  7|8|9                     |O|O");
            Console.WriteLine();
            Console.WriteLine("Bitte gib das TestGameBoard in der gezeigten Reihenfolge ein.");
            return Console.ReadLine();
        }

        private void KreateTestGameBoardList(string userInput)
        {
            userInput = userInput.Replace(",", string.Empty);
            userInput = userInput.Replace('-', ' ');
            Console.WriteLine(userInput);
        }

        private void GetTestDataPlayer()
        {
            Console.WriteLine("Holen der TestPlayer");
        }

        internal void ShowTestData()
        {
            Console.WriteLine("Testdaten ausgeben");
        }
    }
}
