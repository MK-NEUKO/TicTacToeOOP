namespace NEUKO.TicTacToe.Core
{
    public class Player : IPlayer
    {
        private bool _inAction;
        private bool _isHuman;
        private string _name;
        private string _points;        


        public Player()
        {
            _points = "0";
        }

        public string Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public bool InAction
        {
            get { return _inAction; }
            set { _inAction = value; } 
        }
        public bool IsHuman 
        { 
            get { return _isHuman; }
            set { _isHuman = value; }
             
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
