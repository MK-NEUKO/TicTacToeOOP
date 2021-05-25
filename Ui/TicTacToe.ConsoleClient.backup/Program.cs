using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.ConsoleClient
{
    class Program
    {
        // TODO Namenskonventionen .NET 
        // eigene Bezeichner dementsprechen Überarbeiten. 

        // Datenkappselung: Verwendet man innerhalb der Klasse das Feld oder die Eigenschaft?
        // Lamda Ausdrücke nachschlagen, lernen!

       
        static void Main(string[] args)
        {
            #region Objects of the API TicTacToe.Core
            var boardAreaList = new List<GameBoardArea>();
            var board = new GameBoardFactory(boardAreaList).CreateGameBoard();
            //List<GameBoardArea> evaluationList = new List<GameBoardArea>();           
            //for (int areaID = 0; areaID < 9; areaID++)
            //{
            //    evaluationList.Add(new GameBoardArea(areaID));
            //}           
            Player playerX = new Player() { Name = "PlayerX", InAction = true };
            Player playerO = new Player() { Name = "PlayerO" };
            AI aimimax = new AI(/*evaluationList,*/ board, playerX, playerO);
            PlayerController playerController = new PlayerController(playerX, playerO, board, aimimax);
            #endregion

            #region Objects of the ConsoleClient
            QueryValidation validation = new QueryValidation(boardAreaList);
            QueryDisplay queryDisplay = new QueryDisplay();
            QueryConverter inputConverter = new QueryConverter();
            QueryView query = new QueryView(boardAreaList, board, playerX, playerO, playerController, aimimax, validation, queryDisplay, inputConverter);
            DisplayView display = new DisplayView(boardAreaList, board, playerX, playerO, playerController, aimimax);
            TicTacToe tictactoe = new TicTacToe(board, playerController, playerX, playerO, display, query, aimimax);
            #endregion


            tictactoe.Play();
        }
    }
}
