namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.SampleData;

internal class GameInfoBoardSampleData
{
    public Player PlayerX { get; set; }
    public Player PlayerO { get; set; }
    public string FirstInfoRowLabel { get; set; }
    public List<string> InfoRowLabels { get; set; } = new List<string>{"Info-Row - 1", "Info-Row - 2"};
    public List<string> InfoRowValues { get; set; } = new List<string> { "any Value", "another Value" };
}


internal class Player
{
    public string Name { get; set; }
    public string Token { get; set; }
    public bool IsHuman { get; set; }
    public bool IsAi { get; set; }
    public bool IsOnTheMove { get; set; }
    public bool IsWinner { get; set; }
    public int Score { get; set; }
    public AiDifficultyLevel AiDifficultyLevel { get; set; }
}

internal enum AiDifficultyLevel
{
    Easy,
    Medium,
    Hard
}