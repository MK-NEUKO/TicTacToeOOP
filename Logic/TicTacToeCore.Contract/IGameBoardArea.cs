namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IGameBoardArea
{
    int Id { get; set; }
    string? Token { get; set; }
    bool IsWinArea { get; set; }
    bool IsStartNewGameAnimation { get; set; }
    bool IsStartSaveGameAnimation { get; set; }
    bool IsInGame { get; set; }
}