using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerGameBoardViewModel
{
    bool TrySetToken(string token, int areaId);

    List<IPlayerGameBoardAreaViewModel> Areas { get; }
    
    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="PlayerGameBoardViewModel.StoryboardCompleted"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand GameBoardStartAnimationCompletedCommand { get; }

    List<string> GetTokenList();

    void AnimateWinAreas(List<bool> resultWinAreas);
}
