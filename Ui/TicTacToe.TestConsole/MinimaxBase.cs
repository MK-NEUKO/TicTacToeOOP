using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public class AI : IAI
    {
        private IList<GameBoardArea> _evaluationList;
        private IGameBoard _board;
        private IPlayer _playerX;
        private IPlayer _playerO;
        private readonly int[,] _winConstellation;
        private readonly int[] _boardAreaFineValue;
        private const int _xIsWinner = 100;
        private const int _oIsWinner = -100;
        private const int _gameIsTie = 0;
        private const int _gameIsOpen = -2;
        private int _areaIDForX;
        private int _areaIDForO;

        public AI(IList<GameBoardArea> evaluationList, IGameBoard board, IPlayer playerX, IPlayer playerO)
        {
            _evaluationList = evaluationList;
            _board = board;
            _playerX = playerX;
            _playerO = playerO;
            _winConstellation = new int[8, 3]
            {
                {0,1,2}, /* +---+---+---+*/
                {3,4,5}, /* | 0 | 1 | 2 |*/
                {6,7,8}, /* +---+---+---+*/
                {0,3,6}, /* | 3 | 4 | 5 |*/
                {1,4,7}, /* +---+---+---+*/
                {2,5,8}, /* | 6 | 7 | 8 |*/
                {0,4,8}, /* +---+---+---+*/
                {2,4,6},
            };

            _boardAreaFineValue = new int[9]
            {
                3, 2, 3,
                2, 4, 2,
                3, 2, 3
            };
        }

        public AI()
        {
        }

        public int AreaIDForO { get => _areaIDForO; }
        public int AreaIDForX { get => _areaIDForX; }

        public void GetAMove()
        {
            _evaluationList = _board.BoardAreaList;
            _areaIDForX = -1;
            _areaIDForO = -1;

            if (_playerX.InAction)
                GetMoveForPlayerX(_playerX.MaximumDepth);
            if (_playerO.InAction)
                GetMoveForPlayerO(_playerO.MaximumDepth);
        }

        private int GetMoveForPlayerX(int maximumDepth)
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();

            int maximumValue = int.MinValue;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    int returnMinValue = Min(maximumDepth);
                    area.Area = " ";
                    if (returnMinValue > maximumValue)
                    {
                        maximumValue = returnMinValue;
                        _areaIDForX = area.AreaID;
                    }
                }
            }
            return maximumValue;
        }

        private int GetMoveForPlayerO(int maximumDepth)
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();

            int minmumValue = int.MaxValue;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    int returnMaxValue = Max(maximumDepth);
                    area.Area = " ";
                    if (returnMaxValue < minmumValue)
                    {
                        minmumValue = returnMaxValue;
                        _areaIDForO = area.AreaID;
                    }
                }
            }
            return minmumValue;
        }


        private int Max(int maximumDepth)
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();
            if (maximumDepth == 0)
                return EvaluateBoardAreas();

            int maximumValue = int.MinValue;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    int returnMinValue = Min(maximumDepth - 1);
                    area.Area = " ";
                    if (returnMinValue > maximumValue)
                    {
                        maximumValue = returnMinValue;
                    }
                }
            }
            return maximumValue;
        }

        private int Min(int maximumDepth)
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();
            if (maximumDepth == 0)
                return EvaluateBoardAreas();

            int minmumValue = int.MaxValue;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    int returnMaxValue = Max(maximumDepth - 1);
                    area.Area = " ";
                    if (returnMaxValue < minmumValue)
                    {
                        minmumValue = returnMaxValue;
                    }
                }
            }
            return minmumValue;
        }


        private int EvaluateGameBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                string actualContent = _evaluationList[_winConstellation[i, 0]].Area;
                actualContent += _evaluationList[_winConstellation[i, 1]].Area;
                actualContent += _evaluationList[_winConstellation[i, 2]].Area;

                if (actualContent == "XXX")
                    return _xIsWinner;

                if (actualContent == "OOO")
                    return _oIsWinner;
            }

            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                    return _gameIsOpen;
            }
            return _gameIsTie;
        }

        private int EvaluateBoardAreas()
        {
            int value = 0;
            int index = 0;
            foreach (var area in _evaluationList)
            {
                if (area.Area == "O")
                    value -= _boardAreaFineValue[index];
                if (area.Area == "X")
                    value += _boardAreaFineValue[index];
                index++;
            }
            return value;
        }
    }
}