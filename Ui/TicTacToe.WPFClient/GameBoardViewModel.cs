using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public class GameBoardViewModel : IGameBoardViewModel
    {
        public IReadOnlyList<GameBoardArea> GameBoardAreaList => throw new NotImplementedException();
    }
}
