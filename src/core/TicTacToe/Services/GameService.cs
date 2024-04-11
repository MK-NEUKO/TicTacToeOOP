using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayerService _playerService;

        public GameService(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task MakeAMoveAsync(List<IGameBoardArea> gameBoard, List<IPlayer> playerList, int areaId)
        {
            await Task.Run(() =>
            {
                SetToken(gameBoard, playerList, areaId);
                _playerService.ChangeCurrentPlayer(playerList);
            });
        }


        private void SetToken(List<IGameBoardArea> gameBoard, List<IPlayer> playerList, int areaId)
        {
            var currentPlayer = playerList.FirstOrDefault(p => p.IsCurrentPlayer == true);
            if (currentPlayer == null) return;
            if(gameBoard[areaId].IsOccupied) return;
            gameBoard[areaId].Token = currentPlayer.Token;
            gameBoard[areaId].IsOccupied = true;
        }
    }
}