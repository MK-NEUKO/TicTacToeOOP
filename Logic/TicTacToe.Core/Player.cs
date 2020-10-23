namespace NEUKO.TicTacToe.Core
{
    public class Player : IPlayer
    {
        private bool _inAction;
        private bool _isHuman;
        private string _name;

        public Player()
        {

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
