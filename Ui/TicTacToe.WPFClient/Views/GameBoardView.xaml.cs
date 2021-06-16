using System;
using System.Windows.Controls;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    /// <summary>
    /// Interaktionslogik für GameBoard.xaml
    /// </summary>
    public partial class GameBoardView : UserControl
    {
        public delegate void StartAnimationCompletedEventHandler(object sender, EventArgs e);
        public event StartAnimationCompletedEventHandler StartAnimationCompletedEvent;
        public GameBoardView()
        {
            InitializeComponent();
        }

        private void StartAnimationCompleted(object sender, EventArgs e)
        {
            StartAnimationCompletedEvent?.Invoke(sender, e);
        }
    }
}
