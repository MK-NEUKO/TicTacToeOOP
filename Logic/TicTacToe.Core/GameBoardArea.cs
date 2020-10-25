namespace NEUKO.TicTacToe.Core
{
    public class GameBoardArea
    {
        private readonly int _areaID;
        private string area;
        

        public GameBoardArea(int areaID)
        {
            _areaID = areaID;
            area = " ";
        }

        
        public string Area
        {
            get { return area; }
            set { area = value; }
        }

    }
}
