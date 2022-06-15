namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses
{
    public interface IGameBoardArea
    {
        string Area { get; set; }
        int AreaID { get; }
        int ColumnIndex { get; set; }
        bool IsInGame { get; set; }
        bool IsOccupied { get; set; }
        bool IsStartLastGameAnimation { get; set; }
        bool IsStartNewGameAnimation { get; set; }
        bool IsWinArea { get; set; }
        int RowIndex { get; set; }
    }
}