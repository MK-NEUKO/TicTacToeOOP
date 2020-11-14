namespace NEUKO.TicTacToe.Core
{
    public interface IPlayerController
    {
        void ChangePlayer();
        string GiveTheRightToken();
        void GivePoints();
        IPlayer GivePlayerInAction();
        int GameIsTie { get; }
    }
}
