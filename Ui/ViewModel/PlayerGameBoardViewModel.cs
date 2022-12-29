using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    public class PlayerGameBoardViewModel
    {
        public PlayerGameBoardViewModel()
        {
            Areas = CreateAreas();
        }

        private static List<PlayerGameBoardAreaViewModel> CreateAreas()
        {
            var areas = new List<PlayerGameBoardAreaViewModel>();
            for (int id = 0; id < 9; id++)
            {
                areas.Add(new PlayerGameBoardAreaViewModel(id));
                areas[id].Token = "X";
            }
            return areas;
        }

        public List<PlayerGameBoardAreaViewModel> Areas { get; }
    }
}
