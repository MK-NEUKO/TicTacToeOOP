namespace NEUKO.TicTacToe.Core
{
    public interface IPlayerController
    {
        void ChangePlayer();
        string GiveCurrentToken();
        void GivePoints();
        IPlayer GiveCurrentPlayer();
        void ResetPlayers();
        void SetWinner();
        int GameIsTie { get; }
    }
}
