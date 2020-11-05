using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public interface IAI
    {
        void ShowAITest();
        double GetAreaIDForX();
        double GetAreaIDForO();
        int AreaIDForX { get; }
        int AreaIDForO { get; }
        int MaximumDepth { get; set; }
    }
}
