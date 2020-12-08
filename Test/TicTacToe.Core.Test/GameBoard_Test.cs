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

        [DataTestMethod]
        [DataRow(new string[9]{ "X", "X", "X",
                                " ", "O", "O",
                                "O", " ", "X" })]

        [DataRow(new string[9]{ "O", " ", "X",
                                "X", "X", "X",
                                "O", " ", "O" })]

        [DataRow(new string[9]{ "O", "O", " ",
                                "X", "O", " ",
                                "X", "X", "X" })]

        [DataRow(new string[9]{ "X", "O", " ",
                                "X", "O", " ",
                                "X", "X", "O" })]

        [DataRow(new string[9]{ "O", "X", " ",
                                "O", "X", " ",
                                "X", "X", "O" })]

        [DataRow(new string[9]{ "O", "O", "X",
                                " ", "O", "X",
                                "X", " ", "X" })]

        [DataRow(new string[9]{ "X", "O", " ",
                                "X", "X", " ",
                                "O", "O", "X" })]

        [DataRow(new string[9]{ "X", "O", "X",
                                " ", "X", " ",
                                "X", "O", "O" })]
        public void CheckGameBoardState_AllWinConstellationsForPlayerX(string[] testGameBoard)
        {
            // Arange 
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
            
            // Act
            board.CheckGameBoardState();

            // Assert
            Assert.IsTrue(board.PlayerXIsWinner);
            Assert.IsFalse(board.PlayerOIsWinner);
            Assert.IsFalse(board.GameIsTie);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
            TestContext.WriteLine("TestGameBoard:");
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[0], testGameBoard[1], testGameBoard[2]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[3], testGameBoard[4], testGameBoard[5]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[6], testGameBoard[7], testGameBoard[8]);            
        }

        [DataTestMethod]
        [DataRow(new string[9]{ "O", "O", "O",
                                " ", "X", "X",
                                "X", " ", "O" })]

        [DataRow(new string[9]{ "X", " ", "X",
                                "O", "O", "O",
                                "O", " ", "X" })]

        [DataRow(new string[9]{ "X", "X", " ",
                                "X", "O", " ",
                                "O", "O", "O" })]

        [DataRow(new string[9]{ "O", "X", "O",
                                "O", "X", " ",
                                "O", " ", "X" })]

        [DataRow(new string[9]{ " ", "O", "X",
                                "X", "O", "O",
                                "X", "O", " " })]

        [DataRow(new string[9]{ "X", "O", "O",
                                " ", "X", "O",
                                "X", " ", "O" })]

        [DataRow(new string[9]{ "O", "X", " ",
                                "X", "O", " ",
                                "O", "X", "O" })]

        [DataRow(new string[9]{ "X", "X", "O",
                                " ", "O", " ",
                                "O", "X", "O" })]
        public void CheckGameBoardState_AllWinConstellationsForPlayerO(string[] testGameBoard)
        {
            // Arange 
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

            // Act
            board.CheckGameBoardState();

            // Assert
            Assert.IsTrue(board.PlayerOIsWinner);
            Assert.IsFalse(board.PlayerXIsWinner);
            Assert.IsFalse(board.GameIsTie);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
            TestContext.WriteLine("TestGameBoard:");
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[0], testGameBoard[1], testGameBoard[2]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[3], testGameBoard[4], testGameBoard[5]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[6], testGameBoard[7], testGameBoard[8]);
        }

        [DataTestMethod]
        [DataRow(new string[9]{ "O", "X", "X",
                                "X", "O", "O",
                                "O", "X", "X" })]

        [DataRow(new string[9]{ "O", "O", "X",
                                "X", "X", "O",
                                "O", "X", "O" })]

        
        public void CheckGameBoardState_TestWhenGameBoardIsTie(string[] testGameBoard)
        {
            // Arange 
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

            // Act
            board.CheckGameBoardState();

            // Assert
            Assert.IsFalse(board.PlayerXIsWinner);
            Assert.IsFalse(board.PlayerOIsWinner);
            Assert.IsTrue(board.GameIsTie);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
            TestContext.WriteLine("TestGameBoard:");
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[0], testGameBoard[1], testGameBoard[2]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[3], testGameBoard[4], testGameBoard[5]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[6], testGameBoard[7], testGameBoard[8]);
        }

        [DataTestMethod]
        [DataRow(new string[9]{ "O", "X", "X",
                                "X", "O", "O",
                                "O", "X", "X" })]

        [DataRow(new string[9]{ "O", " ", "X",
                                "X", "X", "O",
                                " ", "X", "O" })]
        public void ResetGameBoard_TestWhetherAllGameBoardValuesAreReset(string[] testGameBoard)
        {
            // Arange 
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
            string expexted_allValuesOf_Area = "         ";


            // Act
            board.ResetGameBoard();
            string allValuesOf_Area = "";
            bool allValuesOf_IsWinnArea = true;
            bool allValuesOf_AreaHasAToken = true;
            foreach (var item in boardAreaList)
            {
                allValuesOf_Area += item.Area;
                if (item.IsWinArea)
                    allValuesOf_IsWinnArea = false;
                if (item.AreaHasToken)
                    allValuesOf_AreaHasAToken = false;
            }

            // Assert
            Assert.IsFalse(board.PlayerXIsWinner);
            Assert.IsFalse(board.PlayerOIsWinner);
            Assert.IsFalse(board.GameIsTie);
            Assert.IsTrue(allValuesOf_IsWinnArea);
            Assert.IsTrue(allValuesOf_AreaHasAToken);
            Assert.AreEqual(expexted_allValuesOf_Area, allValuesOf_Area);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
            TestContext.WriteLine("TestGameBoard:");
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[0], testGameBoard[1], testGameBoard[2]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[3], testGameBoard[4], testGameBoard[5]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[6], testGameBoard[7], testGameBoard[8]);
        }

        [TestCleanup] 
        public void TestCleanUp()
        {
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }
    }
}
