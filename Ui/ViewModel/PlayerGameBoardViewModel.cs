using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    [INotifyPropertyChanged]
    public partial class PlayerGameBoardViewModel
    {
        private List<PlayerGameBoardAreaViewModel> _areas;

        public PlayerGameBoardViewModel(List<PlayerGameBoardAreaViewModel> areas)
        {
            _areas = areas.ToList();
        }

        public List<PlayerGameBoardAreaViewModel> Areas { get => _areas; }
    }


    
}
