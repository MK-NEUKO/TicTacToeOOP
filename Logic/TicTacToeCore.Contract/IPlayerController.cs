﻿using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using System.Collections.Generic;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract
{
    public interface IPlayerController
    {
        void ChangePlayer();
        string GiveCurrentToken();
        void GivePoints();
        Player GiveCurrentPlayer();
        void ResetPlayers();
        void SetWinner();
        void GetNewPlayerList();
        void GetLastPlayerList();
        Player PlayerX { get; }
        Player PlayerO { get; }
    }
}
