using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contarct;
using System;
using System.Collections.Generic;
using System.Text;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore
{
    public class AI : IAI
    {
        private IGameBoardRepository _gameBoardRepository;
        private IPlayerReposytory _playerRepository;     
        private IGameBoardManager _gameBoardManager;
        
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
        
        public AI(IGameBoardRepository gameBoardRepository, IPlayerReposytory playerReposytory, IGameBoardManager boardManager)
        {
            _gameBoardRepository = gameBoardRepository;
            _playerRepository = playerReposytory;
            _gameBoardManager = boardManager;
            
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
            foreach (var area in _gameBoardManager.GameBoardAreaList)
            {
                if (area.Token == " ")
                {
                    area.Token = "X";
                    int returnMinValue = Min(maximumDepth, alpha, beta);
                    area.Token = " ";
                    if (returnMinValue > alpha)
                    {
                        alpha = returnMinValue;
                        _areaIDForX = area.Id;
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
            foreach (var area in _gameBoardManager.GameBoardAreaList)
            {
                if (area.Token == " ")
                {
                    area.Token = "O";
                    int returnMaxValue = Max(maximumDepth, alpha, beta);
                    area.Token = " ";
                    if (returnMaxValue < beta)
                    {
                        beta = returnMaxValue;
                        _areaIDForO = area.Id;
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

            foreach (var area in _gameBoardManager.GameBoardAreaList)
            {
                if (area.Token == " ")
                {
                    area.Token = "X";
                    int returnMinValue = Min(maximumDepth - 1, alpha, beta);                    
                    if (returnMinValue > alpha)
                    {
                        alpha = returnMinValue;
                    }

                    area.Token = " ";
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
         
            foreach (var area in _gameBoardManager.GameBoardAreaList)
            {
                if (area.Token == " ")
                {
                    area.Token = "O";
                    int returnMaxValue = Max(maximumDepth - 1, alpha, beta);                    
                    if (returnMaxValue < beta)
                    {
                        beta = returnMaxValue;
                    }

                    area.Token = " ";
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
                string actualContent = _gameBoardManager.GameBoardAreaList[_winConstellations[i, 0]].Token;
                actualContent += _gameBoardManager.GameBoardAreaList[_winConstellations[i, 1]].Token;
                actualContent += _gameBoardManager.GameBoardAreaList[_winConstellations[i, 2]].Token;

                if (actualContent == "XXX")
                    return _xIsWinner;

                if (actualContent == "OOO")
                    return _oIsWinner;
            }

            foreach (var area in _gameBoardManager.GameBoardAreaList)
            {
                if (area.Token == " ")
                    return _gameIsOpen;
            }
            return _gameIsTie;
        }

        //private int EvaluateBoardAreas()
        //{
        //    int value = 0;
        //    int index = 0;
        //    foreach (var area in _gameBoardManager.GameBoardAreaList)
        //    {
        //        if (area.Token == "O")
        //            value -= _boardAreaFineValues[index];
        //        if (area.Token == "X")
        //            value += _boardAreaFineValues[index];
        //        index++;
        //    }
        //    return value;
        //}
    }
}