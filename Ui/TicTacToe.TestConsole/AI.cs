using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    public class AI
    {                               
        private IList<GameBoardArea> _evaluationList;
        private string[] _gameBoard;
        private IGameBoard _board;
        private IPlayer _playerX;
        private IPlayer _playerO;
        private readonly int[,] _winConstellation;
        private const int _xIsWinner = 10;
        private const int _oIsWinner = -10;
        private const int _gameIsTie = 0;
        private const int _gameIsOpen = -2;
        private int _areaIDForX;
        private int _areaIDForO;

        public AI()
        {

        }
        
        public AI(IList<GameBoardArea> evaluationList, IGameBoard board, IPlayer playerX, IPlayer playerO)
        {
            _evaluationList = evaluationList;
            _gameBoard = new string[9];
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
        }

        public int AreaIDForO { get => _areaIDForO; }
        public int AreaIDForX { get => _areaIDForX; }

        public void GetAMove()
        {
            for (int index = 0; index < _gameBoard.Length; index++)
            {
                _gameBoard[index] = _board.BoardAreaList[index].Area;
                Console.WriteLine(_gameBoard[index]);
            }

        }



        
        //private int Max(int depth, double alpha, double beta)
        //{


        //}

        //private int Min(int depth, double alpha, double beta)
        //{
        //    if (EvaluateGameBoard() != _gameIsOpen)
        //        return EvaluateGameBoard();
        //    //if (depth == 0)
        //    //    return EvaluateBoardAreas();

        //    foreach (GameBoardArea area in _evaluationList)
        //    {
        //        if (area.Area == " ")
        //        {
        //            area.Area = "O";
        //            double max = Max(depth - 1, alpha, beta);
        //            area.Area = " ";
        //            if (max < beta)
        //            {
        //                beta = max;
        //                if (depth == _playerO.MaximumDepth)
        //                    _areaIDForO = area.AreaID;
        //            }                        
        //            if (beta <= alpha)
        //                return alpha;
        //        }
        //    }
        //    return beta;
        //}


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
            if (IsGameTie())
                return _gameIsTie;
            return _gameIsOpen;
        }

        private bool IsGameTie()
        {
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                    return false;
            }
            return true;
        }
    }
}