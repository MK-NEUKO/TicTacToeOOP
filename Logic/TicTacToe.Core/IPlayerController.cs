namespace NEUKO.TicTacToe.Core
{
    public interface IPlayerController
    {
        void ChangePlayer();
        string GiveTheRightToken();
        void GivePoints();
        int GameIsTie { get; }
    }
}
