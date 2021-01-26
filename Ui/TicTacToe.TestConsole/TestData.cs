using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    public class TestData
    {
        private char [] _boardAreas;
        private string _testGameBoardInput;
        private string _searchDepth;

        public TestData()
        {
            _boardAreas = new char[9];
        }

        public char[] BoardAreas { get => _boardAreas; }

        public void GetTestData()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" Visual-AI-TicTacToe                                     ");
            Console.WriteLine("-------------------------------------------------------- ");
            Console.WriteLine(" Visuelle Darstellung eines Suchbaums im Spiel TicTacToe ");
            Console.ResetColor();
            TestDataInput();
            CreateTestGameBoardList();
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
            _testGameBoardInput = Console.ReadLine();
            Console.Write(" Suchtiefe: ");
            _searchDepth = Console.ReadLine();
            Console.WriteLine();   
        }

        private void CreateTestGameBoardList()
        {
            _testGameBoardInput = _testGameBoardInput.ToUpper();
            _testGameBoardInput = _testGameBoardInput.Replace(",", string.Empty);
            _testGameBoardInput = _testGameBoardInput.Replace('-', ' ');
            for (int index = 0; index < _boardAreas.Length; index++)
            {
                _boardAreas[index] = _testGameBoardInput[index];
            }
        }

        public void ShowTestData()
        {
            Console.WriteLine();
            Console.WriteLine(" Folgende Testdaten wurden eingegeben:");
            Console.WriteLine(" ----------------------------------------- ");
            Console.WriteLine($"  {_boardAreas[0]}|{_boardAreas[1]}|{_boardAreas[2]}    Suchtiefe: {_searchDepth}");
            Console.WriteLine("  -+-+- ");
            Console.WriteLine($"  {_boardAreas[3]}|{_boardAreas[4]}|{_boardAreas[5]}");
            Console.WriteLine("  -+-+- ");
            Console.WriteLine($"  {_boardAreas[6]}|{_boardAreas[7]}|{_boardAreas[8]}");
            Console.WriteLine();
        }
    }
}
