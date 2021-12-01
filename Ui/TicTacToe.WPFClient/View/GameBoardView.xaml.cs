using System;
using System.Windows.Controls;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    /// <summary>
    /// Interaktionslogik für GameBoard.xaml
    /// </summary>
    public partial class GameBoardView : UserControl
    {       
        public GameBoardView()
        {
            InitializeComponent();
        }

        private void StartAnimationCompleted(object sender, EventArgs e)
        {
            var gameBoardViewModel = (GameBoardViewModel)this.DataContext;
            gameBoardViewModel.StartGameWhenStartanimationCompletedCommand.Execute(null);
        }
    }
}
