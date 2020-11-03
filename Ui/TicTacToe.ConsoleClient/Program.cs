using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.ConsoleClient
{
    class Program
    {
        // TODO: Namenskonventionen .NET 
        // eigene Bezeichner dementsprechen Überarbeiten. 

        // Datenkappselung: Verwendet man innerhalb der Klasse das Feld oder die Eigenschaft?
        // Lamda Ausdrücke nachschlagen, lernen!
        
        static void Main(string[] args)
        {
            List<GameBoardArea> boardAreaList = new List<GameBoardArea>();
            List<GameBoardArea> evaluationList = new List<GameBoardArea>();
            for (int areaID = 0; areaID < 9; areaID++)
            {
                boardAreaList.Add(new GameBoardArea(areaID));
            }
            for (int areaID = 0; areaID < 9; areaID++)
            {
                evaluationList.Add(new GameBoardArea(areaID));
            }
            GameBoard board = new GameBoard(boardAreaList);
            AI aimimax = new AI(evaluationList, board);
            Player playerX = new Player() { InAction = true };
            Player playerO = new Player();
            PlayerController playerController = new PlayerController(playerX, playerO, aimimax);
            ConsoleView view = new ConsoleView(boardAreaList, board, playerX, playerO, aimimax);
            TicTacToe tictactoe = new TicTacToe(board, playerController, playerX, playerO, view, aimimax);

            tictactoe.Play();
        }
    }
}
