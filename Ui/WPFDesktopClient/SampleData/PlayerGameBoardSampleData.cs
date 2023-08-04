using System.Collections.Generic;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData;

public class PlayerGameBoardSampleData
{
    public PlayerGameBoardSampleData()
    {
        Areas = new List<PlayerGameBoardAreaSampleData>()
        {
            new PlayerGameBoardAreaSampleData(0) {Token = "X", },
            new PlayerGameBoardAreaSampleData(1) {Token = "O", },
            new PlayerGameBoardAreaSampleData(2) {Token = "X", },
            new PlayerGameBoardAreaSampleData(3) {Token = "O", },
            new PlayerGameBoardAreaSampleData(4) {Token = "X", },
            new PlayerGameBoardAreaSampleData(5) {Token = "O", },
            new PlayerGameBoardAreaSampleData(6) {Token = "X", },
            new PlayerGameBoardAreaSampleData(7) {Token = "O", },
            new PlayerGameBoardAreaSampleData(8) {Token = "X", },
        };
    }

    public List<PlayerGameBoardAreaSampleData> Areas { get; set; }
}