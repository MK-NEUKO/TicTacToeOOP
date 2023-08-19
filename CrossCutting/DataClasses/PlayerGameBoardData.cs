namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses;

public class PlayerGameBoardData
{
    public PlayerGameBoardData()
    {
        AreasData = CreateAreas();
    }

    public List<PlayerGameBoardAreaData> AreasData { get; set; }

    private List<PlayerGameBoardAreaData> CreateAreas()
    {
        const int numberOfAreas = 9;
        var areaList = new List<PlayerGameBoardAreaData>();
        for (var i = 0; i < numberOfAreas; i++)
        {
            areaList.Add(new PlayerGameBoardAreaData());
            areaList[i].Id = i;
        }
        return areaList;
    }

}