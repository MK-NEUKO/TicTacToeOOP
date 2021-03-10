﻿using NEUKO.TicTacToe.Core;
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

            //Composition root
            var gameBoardAreaList = new List<GameBoardArea>();
            var gameBoard = new GameBoardFactory(gameBoardAreaList).CreateGameBoard();

            var playerX = new Player("PlayerX", true, true);
            var playerO = new Player("PlayerO", false, false);

            var aimimax = new AI(gameBoard, playerX, playerO);
            
            var playerController = new PlayerController(playerX, playerO, gameBoard, aimimax);

            var placeATokenCommands = new List<PlaceATokenCommand>();

            var gameInfoViewModel = new GameInfoViewModel(playerX, playerO);            

            var gameBoardViewModel = new GameBoardViewModel(gameBoard.BoardAreaList, placeATokenCommands);

            var mainWindowViewModel = new MainWindowViewModel(gameBoardViewModel, gameInfoViewModel, gameBoard, playerController);

            new PlaceATokenCommandFactory(placeATokenCommands, mainWindowViewModel).CreateCommands();
            



            MainWindow.DataContext = mainWindowViewModel;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}
