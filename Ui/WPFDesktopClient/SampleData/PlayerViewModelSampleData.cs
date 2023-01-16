namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class PlayerViewModelSampleData
    {
        public string? Name { get; set; }
        public string? Token { get; set; }
        public bool IsHuman { get; set; }
        public bool IsAi { get; set; }
        public bool IsPlayersTurn { get; set; }
        public bool IsWinner { get; set; }
        public int Points { get; set; }
    }
}