using NEUKO.TicTacToe.Core;
using System.Collections.Generic;

namespace NEUKO.TicTacToe.ConsoleClient
{
    class Program
    {
        // TODO: Namenskonventionen .NET 
        // eigene Bezeichner dementsprechen Überarbeiten. 
        
        static void Main(string[] args)
        {
            List<GameBoardArea> boardAreaList = new List<GameBoardArea>();
            for (int areaId = 0; areaId < 9; areaId++)
            {
                boardAreaList.Add(new GameBoardArea(areaId));
            }
            GameBoard board = new GameBoard(boardAreaList);
            Player playerX = new Player() { InAction = true };
            Player playerO = new Player();
            PlayerController playerController = new PlayerController(playerX, playerO);
            ConsoleView view = new ConsoleView(boardAreaList, playerX, playerO);
            TicTacToe tictactoe = new TicTacToe(board, playerController, playerX, playerO, view);

            tictactoe.Play();
        }
    }
}
