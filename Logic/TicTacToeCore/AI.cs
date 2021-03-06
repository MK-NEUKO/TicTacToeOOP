﻿using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contarct;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore
{
    public class AI : IAI
    {
        private IGameBoardRepository _gameBoardRepository;
        private IPlayerReposytory _playerRepository;     
        private IGameBoard _gameBoard;
        
        //private Player _playerX;
        //private Player _playerO;
        private readonly int[,] _winConstellations;
        //private readonly int[] _boardAreaFineValues;
        private const int _xIsWinner = 100;
        private const int _oIsWinner = -100;
        private const int _gameIsTie = 0;
        private const int _gameIsOpen = -1;
        private int _areaIDForX;
        private int _areaIDForO;
        private int _areaIDForCurrentPlayer;
        
        public AI(IGameBoardRepository gameBoardRepository, IPlayerReposytory playerReposytory, IGameBoard board)
        {
            _gameBoardRepository = gameBoardRepository;
            _playerRepository = playerReposytory;
            _gameBoard = board;
            
            //_playerX = _playerRepository.LoadNewPlayerList()[0];
            //_playerO = _playerRepository.LoadNewPlayerList()[1];
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

            //_boardAreaFineValues = new int[9]
            //{
            //    3, 2, 3,
            //    2, 4, 2,
            //    3, 2, 3
            //};
        }

        public AI()
        {
        }

        public int AreaIDForO { get => _areaIDForO; }
        
        public int AreaIDForCurrentPlayer { get => _areaIDForCurrentPlayer; set => _areaIDForCurrentPlayer = value; }

        public void GetAMove(Player currentPlayer)
        {
            _areaIDForX = -1;
            _areaIDForO = -1;
            _areaIDForCurrentPlayer = -1;

            if (currentPlayer.PlayerID == "X")
            {
                GetMoveForPlayerX(1);
                _areaIDForCurrentPlayer = _areaIDForX;
            }
            if (currentPlayer.PlayerID == "O")
            {
                GetMoveForPlayerO(1);
                _areaIDForCurrentPlayer = _areaIDForO;
            }
        }

        private int GetMoveForPlayerX(int maximumDepth)
        {
            if (EvaluateGameBoard() != _gameIsOpen)
                return EvaluateGameBoard();

            int alpha = int.MinValue;
            int beta = int.MaxValue;
            foreach (var area in _gameBoard.GameBoardAreaList)
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
            foreach (var area in _gameBoard.GameBoardAreaList)
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
            //if (maximumDepth == 0 && (_playerX.MaximumDepth > 1 || _playerO.MaximumDepth > 1))
            //    return EvaluateBoardAreas();

            foreach (var area in _gameBoard.GameBoardAreaList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    int returnMinValue = Min(maximumDepth - 1, alpha, beta);                    
                    if (returnMinValue > alpha)
                    {
                        alpha = returnMinValue;
                    }

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
            //if (maximumDepth == 0 && (_playerX.MaximumDepth > 1 || _playerO.MaximumDepth > 1))
            //    return EvaluateBoardAreas();
         
            foreach (var area in _gameBoard.GameBoardAreaList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    int returnMaxValue = Max(maximumDepth - 1, alpha, beta);                    
                    if (returnMaxValue < beta)
                    {
                        beta = returnMaxValue;
                    }

                    area.Area = " ";
                    if (beta <= alpha)
                    {
                        return alpha;
                    }
                }
            }
            return beta;
        }

        
        private int EvaluateGameBoard()
        {        
            for (int i = 0; i < _winConstellations.GetLength(0); i++)
            {
                string actualContent = _gameBoard.GameBoardAreaList[_winConstellations[i, 0]].Area;
                actualContent += _gameBoard.GameBoardAreaList[_winConstellations[i, 1]].Area;
                actualContent += _gameBoard.GameBoardAreaList[_winConstellations[i, 2]].Area;

                if (actualContent == "XXX")
                    return _xIsWinner;

                if (actualContent == "OOO")
                    return _oIsWinner;
            }

            foreach (var area in _gameBoard.GameBoardAreaList)
            {
                if (area.Area == " ")
                    return _gameIsOpen;
            }
            return _gameIsTie;
        }

        //private int EvaluateBoardAreas()
        //{
        //    int value = 0;
        //    int index = 0;
        //    foreach (var area in _gameBoard.GameBoardAreaList)
        //    {
        //        if (area.Area == "O")
        //            value -= _boardAreaFineValues[index];
        //        if (area.Area == "X")
        //            value += _boardAreaFineValues[index];
        //        index++;
        //    }
        //    return value;
        //}
    }
}