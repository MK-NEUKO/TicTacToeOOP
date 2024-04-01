using System.ComponentModel;
using System.Windows.Controls;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.UserControls
{
    public partial class GameBoard : UserControl
    {
        public GameBoard()
        {
            InitializeComponent();
            SetDataContextBasedOnDesignMode();
        }

        private void SetDataContextBasedOnDesignMode() 
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                // DummyGameInfoBoardViewModel is instantiated in the XAML file,
                // because than there is intellisense support for the properties.
            }
            else
            {
                var viewModel = App.AppHost!.Services.GetRequiredService<IGameBoard>();
                DataContext = viewModel;
            }
        }
    }
}
