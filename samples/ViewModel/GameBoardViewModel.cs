using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public class GameBoardViewModel : ObservableObject, IGameBoard
{
    public GameBoardViewModel()
    {
        
        InitializeGameBoardAreas();
    }

    private void InitializeGameBoardAreas()
    {
        GameBoardAreas =
        [
            new GameBoardAreaViewModel { Id = 0 },
            new GameBoardAreaViewModel { Id = 1 },
            new GameBoardAreaViewModel { Id = 2 },
            new GameBoardAreaViewModel { Id = 3 },
            new GameBoardAreaViewModel { Id = 4 },
            new GameBoardAreaViewModel { Id = 5 },
            new GameBoardAreaViewModel { Id = 6 },
            new GameBoardAreaViewModel { Id = 7 },
            new GameBoardAreaViewModel { Id = 8 }
        ];
    }

    public List<IGameBoardArea> GameBoardAreas { get; set; }
}