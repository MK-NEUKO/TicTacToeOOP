using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{

    public class MenuViewModel : ViewModelBase, IMenuViewModel
    {
        private readonly IGameBoardViewModel _gameBoardViewModel;
        private readonly IGameInfoViewModel _gameInfoViewModel;
        private readonly IPlayerController _playerController;
        private Player _playerX;
        private Player _playerO;

        public MenuViewModel(IGameBoardViewModel gameBoardViewModel,
                             IGameInfoViewModel gameInfoViewModel,
                             IPlayerController playerController)
        {
            _gameBoardViewModel = gameBoardViewModel ?? throw new ArgumentNullException(nameof(gameBoardViewModel));
            _gameInfoViewModel = gameInfoViewModel ?? throw new ArgumentNullException(nameof(gameInfoViewModel));
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));

            _playerX = new Player { Name = "PlayerX", IsAI = false, IsHuman = false};
            _playerO = new Player { Name = "PlayerX", IsAI = false, IsHuman = false};
            StartGameCommand = new RelayCommand(StartGameExecute, StartGameCanExecute);
            StartNewGameCommand = new RelayCommand(StartNewGameExecute, StartNewGameCanExecute);
            LoadLastGameCommand = new RelayCommand(LoadLastGameExecute, LoadLastGameCanExecute);
        }

        public ICommand StartGameCommand { get; }
        public ICommand StartNewGameCommand { get; }
        public ICommand LoadLastGameCommand { get; }
        
        public Player PlayerX 
        { 
            get => _playerX; 
            set
            {
                _playerX = value;
                OnPropertyChanged();
            } 
        }
        public Player PlayerO 
        { 
            get => _playerO;
            set
            {
                _playerO = value;
                OnPropertyChanged();
            }  
        }

        private bool StartNewGameCanExecute()
        {
            return true;
        }

        private void StartNewGameExecute(object obj)
        {
            throw new NotImplementedException("StartNewGameExecute");    
        }

        private bool LoadLastGameCanExecute()
        {
            return true;
        }

        private void LoadLastGameExecute(object obj)
        {
            _playerController.GetLastPlayerList();
            PlayerX = _playerController.PlayerX;
            PlayerO = _playerController.PlayerO;
        }

        private bool StartGameCanExecute()
        {
            return true;
        }

        private void StartGameExecute(object obj)
        {
            _gameBoardViewModel.ShowStartAnimation();
        }
    }
}
