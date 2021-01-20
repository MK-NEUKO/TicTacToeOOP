﻿namespace NEUKO.TicTacToe.Core
{
    public class Player : IPlayer
    {
        private bool _inAction;
        private bool _isHuman;
        private string _name;
        private int _points;
        private int _maximumDepth;


        public Player()
        {
            _points = 0;
            _maximumDepth = 0;
            
        }

        public int Points
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

        public int MaximumDepth { get => _maximumDepth; set => _maximumDepth = value; }
    }
}