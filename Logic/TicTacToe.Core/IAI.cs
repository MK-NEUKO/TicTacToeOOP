using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public interface IAI
    {
        void GetAMove();
        int AreaIDForX { get; }
        int AreaIDForO { get; }        
    }
}
