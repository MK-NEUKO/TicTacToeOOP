using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerViewModel
{
    string Name { get; set; }
    string Token { get; set; }
    bool IsWinner { get; set; }
    bool IsHuman { get; set; }
    bool IsAi { get; set; }
    bool IsPlayersTurn { get; set; }
    int Points { get; set; }
    PlayerData PlayerData { get; set; }
    int GiveTokenPosition(List<string> tokenList, int clickedAreaId);
    void SetPoint();
}