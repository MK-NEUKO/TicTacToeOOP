namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses
{
    public class GameBoardArea : BaseDataClass
    { 
        private readonly int _areaID;
        private string _area;
        private bool _areaHasToken;
        private bool _isWinArea;
        private int _columnIndex;
        private int _rowIndex;
        private bool _isShown;
        

        public GameBoardArea(int areaID)
        {
            _areaID = areaID;
            _area = " ";
            _areaHasToken = false;
            _isWinArea = false;
            _isShown = false;
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
        public bool IsShown
        {
            get { return _isShown; }
            set
            {
                _isShown = value;
                OnPropertyChanged();
            }
        }
    }
}
