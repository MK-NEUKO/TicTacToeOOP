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

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void LoadNewGame_Checked(object sender, RoutedEventArgs e)
        {
            EnableControlsPlayerXPlayerO();
            UncheckRadioButtonsPlayerXPlayerO();
            DisableControlsCoverPlayerXPlayerO();
            startGameButton.IsEnabled = true;
        }

        private void LoadLastGame_Checked(object sender, RoutedEventArgs e)
        {
            ProtectControlsWithCoverPlayerXPlayerO();
            EnableControlsPlayerXPlayerO();
            startGameButton.IsEnabled = true;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            controlsCoverGameOptions.Visibility = Visibility.Visible;
            loadLastGame.Focusable = false;
            loadNewGame.Focusable = false;
            ProtectControlsWithCoverPlayerXPlayerO();
            if ((bool)loadNewGame.IsChecked)
            {
                loadLastGame.IsEnabled = false;
            }
            else
            {
                loadNewGame.IsEnabled = false;   
            }
        }

        private void SelectHumanPlayerX_Checked(object sender, RoutedEventArgs e)
        {
            selectDiffecultylevelPlayerX.IsEnabled = false;
        }

        private void SelectAiPlayerX_Checked(object sender, RoutedEventArgs e)
        {
            selectDiffecultylevelPlayerX.IsEnabled = true;
        }

        private void SelectHumanPlayerO_Checked(object sender, RoutedEventArgs e)
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
            selectHumanPlayerO.IsEnabled = true;
            selectAiPlayerX.IsEnabled = true;
            selectAiPlayerO.IsEnabled = true;
            namePlayerX.IsEnabled = true;
            namePlayerO.IsEnabled = true;
            selectDiffecultylevelPlayerX.IsEnabled = true;
            selectDiffecultylevelPlayerO.IsEnabled = true;
        }

        private void UncheckRadioButtonsPlayerXPlayerO()
        {
            selectHumanPlayerX.IsChecked = false;
            selectHumanPlayerO.IsChecked = false;
            selectAiPlayerX.IsChecked = false;
            selectAiPlayerO.IsChecked = false;
        }

        private void ProtectControlsWithCoverPlayerXPlayerO()
        {
            controlsCoverPlayerX.Visibility = Visibility.Visible;
            controlsCoverPlayerO.Visibility = Visibility.Visible;
            selectHumanPlayerX.Focusable = false;
            selectHumanPlayerO.Focusable = false;
            selectAiPlayerX.Focusable = false;
            selectAiPlayerO.Focusable = false;
            namePlayerX.Focusable = false;
            namePlayerO.Focusable = false;
            selectDiffecultylevelPlayerX.Focusable = false;
            selectDiffecultylevelPlayerO.Focusable = false;
        }

        private void DisableControlsCoverPlayerXPlayerO()
        {
            controlsCoverPlayerX.Visibility = Visibility.Hidden;
            controlsCoverPlayerO.Visibility = Visibility.Hidden;
            selectHumanPlayerX.Focusable = true;
            selectHumanPlayerO.Focusable = true;
            selectAiPlayerX.Focusable = true;
            selectAiPlayerO.Focusable = true;
            namePlayerX.Focusable = true;
            namePlayerO.Focusable = true;
            selectDiffecultylevelPlayerX.Focusable = true;
            selectDiffecultylevelPlayerO.Focusable = true;
        }
    }
}
