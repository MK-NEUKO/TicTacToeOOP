using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient.SampleData
{
    public class GameBoardViewModelSampleData
    {
        private IList<GameBoardAreaDummy> _gameBoardAreaList = new List<GameBoardAreaDummy>();
        private IList<GameBoardCommandDummy> _gameBoardCommands = new List<GameBoardCommandDummy>();
        private bool _isPlayed;

        public GameBoardViewModelSampleData()
        {
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "X", AreaID = 0, RowIndex = 0, ColumnIndex = 0, IsWinArea = true});
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "O", AreaID = 1, RowIndex = 0, ColumnIndex = 1 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "X", AreaID = 2, RowIndex = 0, ColumnIndex = 2 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = " ", AreaID = 3, RowIndex = 1, ColumnIndex = 0 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "X", AreaID = 4, RowIndex = 1, ColumnIndex = 1 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = " ", AreaID = 5, RowIndex = 1, ColumnIndex = 2 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "X", AreaID = 6, RowIndex = 2, ColumnIndex = 0 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = " ", AreaID = 7, RowIndex = 2, ColumnIndex = 1 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "X", AreaID = 8, RowIndex = 2, ColumnIndex = 2 });
            
            _gameBoardCommands.Add(new GameBoardCommandDummy() { AreaID = 0, RowIndex = 0, ColumnIndex = 0 });
            _gameBoardCommands.Add(new GameBoardCommandDummy() { AreaID = 1, RowIndex = 0, ColumnIndex = 1 });
            _gameBoardCommands.Add(new GameBoardCommandDummy() { AreaID = 2, RowIndex = 0, ColumnIndex = 2 });
            _gameBoardCommands.Add(new GameBoardCommandDummy() { AreaID = 3, RowIndex = 1, ColumnIndex = 0 });
            _gameBoardCommands.Add(new GameBoardCommandDummy() { AreaID = 4, RowIndex = 1, ColumnIndex = 1 });
            _gameBoardCommands.Add(new GameBoardCommandDummy() { AreaID = 5, RowIndex = 1, ColumnIndex = 2 });
            _gameBoardCommands.Add(new GameBoardCommandDummy() { AreaID = 6, RowIndex = 2, ColumnIndex = 0 });
            _gameBoardCommands.Add(new GameBoardCommandDummy() { AreaID = 7, RowIndex = 2, ColumnIndex = 1 });
            _gameBoardCommands.Add(new GameBoardCommandDummy() { AreaID = 8, RowIndex = 2, ColumnIndex = 2 });

            _isPlayed = false;
        }

        public IList<GameBoardAreaDummy> GameBoardAreaList { get => _gameBoardAreaList; set => _gameBoardAreaList = value; }
        public IList<GameBoardCommandDummy> GameBoardCommands { get => _gameBoardCommands; set => _gameBoardCommands = value; }
        public bool IsPlayed { get => _isPlayed; set => _isPlayed = value; }
    }
}
