namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses
{
    public class GameBoardArea : DataClassBase
    { 
        private readonly int _areaID;
        private string _area;
        private bool _isOccupied;
        private bool _isWinArea;
        private int _columnIndex;
        private int _rowIndex;
        private bool _isNewGameAnimated;
        private bool _isLastGameAnimated;
        private bool _isInGame;
        

        public GameBoardArea(int areaID)
        {
            _areaID = areaID;
            _area = " ";
            _isOccupied = false;
            _isWinArea = false;
            _isNewGameAnimated = false;
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

        public bool IsOccupied 
        {
            get { return _isOccupied; }
            set
            {
                if (_area != " ")
                {
                    _isOccupied = false;
                }
                _isOccupied = value;
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
        public bool IsNewGameAnimated
        {
            get { return _isNewGameAnimated; }
            set
            {
                _isNewGameAnimated = value;
                OnPropertyChanged();
            }
        }

        public bool IsLastGameAnimated
        {
            get => _isLastGameAnimated;
            set
            {
                _isLastGameAnimated = value;
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
