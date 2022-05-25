using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses
{
    public class Player : DataClassBase
    {
        private readonly string _playerID;
        private bool _inAction;
        private bool _isHuman;
        private bool _isAI;
        private string _name;
        private int _points;
        private int _maximumDepth;
        private bool _isWinner;


        public Player()
        {

        }

        public Player(string playerID, string name, bool inAction, bool isHuman)
        {
            _playerID = playerID;
            _name = name;
            _inAction = inAction;
            IsHuman = isHuman;
            _points = 0;
            _maximumDepth = 0;
            _isWinner = false;
            
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
            get => _isHuman;
            set 
            {
                _isHuman = value;
                if (_isHuman)
                {
                    _isAI = false;
                }
                else
                {
                    _isAI = true;
                }              
            }
             
        }

        public bool IsAI
        {
            get => _isAI;
            set
            {
                _isAI = value;
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

        public bool IsWinner
        {
            get { return _isWinner; }
            set 
            { 
                _isWinner = value;
                OnPropertyChanged();
            }
        }

        public int MaximumDepth { get => _maximumDepth; set => _maximumDepth = value; }

        public string PlayerID => _playerID;
    }
}
