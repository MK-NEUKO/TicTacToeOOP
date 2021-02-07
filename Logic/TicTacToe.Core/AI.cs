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
        //private readonly double[] _boardAreaFineValue;
        private const int _xIsWinner = 1;
        private const int _oIsWinner = -1;
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

            //_boardAreaFineValue = new double[9]
            //{
            //    0.03,0.02,0.03,
            //    0.02,0.04,0.02,
            //    0.03,0.02,0.03
            //};
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

            if(_playerX.InAction)
                GetMoveForPlayerX();
            if(_playerO.InAction)
                GetMoveForPlayerO();
        }

        private int GetMoveForPlayerX()
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();

            int maximumValue = int.MinValue;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    int returnMinValue = Min();
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

        private int GetMoveForPlayerO()
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();

            int minmumValue = int.MaxValue;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    int returnMaxValue = Max();
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


        private int Max()
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();

            int maximumValue = int.MinValue;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    int returnMinValue = Min();
                    area.Area = " ";
                    if (returnMinValue > maximumValue)
                    {
                        maximumValue = returnMinValue;
                    }                                        
                }
            }
            return maximumValue;
        }

        private int Min()
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();

            int minmumValue = int.MaxValue;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    int returnMaxValue = Max();
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

        //private double EvaluateBoardAreas()
        //{
        //    double value = 0;
        //    int index = 0;
        //    foreach (GameBoardArea area in _evaluationList)
        //    {
        //        if (area.Area == "O")
        //            value -= _boardAreaFineValue[index];
        //        if (area.Area == "X")
        //            value += _boardAreaFineValue[index];
        //        index++;
        //    }
        //    return value;
        //}
    }
}