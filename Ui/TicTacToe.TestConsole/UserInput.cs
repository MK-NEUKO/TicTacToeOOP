using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    public class UserInput
    {
        private char [] _boardAreas;
        private string _testGameBoardInput;
        private string _searchDepth;
        private char _nextPlayer;
        private string _nextPlayerUserInput;

        public UserInput()
        {
            _boardAreas = new char[9];
        }

        public char[] BoardAreas { get => _boardAreas; }
        public char NextPlayer{ get => _nextPlayer; }
        public string SearchDepth { get => _searchDepth; }

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
            Console.WriteLine("  0|1|2                    X| |X");
            Console.WriteLine("  -+-+-                    -+-+-");
            Console.WriteLine("  3|4|5    Zum Beispiel    X|O|     =>  <X-X,XO-,-OO>");
            Console.WriteLine("  -+-+-                    -+-+-");
            Console.WriteLine("  6|7|8                     |O|O");
            Console.WriteLine();
            Console.WriteLine(" Testdaten eingeben:");
            Console.WriteLine(" ----------------------------------------- ");
            Console.Write(" TestGameBoard: ");
            _testGameBoardInput = Console.ReadLine();
            Console.Write(" Suchtiefe....: ");
            _searchDepth = Console.ReadLine();
            Console.Write(" Nächster Zug.: ");
            _nextPlayerUserInput = Console.ReadLine();
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

            _nextPlayerUserInput = _nextPlayerUserInput.ToUpper();
            _nextPlayer = Convert.ToChar(_nextPlayerUserInput);
        }

        public void ShowTestData()
        {
            Console.WriteLine();
            Console.WriteLine(" Folgende Testdaten wurden eingegeben:");
            Console.WriteLine(" ----------------------------------------- ");
            Console.WriteLine($"  {_boardAreas[0]}|{_boardAreas[1]}|{_boardAreas[2]}    Suchtiefe...: {_searchDepth}");
            Console.WriteLine($"  -+-+-    Nächster Zug: {_nextPlayer}");
            Console.WriteLine($"  {_boardAreas[3]}|{_boardAreas[4]}|{_boardAreas[5]}");
            Console.WriteLine("  -+-+- ");
            Console.WriteLine($"  {_boardAreas[6]}|{_boardAreas[7]}|{_boardAreas[8]}");
            Console.WriteLine();
        }
    }
}
