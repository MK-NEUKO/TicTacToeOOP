namespace NEUKO.TicTacToe.Core
{
    public interface IPlayerController
    {
        void ChangePlayer();
        string GiveCurrentToken();
        void GivePoints();
        IPlayer GiveCurrentPlayer();
        void ResetPlayers();
        int GameIsTie { get; }
    }
}
