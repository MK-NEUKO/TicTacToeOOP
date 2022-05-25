using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    /// <summary>
    /// Interaktionslogik für MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MenuView()
        {
            InitializeComponent();
        } 

        private void LoadNewGame_Checked(object sender, RoutedEventArgs e)
        {
            EnableControlsPlayerXPlayerO();
            startGameButton.IsEnabled = true;
        }
        private void LoadLastGame_Checked(object sender, RoutedEventArgs e)
        {
            FreezControlsPlayerXPlayerO();
        }
        private void SelectHumanPlayerX_Checked(object sender, RoutedEventArgs e)
        {
            selectDiffecultylevelPlayerX.IsEnabled = false;
        }
        private void SelectAiPlayerX_Checked(object sender, RoutedEventArgs e)
        {
            selectDiffecultylevelPlayerX.IsEnabled = true;
        }
        private void SelectHumamnPlayerO_Checked(object sender, RoutedEventArgs e)
        {
            selectDiffecultylevelPlayerO.IsEnabled = false;
        }

        private void SelectAiPlayerO_Checked(object sender, RoutedEventArgs e)
        {
            selectDiffecultylevelPlayerO.IsEnabled = true;
        }

        private void EnableControlsPlayerXPlayerO()
        {
            selectHumanPlayerX.IsEnabled = true;
            selectHumamnPlayerO.IsEnabled = true;
            selectAiPlayerX.IsEnabled = true;
            selectAiPlayerO.IsEnabled = true;
            namePlayerX.IsEnabled = true;
            namePlayerO.IsEnabled = true;
            selectDiffecultylevelPlayerX.IsEnabled = true;
            selectDiffecultylevelPlayerO.IsEnabled = true;
        }

        private void FreezControlsPlayerXPlayerO()
        {
            //selectAiPlayerO.IsEnabled = false;
            //VisualStateManager.GoToState(selectAiPlayerO, "Normal", true);

        }

    }
}
