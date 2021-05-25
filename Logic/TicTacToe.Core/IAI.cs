using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore
{
    public interface IAI
    {
        void GetAMove();
        int AreaIDForX { get; }
        int AreaIDForO { get; }        
    }
}
