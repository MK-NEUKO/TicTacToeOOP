﻿using NEUKO.TicTacToe.Core;
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
            PlayerController playerController = new PlayerController(playerX, playerO, board, aimimax);
            QueryView query = new QueryView(boardAreaList, board, playerX, playerO, aimimax);
            DisplayView display = new DisplayView(boardAreaList, board, playerX, playerO, playerController, aimimax);           
            TicTacToe tictactoe = new TicTacToe(board, playerController, playerX, playerO, display, query, aimimax);

            tictactoe.Play();
        }
    }
}
