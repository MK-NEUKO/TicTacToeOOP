using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract
{
    public interface IAI
    {
        void GetAMove();
        int AreaIDForX { get; }
        int AreaIDForO { get; }        
    }
}
