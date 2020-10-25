namespace NEUKO.TicTacToe.Core
{
    public class GameBoardArea
    {
        private readonly int _areaID;
        private string _area;
        private bool _areaHasToken;
        

        public GameBoardArea(int areaID)
        {
            _areaID = areaID;
            _area = " ";
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

    }
}
