using Microsoft.VisualStudio.TestTools.UnitTesting;
using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Core.Test
{
    [TestClass]
    class Ai_Test
    {
        private TestContext _testContextInstance;
        private GameBoard _board;
        private AI _aimimax;
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
        [DataRow(new string[9]{ " ", " O"," ",
                                "X", "X", "O",
                                " ", "X", "O" })]
        public void GetAMove_TestWhetherCorrectAreaIDIsReturned(string[] testGameBoard)
        {
            // Arange 
            for (int index = 0; index < testGameBoard.Length; index++)
            {
                _boardAreaList[index].Area = testGameBoard[index];
            }

            // Act
            _board.CheckGameBoardState();

            // Assert
        }
    }
}
