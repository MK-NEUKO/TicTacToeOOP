﻿using System.Collections.Generic;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract
{
    public interface IGameBoardManager
    {
        List<GameBoardArea> GameBoardAreaList { get; }
        bool IsPlayerXWinner { get; }
        bool IsPlayerOWinner { get; }
        bool IsGameTie { get; }
        void PlaceAToken(int areaID, string token);
        void CheckGameBoardState();
        void ResetGameBoard();
        void ShowStartAnimation(bool isNewGame);
        void ResetAnimationValue();
        void LoadLastGameBoard();
    }
}