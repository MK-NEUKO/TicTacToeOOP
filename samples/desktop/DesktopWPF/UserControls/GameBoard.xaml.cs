using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using MichaelKoch.TicTacToe.Samples.DesktopWPF.CustomControls;
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
                // DummyGameBoardViewModel is instantiated in the XAML file,
                // because than there is intellisense support for the properties.
            }
            else
            {
                // TODO: Setup a new ViewModel for the GameBoard-Control 
                //var viewModel = App.AppHost!.Services.GetRequiredService<IGameBoard>();
                //DataContext = viewModel;
            }
        }


        private void AreaButton_OnMouseLeave(object sender, MouseEventArgs e)
        {
            var button = (AreaButton)sender;
            if ((bool)button.IsChecked)
            {
                button.CanShowIsOccupied = true;
            }
        }
    }
}
