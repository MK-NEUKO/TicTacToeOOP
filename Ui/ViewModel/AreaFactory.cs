using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    public class AreaFactory : IAreaFactory
    {
        public List<PlayerGameBoardAreaViewModel> CreateAreas()
        {
            const int numberOfAreas = 9;
            var areaList = new List<PlayerGameBoardAreaViewModel>();
            for (int id = 0; id < numberOfAreas; id++)
            {
                areaList.Add(new PlayerGameBoardAreaViewModel(id));
            }

            return areaList;
        }
    }
}
