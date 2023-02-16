using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerGameBoardViewModel
{
    Task<bool> TrySetTokenTaskAsync(string token, int areaId);

    IReadOnlyList<IPlayerGameBoardAreaViewModel> Areas { get; }
    
    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="PlayerGameBoardViewModel.StoryboardCompleted"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand GameBoardStartAnimationCompletedCommand { get; }

    void AnimateWinAreas(List<bool> resultWinAreas);

    void StartGameStartAnimation();

    List<string> GetCurrentTokenList();
}
