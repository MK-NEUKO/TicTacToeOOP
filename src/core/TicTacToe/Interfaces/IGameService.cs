namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IGameService
{
    Task MakeAMoveAsync(IGameBoard gameBoard, List<IPlayer> playerList, int areaId);
}