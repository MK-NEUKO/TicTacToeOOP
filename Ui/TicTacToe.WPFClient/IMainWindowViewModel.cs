﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public interface IMainWindowViewModel
    {
        IGameBoardViewModel GameBoardViewModel { get; }
        IGameInfoViewModel GameInfoViewModel { get; }
        void PlayAMove(int areaID);
    }
}
