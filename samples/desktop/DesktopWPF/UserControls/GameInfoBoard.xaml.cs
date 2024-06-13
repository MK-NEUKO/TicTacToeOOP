using System.ComponentModel;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

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
                // Todo: Setup the ViewModel for the GameInfoBoard-UserControl
                //var viewModel = App.AppHost!.Services.GetRequiredService<IGameInfoBoardViewModel>();
                //DataContext = viewModel;
            }
        }
    }
}
