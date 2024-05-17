using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayerService _playerService;
        private readonly IGameEvaluator _gameEvaluator;

        public GameService(IPlayerService playerService, IGameEvaluator gameEvaluator)
        {
            _playerService = playerService;
            _gameEvaluator = gameEvaluator;
        }

        public async Task MakeAMoveAsync(IGameBoard gameBoard, List<IPlayer> playerList, int areaId)
        {
            await Task.Run(() =>
            {
                SetToken(gameBoard, playerList, areaId);
                _gameEvaluator.EvaluateGame(gameBoard, playerList);
                _playerService.ChangeCurrentPlayer(playerList);
            });
        }


        private void SetToken(IGameBoard gameBoard, List<IPlayer> playerList, int areaId)
        {
            var currentPlayer = playerList.FirstOrDefault(p => p.IsCurrentPlayer == true);
            if (currentPlayer == null) return;
            if(gameBoard.Areas[areaId].IsOccupied) return;
            gameBoard.Areas[areaId].Token = currentPlayer.Token;
            gameBoard.Areas[areaId].IsOccupied = true;
        }
    }
}