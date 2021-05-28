using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract
{
    public interface IPlayerController
    {
        void ChangePlayer();
        string GiveCurrentToken();
        void GivePoints();
        Player GiveCurrentPlayer();
        void ResetPlayers();
        void SetWinner();
        int GameIsTie { get; }
    }
}
