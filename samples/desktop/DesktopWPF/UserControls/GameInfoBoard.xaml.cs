using System.ComponentModel;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.UserControls
{
    public partial class GameInfoBoard : UserControl
    {
        public GameInfoBoard()
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
                var viewModel = App.AppHost!.Services.GetRequiredService<IGameInfoBoardViewModel>();
                DataContext = viewModel;
            }
        }
    }
}
