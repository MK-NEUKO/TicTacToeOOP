using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls
{
    /// <summary>
    /// Interaction logic for GetSecureDialogControl.xaml
    /// </summary>
    public partial class GetSecureDialogControl : UserControl
    {
        public GetSecureDialogControl()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var dialogWindow = (Window)this.Parent;
            dialogWindow.DialogResult = true;
        }
    }
}
