using CommunityToolkit.Mvvm.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerGameBoardViewModel
{
    Task<bool> TrySetTokenTaskAsync(string token, bool isHuman, int areaId);
    IReadOnlyList<IPlayerGameBoardAreaViewModel> Areas { get; }
    IRelayCommand GameBoardStartAnimationCompletedCommand { get; }
    void AnimateWinAreas(List<bool> resultWinAreas);
    void StartGameStartAnimation();
    List<string> GetCurrentTokenList();
}
