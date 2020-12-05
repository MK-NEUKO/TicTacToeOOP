using Microsoft.VisualStudio.TestTools.UnitTesting;
using NEUKO.TicTacToe.Core;
using System.Collections.Generic;

namespace TicTacToe.Core.Test
{
    [TestClass]
    public class GameBoard_Test
    {
        

        [TestMethod]
        public void WinConstellationOne_Test()
        {
            List<GameBoardArea> boardAreaList = new List<GameBoardArea>();           
            for (int areaID = 0; areaID < 9; areaID++)
            {
                boardAreaList.Add(new GameBoardArea(areaID));
            }           
            GameBoard board = new GameBoard(boardAreaList);

            boardAreaList[0].Area = "X";
            boardAreaList[1].Area = "X";
            boardAreaList[2].Area = "X";
            boardAreaList[3].Area = " ";
            boardAreaList[4].Area = " ";
            boardAreaList[5].Area = " ";
            boardAreaList[6].Area = " ";
            boardAreaList[7].Area = " ";
            boardAreaList[8].Area = " ";

            board.CheckGameBoardState();

            Assert.IsTrue(board.PlayerXIsWinner);
        }
    }
}
