using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract
{
    public interface IPlayerController
    {
        Player PlayerX { get; set; }
        Player PlayerO { get; set; }
        void ChangePlayer();
        string GiveCurrentToken();
        void GivePoints();
        Player GiveCurrentPlayer();
        void ResetPlayers();
        void SetWinner();
        int GameIsTie { get; }
    }
}
