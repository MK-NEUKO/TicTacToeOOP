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

        private UserInput  _testData;
        private const int _playerXIsWinner = 10;
        private const int _playerOIsWinner = -10;
        private const int _gameIsTie = 0;
        private const int _gameIsOpen = 1;
        private int _nextMoveX;
        private int _nextMoveO;
        private readonly int[,] _winConstellation;

        public int NextMoveX { get => _nextMoveX; }
        public int NextMoveO { get => _nextMoveO; }

        public MiniMax(UserInput testData)
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
        
        public int NextMove(char player)
        {
            if (Evaluate() != _gameIsOpen)
                return Evaluate();

            if (player == 'X')
            {
                int maximumValue = -1000;
                for (int index = 0; index < _testData.BoardAreas.Length; index++)
                {
                    if (_testData.BoardAreas[index] == ' ')
                    {
                        _testData.BoardAreas[index] = 'X';
                        int minReturnValue = Min();
                        if (minReturnValue > maximumValue)
                        {
                            maximumValue = minReturnValue;
                            _nextMoveX = index;
                        }
                        _testData.BoardAreas[index] = ' ';
                    }
                }
                return maximumValue;
            }

            if (player == 'O')
            {
                int minimumValue = 1000;
                for (int index = 0; index < _testData.BoardAreas.Length; index++)
                {
                    if (_testData.BoardAreas[index] == ' ')
                    {
                        _testData.BoardAreas[index] = 'O';
                        int maxReturnValue = Max();
                        if (maxReturnValue < minimumValue)
                        {
                            minimumValue = maxReturnValue;
                            _nextMoveO = index;
                        }
                        _testData.BoardAreas[index] = ' ';
                    }
                }
                return minimumValue;
            }
            return 8888;
        }

        public int Max()
        {
            if (Evaluate() != _gameIsOpen)
                return Evaluate();
            int maximumValue = -1000;
            for (int index = 0; index < _testData.BoardAreas.Length; index++)
            {
                if (_testData.BoardAreas[index] == ' ')
                {
                    _testData.BoardAreas[index] = 'X';
                    int minReturnValue = Min();
                    if (minReturnValue > maximumValue)
                    {
                        maximumValue = minReturnValue;                       
                    }
                    _testData.BoardAreas[index] = ' ';
                }
            }
            return maximumValue;
        }

        public int Min()
        {
            if (Evaluate() != _gameIsOpen)
                return Evaluate();
            int minimumValue = 1000;
            for (int index = 0; index < _testData.BoardAreas.Length; index++)
            {
                if (_testData.BoardAreas[index] == ' ')
                {
                    _testData.BoardAreas[index] = 'O';
                    int maxReturnValue = Max();
                    if (maxReturnValue < minimumValue)
                    {
                        minimumValue = maxReturnValue;
                    }
                    _testData.BoardAreas[index] = ' ';
                }
            }
            return minimumValue;
        }

        public int Evaluate()
        {
            for (int i = 0; i < _winConstellation.GetLength(0); i++)
            {
                string actualContent = _testData.BoardAreas[_winConstellation[i, 0]].ToString();
                actualContent += _testData.BoardAreas[_winConstellation[i, 1]].ToString();
                actualContent += _testData.BoardAreas[_winConstellation[i, 2]].ToString();

                if (actualContent == "XXX")
                    return _playerXIsWinner;

                if (actualContent == "OOO")
                    return _playerOIsWinner;
            }
            foreach (var area in _testData.BoardAreas)
            {
                if (area == ' ')
                    return _gameIsOpen;
            }
            return _gameIsTie;
        }
    }
}
