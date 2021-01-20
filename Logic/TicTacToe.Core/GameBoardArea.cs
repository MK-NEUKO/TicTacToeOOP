﻿namespace NEUKO.TicTacToe.Core
{
    public class GameBoardArea
    {
        private readonly int _areaID;
        private string _area;
        private bool _areaHasToken;
        private bool _isWinArea;
        

        public GameBoardArea(int areaID)
        {
            _areaID = areaID;
            _area = " ";
            _areaHasToken = false;
            _isWinArea = false;
        }

        public bool IsWinArea
        {
            get { return _isWinArea; }
            set { _isWinArea = value; }
        }

        public bool AreaHasToken 
        {
            get { return _areaHasToken; }
            set { _areaHasToken = value; }
        }

        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public int AreaID { get => _areaID; }
    }
}