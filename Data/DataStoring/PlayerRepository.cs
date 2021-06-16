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
        public List<Player> LoadNewPlayerList()
        {
            return new List<Player>
            {
                new Player("PlayerX", true, true),
                new Player("PlyaerO", false, false)
            };
        }

        public List<Player> LoadLastPlayerList()
        {
            return new List<Player>
            {
                new Player("Horst", true, true){ Points = 5 },
                new Player("Detlef", false, false){ Points = 17}
            };
        }

        public void StorePlayerList()
        {
            throw new NotImplementedException();
        }
    }
}
