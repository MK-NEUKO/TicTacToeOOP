using System.Windows.Controls;
using MichaelKoch.TicTacToe.Samples.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.UserControls
{
    public partial class GameInfoBoard : UserControl
    {
        public GameInfoBoard()
        {
            InitializeComponent();
            var vm = App.AppHost!.Services.GetRequiredService<PlayerViewModel>();
            DataContext = vm;
        }
    }
}
