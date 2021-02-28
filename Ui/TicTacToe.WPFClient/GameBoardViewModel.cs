using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public class GameBoardViewModel : IGameBoardViewModel
    {
        private readonly IList<GameBoardArea> _gameBoardAreaList;

        public GameBoardViewModel(IList<GameBoardArea> gameBoardAreaList)
        {
            if (gameBoardAreaList == null) throw new ArgumentNullException("GameBoardAreaList");

            _gameBoardAreaList = gameBoardAreaList;

            _gameBoardAreaList[2].Area = "X";
        }

        public IList<GameBoardArea> GameBoardAreaList => _gameBoardAreaList;
    }
}
