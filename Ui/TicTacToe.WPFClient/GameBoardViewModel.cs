using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public class GameBoardViewModel : IGameBoardViewModel
    {
        private readonly IList<GameBoardArea> _gameBoardAreaList;
        private readonly IList<PlaceATokenCommand> _placeATokenCommands;

        public GameBoardViewModel(IList<GameBoardArea> gameBoardAreaList, IList<PlaceATokenCommand> placeATokenCommands)
        {
            if (gameBoardAreaList == null) throw new ArgumentNullException("GameBoardAreaList");
            if (placeATokenCommands == null) throw new ArgumentNullException("PlaceATokenCommands");

            _gameBoardAreaList = gameBoardAreaList;
            _placeATokenCommands = placeATokenCommands;
        }

        public IList<GameBoardArea> GameBoardAreaList => _gameBoardAreaList;

        public IList<PlaceATokenCommand> PlaceATokenCommands => _placeATokenCommands;
    }
}
