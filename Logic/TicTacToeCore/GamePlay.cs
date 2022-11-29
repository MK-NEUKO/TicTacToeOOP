using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore
{
    public class GamePlay : IGamePlay
    {
        private readonly IGameBoardManager _gameBoardManager;
        private readonly IPlayerController _playerController;
        private readonly IAI _aimiamx;

        public GamePlay(IGameBoardManager gameBoardManager, IPlayerController playerController, IAI aimiamx)
        {
            _gameBoardManager = gameBoardManager ?? throw new ArgumentNullException(nameof(gameBoardManager));
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
            _aimiamx = aimiamx ?? throw new ArgumentNullException(nameof(aimiamx));
        }

        public void MakePossibleNextMove()
        {
            var currentPlayer = _playerController.GiveCurrentPlayer();
            var isNextMovePossible = !(_gameBoardManager.IsPlayerXWinner || _gameBoardManager.IsPlayerOWinner || _gameBoardManager.IsGameTie);
            if (currentPlayer.IsAI && isNextMovePossible)
            {
                _aimiamx.GetAMove(currentPlayer);
                MakeAMove(_aimiamx.AreaIDForCurrentPlayer);
            }
        }

        public void EnterAIBattleLoop()
        {          
            while (!_gameBoardManager.IsPlayerXWinner && !_gameBoardManager.IsPlayerOWinner && !_gameBoardManager.IsGameTie)
            {
                var currentPlayer = _playerController.GiveCurrentPlayer();
                _aimiamx.GetAMove(currentPlayer);
                MakeAMove(_aimiamx.AreaIDForCurrentPlayer);
            }
            _playerController.SetWinner();
            _playerController.GivePoints();
        }

        public void MakeAMove(int areaID)
        {
            _gameBoardManager.PlaceAToken(areaID, _playerController.GiveCurrentToken());
            _gameBoardManager.CheckGameBoardState();

            var isGameDecided = _gameBoardManager.IsPlayerXWinner || _gameBoardManager.IsPlayerOWinner || _gameBoardManager.IsGameTie;
            if (isGameDecided)
            {
                _playerController.SetWinner();
                _playerController.GivePoints();
            }
            else
            {
                _playerController.ChangePlayer();
            }
        }

        public void SetupNextGame()
        {
            if (_gameBoardManager.IsGameTie)
            {
                _playerController.ChangePlayer();
            }
            _gameBoardManager.ResetGameBoard();
            _playerController.ResetPlayers();
        }

        public bool IsAIBattle()
        {
            return _playerController.PlayerX.IsAI && _playerController.PlayerO.IsAI;
        }
    }
}
