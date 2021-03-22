using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NEUKO.TicTacToe.WPFClient
{

    public class MenuViewModel : IMenuViewModel
    {
        public ICommand StartGameCommand { get; }
        public MenuViewModel()
        {
            StartGameCommand = new RelayCommand(StartGame, CanStartGame);
        }

        private void StartGame(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanStartGame()
        {
            throw new NotImplementedException();
        }        
    }
}
