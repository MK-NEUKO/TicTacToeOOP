using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public class GameBoardViewModel : ObservableObject, IGameBoard
{
    private bool _isUndecided;

    public GameBoardViewModel()
    {
        
        InitializeAreas();
    }

    private void InitializeAreas()
    {
        Areas =
        [
            new GameBoardAreaViewModel { Id = 0, Token = "X"},
            new GameBoardAreaViewModel { Id = 1, Token = "O"},
            new GameBoardAreaViewModel { Id = 2 },
            new GameBoardAreaViewModel { Id = 3 },
            new GameBoardAreaViewModel { Id = 4 },
            new GameBoardAreaViewModel { Id = 5 },
            new GameBoardAreaViewModel { Id = 6 },
            new GameBoardAreaViewModel { Id = 7 },
            new GameBoardAreaViewModel { Id = 8 }
        ];
    }

    public List<IGameBoardArea> Areas { get; set; }

    public bool IsUndecided
    {
        get => _isUndecided;
        set => SetProperty(ref _isUndecided, value);
    }
}