using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public class PlayTicTacToe
    {

    }

    public class GameBoardArea
    {
        private readonly int _areaId;
        private readonly bool _signeIsX;
        private readonly bool _signeIsO;
        private readonly bool _areaIsEmpty;

        public GameBoardArea(int areaId)
        {
            _areaId = areaId;
            _signeIsX = false;
            _signeIsO = false;
            _areaIsEmpty = true;
        }
    }

    public class GameBoard : IGameBoard
    {
        private readonly IList<GameBoardArea> _boardAreaList;

        public GameBoard(IList<GameBoardArea> boardAreaList)
        {
            _boardAreaList = boardAreaList;

        }

        public IList<GameBoardArea> BoardAreaList
        {
            get { return _boardAreaList; }
        }

        public string CheckForWinner()
        {
            throw new NotImplementedException();
        }

        public void PlaceASigne(int areaId)
        {
            throw new NotImplementedException();
        }
    }

    public interface IGameBoard
    {
        IList<GameBoardArea> BoardAreaList { get; }
        void PlaceASigne(int areaId);
        string CheckForWinner();
    }
}
