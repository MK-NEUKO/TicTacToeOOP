using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public class AI : IAI
    {
        private IGameBoard _board;
        private IPlayer _playerX;
        private IPlayer _playerO;
        private readonly int[,] _winConstellations;
        private readonly int[] _boardAreaFineValues;
        private const int _xIsWinner = 100;
        private const int _oIsWinner = -100;
        private const int _gameIsTie = 0;
        private const int _gameIsOpen = -1;
        private int _areaIDForX;
        private int _areaIDForO;       
        
        public AI(IGameBoard board, IPlayer playerX, IPlayer playerO)
        {
            _board = board;
            _playerX = playerX;
            _playerO = playerO;
            _winConstellations = new int[8, 3]
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

            _boardAreaFineValues = new int[9]
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
            _areaIDForX = -1;
            _areaIDForO = -1;

            if(_playerX.InAction)
                GetMoveForPlayerX(_playerX.MaximumDepth);
            if(_playerO.InAction)
                GetMoveForPlayerO(_playerO.MaximumDepth);
        }

        private int GetMoveForPlayerX(int maximumDepth)
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();

            int alpha = int.MinValue;
            int beta = int.MaxValue;
            foreach (GameBoardArea area in _board.BoardAreaList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    int returnMinValue = Min(maximumDepth, alpha, beta);
                    area.Area = " ";
                    if (returnMinValue > alpha)
                    {
                        alpha = returnMinValue;
                        _areaIDForX = area.AreaID;
                    }
                }
            }
            return alpha;
        }

        private int GetMoveForPlayerO(int maximumDepth)
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();

            int alpha = int.MinValue;
            int beta = int.MaxValue;
            foreach (GameBoardArea area in _board.BoardAreaList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    int returnMaxValue = Max(maximumDepth, alpha, beta);
                    area.Area = " ";
                    if (returnMaxValue < beta)
                    {
                        beta = returnMaxValue;
                        _areaIDForO = area.AreaID;
                    }
                }
            }
            return beta;
        }


        private int Max(int maximumDepth, int alpha, int beta)
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();
            if (maximumDepth == 0 && (_playerX.MaximumDepth > 1 || _playerO.MaximumDepth > 1))
                return EvaluateBoardAreas();

            foreach (GameBoardArea area in _board.BoardAreaList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    int returnMinValue = Min(maximumDepth - 1, alpha, beta);                    
                    if (returnMinValue > alpha)               
                        alpha = returnMinValue;
                    area.Area = " ";
                    if (alpha >= beta)
                        return beta;
                }
            }
            return alpha;
        }

        private int Min(int maximumDepth, int alpha, int beta)
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();
            if (maximumDepth == 0 && (_playerX.MaximumDepth > 1 || _playerO.MaximumDepth > 1))
                return EvaluateBoardAreas();
         
            foreach (GameBoardArea area in _board.BoardAreaList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    int returnMaxValue = Max(maximumDepth - 1, alpha, beta);                    
                    if (returnMaxValue < beta)
                         beta = returnMaxValue;
                    area.Area = " ";
                    if (beta <= alpha)
                        return alpha;
                }
            }
            return beta;
        }

        
        private int EvaluateGameBoard()
        {        
            for (int i = 0; i < _winConstellations.GetLength(0); i++)
            {
                string actualContent = _board.BoardAreaList[_winConstellations[i, 0]].Area;
                actualContent += _board.BoardAreaList[_winConstellations[i, 1]].Area;
                actualContent += _board.BoardAreaList[_winConstellations[i, 2]].Area;

                if (actualContent == "XXX")
                    return _xIsWinner;

                if (actualContent == "OOO")
                    return _oIsWinner;
            }

            foreach (GameBoardArea area in _board.BoardAreaList)
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
            foreach (var area in _board.BoardAreaList)
            {
                if (area.Area == "O")
                    value -= _boardAreaFineValues[index];
                if (area.Area == "X")
                    value += _boardAreaFineValues[index];
                index++;
            }
            return value;
        }
    }
}