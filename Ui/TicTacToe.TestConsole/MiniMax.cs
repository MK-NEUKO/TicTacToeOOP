using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    public class MiniMax
    {
        // Definieren der Werte für die Bewertungsfunktion.
        // definiere 10 für playerX gewonnen.
        // definiere -10 für playerO gewonnen.
        // definiere 0 für Unentschieden.
        // definiere 1 für alles offen.

        private TestData  _testData;
        private const int _playerXIsWinner = 10;
        private const int _playerOIsWinner = -10;
        private const int _gameIsTie = 0;
        private const int _gameIsOpen = 1;
        private readonly int[,] _winConstellation;


        public MiniMax(TestData testData)
        {
            _testData = testData;
            _winConstellation = new int[8, 3]
            {
                {0,1,2}, /*  +---+---+---+  */
                {3,4,5}, /*  | 0 | 1 | 2 |  */
                {6,7,8}, /*  +---+---+---+  */
                {0,3,6}, /*  | 3 | 4 | 5 |  */
                {1,4,7}, /*  +---+---+---+  */
                {2,5,8}, /*  | 6 | 7 | 8 |  */
                {0,4,8}, /*  +---+---+---+  */
                {2,4,6},
            };
        }

        public int Evaluate()
        {
            for (int i = 0; i < _winConstellation.GetLength(0); i++)
            {
                string actualContent = _testData.TestGameBoardList[_winConstellation[i, 0]];
                actualContent += _testData.TestGameBoardList[_winConstellation[i, 1]];
                actualContent += _testData.TestGameBoardList[_winConstellation[i, 2]];

                if (actualContent == "XXX")
                    return _playerXIsWinner;

                if (actualContent == "OOO")
                    return _playerOIsWinner;
            }
            foreach (var listItem in _testData.TestGameBoardList)
            {
                if (listItem == " ")
                    return _gameIsOpen;
            }
            return _gameIsTie;
        }
    }
}
