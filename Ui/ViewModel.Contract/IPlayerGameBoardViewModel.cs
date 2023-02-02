using CommunityToolkit.Mvvm.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerGameBoardViewModel
{
    List<IPlayerGameBoardAreaViewModel> Areas { get; }
    
    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="PlayerGameBoardViewModel.StoryboardCompleted"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand GameBoardStartAnimationCompletedCommand { get; }
}
