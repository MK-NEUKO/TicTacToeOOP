namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses
{
    public interface IPlayer
    {
        bool InAction { get; set; }
        bool IsAI { get; set; }
        bool IsHuman { get; set; }
        bool IsWinner { get; set; }
        int MaximumDepth { get; set; }
        string Name { get; set; }
        string PlayerID { get; }
        int Points { get; set; }
    }
}