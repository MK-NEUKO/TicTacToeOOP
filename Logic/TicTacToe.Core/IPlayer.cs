namespace NEUKO.TicTacToe.Core
{
    public interface IPlayer
    {
        bool InAction { get; set; }
        bool IsHuman { get; set; }
        string Name { get; set; }
        int Points { get; set; }
    }
}
