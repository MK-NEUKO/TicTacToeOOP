using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class EvaluationResult : IEvaluationResult
{
    public EvaluationResult()
    {
        WinAreas = CreateList();
    }

    private static List<bool> CreateList()
    {
        var list = new List<bool>();
        for (var i = 0; i < 9; i++)
        {
            list.Add(false);
        }
        return list;
    }

    public List<bool> WinAreas { get; set; }
    public bool IsWinner { get; set; }
    public bool IsLoser { get; set; }
    public bool IsDraw { get; set; }
    public bool IsOpen { get; set; }
}