using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract
{
    public interface IAI
    {
        void GetAMove(Player currentPlayer);
        int AreaIDForX { get; }
        int AreaIDForO { get; }        
    }
}
