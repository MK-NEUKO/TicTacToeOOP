﻿using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public interface IGameInfoViewModel
    {
        public Player PlayerX { get; }
        public Player PlayerO { get; }

        void InitializeNewPlayerList();
    }
}
