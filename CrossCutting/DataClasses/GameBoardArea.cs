namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses
{
    public class GameBoardArea : DataClassBase
    { 
        private readonly int _areaID;
        private string _area;
        private bool _areaHasToken;
        private bool _isWinArea;
        private int _columnIndex;
        private int _rowIndex;
        private bool _isAnimated;
        private bool _isInGame;
        

        public GameBoardArea(int areaID)
        {
            _areaID = areaID;
            _area = " ";
            _areaHasToken = false;
            _isWinArea = false;
            _isAnimated = false;
        }

        public bool IsWinArea
        {
            get { return _isWinArea; }
            set 
            {
                _isWinArea = value;
                OnPropertyChanged();
            }
        }

        public bool AreaHasToken 
        {
            get { return _areaHasToken; }
            set 
            { 
                _areaHasToken = value;
                OnPropertyChanged();
            }
        }

        public string Area
        {
            get { return _area; }
            set 
            {
                _area = value;
                OnPropertyChanged();    
            }
        }

        public int AreaID { get => _areaID; }
        public int ColumnIndex { get => _columnIndex; set => _columnIndex = value; }
        public int RowIndex { get => _rowIndex; set => _rowIndex = value; }
        public bool IsAnimated
        {
            get { return _isAnimated; }
            set
            {
                _isAnimated = value;
                OnPropertyChanged();
            }
        }

        public bool IsInGame
        {
            get => _isInGame;
            set
            {
                _isInGame = value;
                OnPropertyChanged();
            }
        }
    }
}
