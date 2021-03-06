﻿using MichaelKoch.TicTacToe.Logik.TicTacToeCore;

namespace NEUKO.TicTacToe.WPFClient
{
    public interface IGameInfoViewModel
    {
        public IPlayer PlayerX { get; set; }
        public IPlayer PlayerO { get; set; }
        public int NumberOfTie { get; set; }
    }
}
