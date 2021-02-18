using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public interface IGameBoardViewModel
    {
        IReadOnlyList<GameBoardArea> GameBoardAreaList { get; }
    }
}
