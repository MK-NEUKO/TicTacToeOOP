using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    public class TestData
    {
        private List<string> _testGameBoardList;
        private string _testGameBoardInput;
        private string _searchDepth;

        public TestData(List<string> testGameBoard)
        {
            _testGameBoardList = testGameBoard;
        }

        public List<string> TestGameBoardList { get => _testGameBoardList; }

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
            foreach (char currentChar in _testGameBoardInput)
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
