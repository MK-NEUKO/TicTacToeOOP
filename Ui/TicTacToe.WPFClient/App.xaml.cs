using NEUKO.TicTacToe.Core;
using System.Collections.Generic;
using System.Windows;

namespace NEUKO.TicTacToe.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Composition root
            var gameBoardAreaList = new List<GameBoardArea>();
            var gameBoard = new GameBoardFactory(gameBoardAreaList).CreateGameBoard();

            var gameBoardViewModel = new GameBoardViewModel(gameBoard.BoardAreaList);

            var mainWindowViewModel = new MainWindowViewModel(gameBoardViewModel);

            MainWindow = new MainWindow { DataContext = mainWindowViewModel };
            MainWindow.Show();
        }
    }
}
