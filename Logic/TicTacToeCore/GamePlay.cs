using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore
{
    public class GamePlay : IGamePlay
    {
        private readonly IGameBoard _gameBoard;
        private readonly IPlayerController _playerController;
        private readonly IAI _aimiamx;

        public GamePlay(IGameBoard gameBoard, IPlayerController playerController, IAI aimiamx)
        {
            _gameBoard = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
            _aimiamx = aimiamx ?? throw new ArgumentNullException(nameof(aimiamx));
        }

        public void MakePossibleNextMove()
        {
            var currentPlayer = _playerController.GiveCurrentPlayer();
            var isNextMovePossible = !(_gameBoard.IsPlayerXWinner || _gameBoard.IsPlayerOWinner || _gameBoard.IsGameTie);

            if (currentPlayer.IsAI && isNextMovePossible)
            {
                _aimiamx.GetAMove(currentPlayer);
                MakeAMove(_aimiamx.AreaIDForO);
            }
        }

        public void MakeAMove(int areaID)
        {
            _gameBoard.PlaceAToken(areaID, _playerController.GiveCurrentToken());
            _gameBoard.CheckGameBoardState();
            _playerController.GivePoints();
            _playerController.SetWinner();
            _playerController.ChangePlayer();
        }
    }
}
