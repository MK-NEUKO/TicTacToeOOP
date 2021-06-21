using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class MainWindowViewModelSampleDate : IMainWindowViewModel
    {
        public IGameBoardViewModel GameBoardViewModel => throw new NotImplementedException();

        public IGameInfoViewModel GameInfoViewModel => throw new NotImplementedException();

        public ICommand InitializeGameCommand => throw new NotImplementedException();
    }
}
