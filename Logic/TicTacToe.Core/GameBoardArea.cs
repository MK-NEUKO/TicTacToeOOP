namespace NEUKO.TicTacToe.Core
{
    public class GameBoardArea
    {
        private readonly int _areaId;
        private string _signe;
        

        public GameBoardArea(int areaId)
        {
            _areaId = areaId;
            _signe = " ";
        }

        
        public string Signe
        {
            get { return _signe; }
            set { _signe = value; }
        }

    }
}
