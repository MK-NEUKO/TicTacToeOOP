using Microsoft.VisualStudio.TestTools.UnitTesting;
using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Core.Test
{
    [TestClass]
    public class Ai_Test
    {
        private TestContext _testContextInstance;
        private AI _aimimax;
        private IPlayer _playerX;
        private IPlayer _playerO;
        private IGameBoard _board;
        private IList<GameBoardArea> _evaluationList;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _playerX = new Player();
            _playerO = new Player();            
            _evaluationList = new List<GameBoardArea>();
            for (int areaID = 0; areaID < 9; areaID++)
            {
                _evaluationList.Add(new GameBoardArea(areaID));
            }
            _board = new GameBoard(_evaluationList);
            _aimimax = new AI(_evaluationList, _board, _playerX, _playerO);
        }


        [DataTestMethod]
        [DataRow(new string[9]{ " ", "O"," ",
                                "X", "X", "O",
                                " ", "X", "O" })]
        public void GetAMove_ReturnAreaIDForX_CorrectAreaID(string[] testGameBoard)
        {
            // Arange 
            for (int index = 0; index < testGameBoard.Length; index++)
            {
                _evaluationList[index].Area = testGameBoard[index];
            }
            _playerO.InAction = false;
            _playerX.InAction = true;
            _playerX.MaximumDepth = 10;

            // Act
            _aimimax.GetAMove();

            // Assert
            Assert.AreEqual(2, _aimimax.AreaIDForX);
        }

        [DataTestMethod]
        [DataRow(new string[9]{ "X", "O"," ",
                                "X", "X", "O",
                                " ", "X", "O" })]
        public void GetAMove_ReturnAreaIDForO_CorrectAreaID(string[] testGameBoard)
        {
            // Arange 
            for (int index = 0; index < testGameBoard.Length; index++)
            {
                _evaluationList[index].Area = testGameBoard[index];
            }
            _playerO.InAction = true;
            _playerX.InAction = false;
            _playerO.MaximumDepth = 10;

            // Act
            _aimimax.GetAMove();

            // Assert
            Assert.AreEqual(2, _aimimax.AreaIDForO);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }
    }
}
