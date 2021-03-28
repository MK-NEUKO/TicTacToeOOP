using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NEUKO.TicTacToe.WPFClient
{
    public class GameBoardViewModel : ViewModelBase, IGameBoardViewModel
    {
        private readonly IList<GameBoardArea> _gameBoardAreaList;
        private readonly IList<PlaceATokenCommand> _placeATokenCommands;

        public ICommand StartAnimationCompletedCommand { get; }

        public GameBoardViewModel(IList<GameBoardArea> gameBoardAreaList, IList<PlaceATokenCommand> placeATokenCommands)
        {
            if (gameBoardAreaList == null) throw new ArgumentNullException("GameBoardAreaList");
            if (placeATokenCommands == null) throw new ArgumentNullException("PlaceATokenCommands");

            _gameBoardAreaList = gameBoardAreaList;
            _placeATokenCommands = placeATokenCommands;

            StartAnimationCompletedCommand = new RelayCommand(StartAnimationCompleted, CanStartAnimationCompleted);
        }

        private bool CanStartAnimationCompleted()
        {
            return true;
        }

        private void StartAnimationCompleted(object obj)
        {
            foreach (var area in _gameBoardAreaList)
            {
                area.Area = "X";
            }
        }

        public IList<GameBoardArea> GameBoardAreaList => _gameBoardAreaList;

        public IList<PlaceATokenCommand> PlaceATokenCommands => _placeATokenCommands;
    }
}
