namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IGameService
{
    Task MakeAMoveAsync(List<IGameBoardArea> gameBoard, List<IPlayer> playerList, int areaId);
}