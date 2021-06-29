using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using System.Collections.Generic;
using System.Windows;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Composition root           
            var gameBoardRepository = new GameBoardRepository();
            var gameBoard = new GameBoard(gameBoardRepository);

            var playerReposytory = new PlayerRepository();
            var aimimax = new AI(gameBoardRepository, playerReposytory, gameBoard);
            
            var playerController = new PlayerController(playerReposytory, gameBoard, aimimax);

            var gamePlay = new GamePlay(gameBoard, playerController, aimimax);

            var gameInfoViewModel = new GameInfoViewModel(playerController);            

            var gameBoardViewModel = new GameBoardViewModel(gameBoard, gamePlay);

            var menuViewModel = new MenuViewModel(gameBoardViewModel, gameInfoViewModel, playerController);

            var mainWindowViewModel = new MainWindowViewModel(menuViewModel, gameBoardViewModel, gameInfoViewModel, gamePlay);

            MainWindow.DataContext = mainWindowViewModel;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}
