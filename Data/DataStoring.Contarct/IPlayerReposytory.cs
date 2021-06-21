using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelKoch.TicTacToe.Data.DataStoring.Contarct
{
    public interface IPlayerReposytory
    {
        List<Player> LoadDefaultPlayerList();
        List<Player> LoadLastPlayerList();
        List<Player> LoadNewPlayerList();
        void StorePlayerList();
    }
}
