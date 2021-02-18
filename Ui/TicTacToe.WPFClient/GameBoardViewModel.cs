using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public class GameBoardViewModel : IGameBoardViewModel
    {
        private readonly IReadOnlyList<GameBoardArea> _gameBoardAreaList;

        public GameBoardViewModel(IReadOnlyList<GameBoardArea> gameBoardAreaList)
        {
            _gameBoardAreaList = gameBoardAreaList;
        }

        public IReadOnlyList<GameBoardArea> GameBoardAreaList => _gameBoardAreaList;
    }
}
