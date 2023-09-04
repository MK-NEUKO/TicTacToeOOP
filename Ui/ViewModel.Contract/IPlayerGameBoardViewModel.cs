using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerGameBoardViewModel
{
    Task<bool> TrySetTokenTaskAsync(string token, bool isHuman, int areaId);
    IReadOnlyList<IPlayerGameBoardAreaViewModel> Areas { get; }
    PlayerGameBoardData PlayerGameBoardData { get; }
    IRelayCommand GameBoardStartAnimationCompletedCommand { get; }
    void AnimateWinAreas(List<bool> resultWinAreas);
    void StartGameStartAnimation(bool isNewGame);
    List<string> GetCurrentTokenList();
}
