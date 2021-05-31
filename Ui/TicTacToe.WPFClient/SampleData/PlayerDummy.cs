using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class PlayerDummy
    {
        public bool InAction { get; set; }
        public bool IsHuman { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int MaximumDepth { get; set; }
    }
}
