using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;

namespace NEUKO.TicTacToe.WPFClient
{
    public interface IGameInfoViewModel
    {
        public Player PlayerX { get; set; }
        public Player PlayerO { get; set; }
        public int NumberOfTie { get; set; }
    }
}
