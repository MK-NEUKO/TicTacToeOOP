using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    /// <summary>
    /// Interaktionslogik für GameBoard.xaml
    /// </summary>
    public partial class GameBoardView : UserControl, INotifyPropertyChanged
    {
        private bool _isLoadNewGameAnimation;

        public GameBoardView()
        {
            InitializeComponent();
        }

        public bool IsLoadNewGameAnimation
        {
            get => _isLoadNewGameAnimation;
            set 
            {
                _isLoadNewGameAnimation = value;
                OnPropertyChanged();
            }
        }

        private void StartAnimationCompleted(object sender, EventArgs e)
        {
            var gameBoardViewModel = (GameBoardViewModel)this.DataContext;
            gameBoardViewModel.StartGameWhenStartanimationCompletedCommand.Execute(null);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
