using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    public interface IPlayerGameBoardViewModel
    {
        List<PlayerGameBoardAreaViewModel> Areas { get; }
    }

    public class PlayerGameBoardViewModel : IPlayerGameBoardViewModel
    {
        public PlayerGameBoardViewModel(IAreaFactory areaFactory)
        {
            Areas = areaFactory.CreateAreas();
        }

        public List<PlayerGameBoardAreaViewModel> Areas { get; }
    }
}
