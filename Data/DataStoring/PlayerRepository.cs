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
                new Player("X", "Default-X", true, false){ Points = 66 },
                new Player("O", "Default-O", false, true){ Points = 4 }
            };
        }

        public List<Player> LoadNewPlayerList()
        {
            return new List<Player>
            {
                new Player("X", "new_Michael", true, false){ Points = 2 },
                new Player("O", "new_Aimimax", false, false){ Points = 12 }
            };
        }

        public List<Player> LoadLastPlayerList()
        {
            return new List<Player>
            {
                new Player("X", "last_Horst", true, true){ Points = 5 },
                new Player("O", "last_Detlef", false, true){ Points = 17}
            };
        }

        public void StorePlayerList()
        {
            throw new NotImplementedException();
        }
    }
}
