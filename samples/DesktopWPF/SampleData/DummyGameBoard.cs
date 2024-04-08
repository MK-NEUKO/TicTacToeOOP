namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.SampleData;

public class DummyGameBoard
{
    public DummyGameBoard()
    {
        GameBoardAreas = CreateAreas();
    }

    private List<DummyGameBoardArea>? CreateAreas()
    {
        var areas = new List<DummyGameBoardArea>();

        for (int i = 0; i < 9; i++)
        {
            areas.Add(new DummyGameBoardArea
            {
                Id = i,
                Token = "X",
                IsWinArea = false,
                IsOccupied = false
            });
        }

        return areas;
    }

    public List<DummyGameBoardArea> GameBoardAreas { get; set; }
}