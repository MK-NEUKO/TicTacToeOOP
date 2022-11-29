using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore;
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
            var gameBoard = new GameBoardManagerManager(gameBoardRepository);

            var playerRepository = new PlayerRepository();
            var aimimax = new AI(gameBoardRepository, playerRepository, gameBoard);
            
            var playerController = new PlayerController(playerRepository, gameBoard, aimimax);

            var gamePlay = new GamePlay(gameBoard, playerController, aimimax);

            

            MainWindow.DataContext = mainWindowViewModel;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}
