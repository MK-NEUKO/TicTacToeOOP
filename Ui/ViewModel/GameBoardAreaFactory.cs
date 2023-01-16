namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public class GameBoardAreaFactory : IGameBoardAreaFactory
{
    public List<IPlayerGameBoardAreaViewModel> CreateAreas()
    {
        const int numberOfAreas = 9;
        var areaList = new List<IPlayerGameBoardAreaViewModel>();
        for (int id = 0; id < numberOfAreas; id++)
        {
            areaList.Add(new PlayerGameBoardAreaViewModel(id));
        }

        return areaList;
    }
}