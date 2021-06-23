using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract
{
    public interface IGamePlay
    {
        void MakeAMove(int areaID);
        void MakePossibleNextMove();
    }
}
