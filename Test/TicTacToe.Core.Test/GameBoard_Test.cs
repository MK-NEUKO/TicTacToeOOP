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
        private TestContext _testContextInstance;
        private GameBoard _board;
        private IList<GameBoardArea> _boardAreaList;
        public TestContext TestContext
        { 
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }        

        [TestInitialize]
        public void TestInitialize()
        {
            _boardAreaList = new List<GameBoardArea>();
            for (int areaID = 0; areaID < 9; areaID++)
            {
                _boardAreaList.Add(new GameBoardArea(areaID));
            }
            _board = new GameBoard(_boardAreaList);
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
            for (int index = 0; index < testGameBoard.Length; index++)
            {
                _boardAreaList[index].Area = testGameBoard[index];
            }
            
            // Act
            _board.CheckGameBoardState();

            // Assert
            Assert.IsTrue(_board.PlayerXIsWinner);
            Assert.IsFalse(_board.PlayerOIsWinner);
            Assert.IsFalse(_board.GameIsTie);
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
            for (int index = 0; index < testGameBoard.Length; index++)
            {
                _boardAreaList[index].Area = testGameBoard[index];
            }

            // Act
            _board.CheckGameBoardState();

            // Assert
            Assert.IsTrue(_board.PlayerOIsWinner);
            Assert.IsFalse(_board.PlayerXIsWinner);
            Assert.IsFalse(_board.GameIsTie);
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
            for (int index = 0; index < testGameBoard.Length; index++)
            {
                _boardAreaList[index].Area = testGameBoard[index];
            }

            // Act
            _board.CheckGameBoardState();

            // Assert
            Assert.IsFalse(_board.PlayerXIsWinner);
            Assert.IsFalse(_board.PlayerOIsWinner);
            Assert.IsTrue(_board.GameIsTie);
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
            for (int index = 0; index < testGameBoard.Length; index++)
            {
                _boardAreaList[index].Area = testGameBoard[index];
            }
            string expexted_allValuesOf_Area = "         ";


            // Act
            _board.ResetGameBoard();


            // Assert
            string allValuesOf_Area = "";
            bool allValuesOf_IsWinnArea =false;
            bool allValuesOf_AreaHasAToken = false;
            foreach (var item in _boardAreaList)
            {
                allValuesOf_Area += item.Area;
                if (item.IsWinArea)
                    allValuesOf_IsWinnArea = true;
                if (item.AreaHasToken)
                    allValuesOf_AreaHasAToken = true;
            }

            Assert.IsFalse(_board.PlayerXIsWinner);
            Assert.IsFalse(_board.PlayerOIsWinner);
            Assert.IsFalse(_board.GameIsTie);
            Assert.IsFalse(allValuesOf_IsWinnArea);
            Assert.IsFalse(allValuesOf_AreaHasAToken);
            Assert.AreEqual(expexted_allValuesOf_Area, allValuesOf_Area);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
            TestContext.WriteLine("TestGameBoard:");
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[0], testGameBoard[1], testGameBoard[2]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[3], testGameBoard[4], testGameBoard[5]);
            TestContext.WriteLine(" {0} | {1} | {2} ", testGameBoard[6], testGameBoard[7], testGameBoard[8]);
        }

        [DataTestMethod]
        [DataRow(0, "X", "X")]
        [DataRow(1, "O", "O")]
        [DataRow(2, "X", "X")]
        [DataRow(3, "O", "O")]
        [DataRow(4, "X", "X")]
        [DataRow(5, "O", "O")]
        [DataRow(6, "X", "X")]
        [DataRow(7, "O", "O")]
        [DataRow(8, "X", "X")]
        public void PlaceAToken_TestWhenATokenIsPlaced(int inputAreaID, string token, string expectedToken)
        {                    
            // Act
            _board.PlaceAToken(inputAreaID, token);

            // Assert
            Assert.AreEqual(expectedToken, _boardAreaList[inputAreaID].Area);
            Assert.IsTrue(_boardAreaList[inputAreaID].AreaHasToken);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
            TestContext.WriteLine("TestData:");
            TestContext.WriteLine($"AreaID: {inputAreaID} | Token: {token}");
        }

        [TestCleanup] 
        public void TestCleanUp()
        {
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }
    }
}
