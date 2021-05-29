using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelKoch.TicTacToe.Data.DataStoring
{
    public class PlayerRepository : IPlayerReposytory
    {
        public IList<Player> PlayerList =>
            new List<Player>
            {
                new Player("PlayerX", true, true),
                new Player("PlyaerO", false, false)
            };
    }
}
