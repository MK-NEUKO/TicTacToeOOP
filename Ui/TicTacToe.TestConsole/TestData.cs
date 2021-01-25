using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    class TestData
    {
        private List<string> _testGameBoardList;
        private string _testGameBoardAsString;
        private string _searchDepth;

        public TestData()
        {
            _testGameBoardList = new List<string>();
        }

        public List<string> TestGameBoardList { get => _testGameBoardList; set => _testGameBoardList = value; }

        public void GetTestData()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" Visual-AI-TicTacToe                                     ");
            Console.WriteLine("-------------------------------------------------------- ");
            Console.WriteLine(" Visuelle Darstellung eines Suchbaums im Spiel TicTacToe ");
            Console.ResetColor();
            TestDataInput();
            KreateTestGameBoardList();
        }        

        private void TestDataInput()
        {
            Console.WriteLine();
            Console.WriteLine(" Eingabe der Testdaten:");
            Console.WriteLine();
            Console.WriteLine("  1|2|3                    X| |X");
            Console.WriteLine("  -+-+-                    -+-+-");
            Console.WriteLine("  4|5|6    Zum Beispiel    X|O|     =>  <X,-,X,X,O,-,-,O,O>");
            Console.WriteLine("  -+-+-                    -+-+-");
            Console.WriteLine("  7|8|9                     |O|O");
            Console.WriteLine();
            Console.WriteLine(" Testdaten eingeben:");
            Console.WriteLine(" ----------------------------------------- ");
            Console.Write(" TestGameBoard: ");
            _testGameBoardAsString = Console.ReadLine();
            Console.Write(" Suchtiefe: ");
            _searchDepth = Console.ReadLine();
            Console.WriteLine();   
        }

        private void KreateTestGameBoardList()
        {
            _testGameBoardAsString = _testGameBoardAsString.ToUpper();
            _testGameBoardAsString = _testGameBoardAsString.Replace(",", string.Empty);
            _testGameBoardAsString = _testGameBoardAsString.Replace('-', ' ');
            foreach (char currentChar in _testGameBoardAsString)
            {
                _testGameBoardList.Add(currentChar.ToString());
            }                    
        }

        public void ShowTestData()
        {
            Console.WriteLine();
            Console.WriteLine(" Folgende Testdaten wurden eingegeben:");
            Console.WriteLine(" ----------------------------------------- ");
            Console.WriteLine($"  {_testGameBoardList[0]}|{_testGameBoardList[1]}|{_testGameBoardList[2]}    Suchtiefe: {_searchDepth}");
            Console.WriteLine("  -+-+- ");
            Console.WriteLine($"  {_testGameBoardList[3]}|{_testGameBoardList[4]}|{_testGameBoardList[5]}");
            Console.WriteLine("  -+-+- ");
            Console.WriteLine($"  {_testGameBoardList[6]}|{_testGameBoardList[7]}|{_testGameBoardList[8]}");
            Console.WriteLine();
        }
    }
}
