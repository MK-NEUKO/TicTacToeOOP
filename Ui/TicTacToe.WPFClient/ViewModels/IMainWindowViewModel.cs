using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public interface IMainWindowViewModel
    {
        IGameBoardViewModel GameBoardViewModel { get; }
        IGameInfoViewModel GameInfoViewModel { get; }
        void PlayAMove(int areaID);       
    }
}
