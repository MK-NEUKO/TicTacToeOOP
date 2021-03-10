namespace NEUKO.TicTacToe.Core
{
    public class Player : CoreBase, IPlayer
    {
        private bool _inAction;
        private bool _isHuman;
        private string _name;
        private int _points;
        private int _maximumDepth;


        public Player(string name, bool inAction, bool isHuman)
        {
            _name = name;
            _inAction = inAction;
            _isHuman = isHuman;
            _points = 0;
            _maximumDepth = 0;
            
        }

        public int Points
        {
            get { return _points; }
            set 
            { 
                _points = value;
                OnPropertyChanged();
            }
        }

        public bool InAction
        {
            get { return _inAction; }
            set
            { 
                _inAction = value;
                OnPropertyChanged();
            } 
        }
        public bool IsHuman 
        { 
            get { return _isHuman; }
            set 
            { 
                _isHuman = value;
                OnPropertyChanged();
            }
             
        }
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged();
            }
        }

        public int MaximumDepth { get => _maximumDepth; set => _maximumDepth = value; }
    }
}
