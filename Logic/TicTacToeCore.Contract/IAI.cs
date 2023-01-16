using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract
{
    public interface IAI
    {
        void GetAMove(Player currentPlayer);
        int AreaIDForCurrentPlayer { get; }
        int AreaIDForO { get; }        
    }
}
