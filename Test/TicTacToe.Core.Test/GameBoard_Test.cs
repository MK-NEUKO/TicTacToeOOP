using Microsoft.VisualStudio.TestTools.UnitTesting;
using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace TicTacToe.Core.Test
{
    [TestClass]
    public class GameBoard_Test
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

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
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
        }

        [DataTestMethod]
        [DataRow(new string[9]{ "X", "X", "O",
                                " ", "X", "O",
                                "O", " ", "X" })]

        [DataRow(new string[9]{ "O", "X", "X",
                                " ", "X", "O",
                                "X", " ", "O" })]
        public void CheckWinConstallation_GameBoard(string[] testGameBoard)
        {
            List<GameBoardArea> boardAreaList = new List<GameBoardArea>();
            for (int areaID = 0; areaID < 9; areaID++)
            {
                boardAreaList.Add(new GameBoardArea(areaID));
            }
            GameBoard board = new GameBoard(boardAreaList);

            for (int index = 0; index < testGameBoard.Length; index++)
            {
                boardAreaList[index].Area = testGameBoard[index];
            }
            
            board.CheckGameBoardState();

            Assert.IsTrue(board.PlayerXIsWinner);
            Assert.IsFalse(board.PlayerOIsWinner);
            Assert.IsFalse(board.GameIsTie);
            TestContext.WriteLine($"{testGameBoard[0]}|{testGameBoard[1]}|{testGameBoard[2]}");
            TestContext.WriteLine($"{testGameBoard[3]}|{testGameBoard[4]}|{testGameBoard[5]}");
            TestContext.WriteLine($"{testGameBoard[6]}|{testGameBoard[7]}|{testGameBoard[8]}");
        }

        [TestCleanup] 
        public void TestCleanUp()
        {
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }
    }
}
