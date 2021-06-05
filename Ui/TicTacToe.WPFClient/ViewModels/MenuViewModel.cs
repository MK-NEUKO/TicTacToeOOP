﻿using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{

    public class MenuViewModel : IMenuViewModel
    {
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;
        private readonly IPlayerController _playerController;
        private IList<Player> _playerDataOnTheRibbon;
        private bool _userChoosesStartNewGame;
        private bool _userChoosesStartLastGame;


        public ICommand StartGameCommand { get; }
        public ICommand StartNewGameCommand { get; }
        public ICommand StartLastGameCommand { get; }
        public IList<Player> PlayerDataOnTheRibbon { get => _playerDataOnTheRibbon; set => _playerDataOnTheRibbon = value; }
        public bool UserChoosesStartNewGame { get => _userChoosesStartNewGame; set => _userChoosesStartNewGame = value; }
        public bool UserChoosesStartLastGame { get => _userChoosesStartLastGame; set => _userChoosesStartLastGame = value; }

        public MenuViewModel(IGameBoardViewModel gameBoardViewModel,
                             IGameInfoViewModel gameInfoViewModel,
                             IPlayerController playerController)
        {
            _gameBoardViewModel = gameBoardViewModel ?? throw new ArgumentNullException(nameof(gameBoardViewModel));
            _gameInfoViewModel = gameInfoViewModel ?? throw new ArgumentNullException(nameof(gameInfoViewModel));
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
            _playerDataOnTheRibbon = new List<Player>
            {
                new Player(){Name = "PlayerX"},
                new Player(){Name = "PlayerO"}
            };

            StartGameCommand = new RelayCommand(StartGame, CanStartGame);
            StartNewGameCommand = new RelayCommand(UserChoosesStartNewGameCommand, CanUserChoosesStartNewGameCommand);
            StartLastGameCommand = new RelayCommand(UserChoosesStartLastGameCommand, CanUserChoosesStartLastGameCommand);
        }

        private bool CanUserChoosesStartLastGameCommand()
        {
            return true;
        }

        private void UserChoosesStartLastGameCommand(object obj)
        {
            _userChoosesStartLastGame = true;
            _userChoosesStartNewGame = false;
        }

        private bool CanUserChoosesStartNewGameCommand()
        {
           return true;
        }

        private void UserChoosesStartNewGameCommand(object obj)
        {
            _userChoosesStartNewGame = true;
            _userChoosesStartLastGame = false;
        }

        private bool CanStartGame()
        {
            return true;
        }

        private void StartGame(object obj)
        {
            _gameBoardViewModel.ShowStartAnimation();
        }

    }
}
