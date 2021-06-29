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
        public List<Player> LoadDefaultPlayerList()
        {
            return new List<Player>
            {
                new Player("X", "PlayerX", true, false),
                new Player("O", "PlayerO", false, true)
            };
        }

        public List<Player> LoadNewPlayerList()
        {
            return new List<Player>
            {
                new Player("X", "Michael", true, false),
                new Player("O", "Aimimax", false, false)
            };
        }

        public List<Player> LoadLastPlayerList()
        {
            return new List<Player>
            {
                new Player("X", "Horst", true, true){ Points = 5 },
                new Player("O", "Detlef", false, false){ Points = 17}
            };
        }

        public void StorePlayerList()
        {
            throw new NotImplementedException();
        }
    }
}
