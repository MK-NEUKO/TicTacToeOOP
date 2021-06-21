using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class GameBoardViewModelSampleData : IGameBoardViewModel
    {
        private List<PlaceATokenCommand> _placeATokenCommands;
        private IList<GameBoardAreaDummy> _gameBoardAreaList = new List<GameBoardAreaDummy>();        
        private bool _isPlayed;

        public GameBoardViewModelSampleData()
        {
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "X", AreaID = 0, RowIndex = 0, ColumnIndex = 0, IsWinArea = true});
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "O", AreaID = 1, RowIndex = 0, ColumnIndex = 1 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "X", AreaID = 2, RowIndex = 0, ColumnIndex = 2 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = " ", AreaID = 3, RowIndex = 1, ColumnIndex = 0 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "X", AreaID = 4, RowIndex = 1, ColumnIndex = 1 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = " ", AreaID = 5, RowIndex = 1, ColumnIndex = 2 });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "X", AreaID = 6, RowIndex = 2, ColumnIndex = 0, IsGameRunning = true });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = " ", AreaID = 7, RowIndex = 2, ColumnIndex = 1, IsGameRunning = true });
            _gameBoardAreaList.Add(new GameBoardAreaDummy() { Area = "O", AreaID = 8, RowIndex = 2, ColumnIndex = 2, IsGameRunning = true });

            _placeATokenCommands = CreatePlaceATokenCommands();
        }

        private List<PlaceATokenCommand> CreatePlaceATokenCommands()
        {
            _placeATokenCommands = new List<PlaceATokenCommand>();
            int numberOfCommands = 9;
            for (int areaID = 0; areaID < numberOfCommands; areaID++)
            {
                _placeATokenCommands.Add(new PlaceATokenCommand(areaID, PlaceATokenExecute, PlaceATokenCanExecute));
                _placeATokenCommands[areaID].RowIndex = _gameBoardAreaList[areaID].RowIndex;
                _placeATokenCommands[areaID].ColumnIndex = _gameBoardAreaList[areaID].ColumnIndex;
            }

            return _placeATokenCommands;
        }

        private bool PlaceATokenCanExecute(int areaID)
        {
            return true;
        }

        private void PlaceATokenExecute(int obj)
        {
            int i = 5;
        }

        public IList<GameBoardAreaDummy> GameBoardAreaList { get => _gameBoardAreaList; set => _gameBoardAreaList = value; }
        public bool IsPlayed { get => _isPlayed; set => _isPlayed = value; }

        public IReadOnlyList<PlaceATokenCommand> PlaceATokenCommands => _placeATokenCommands.AsReadOnly();

        IReadOnlyList<GameBoardArea> IGameBoardViewModel.GameBoardAreaList => throw new NotImplementedException();

        public void InitializeLastGameBoard()
        {
            throw new NotImplementedException();
        }

        public void InitializeNewGameBoard()
        {
            throw new NotImplementedException();
        }

        public void ShowStartAnimation()
        {
            throw new NotImplementedException();
        }
    }
}
