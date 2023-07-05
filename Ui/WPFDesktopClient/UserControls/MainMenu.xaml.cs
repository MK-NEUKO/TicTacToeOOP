using System.Windows;
using System.Windows.Controls;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            Loaded += MainMenu_Loaded;
        }

        private void MainMenu_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IMenuViewModel vm)
            {
                vm.GameMenuViewModel.Reset += this.ResetGameMenu;
            } 
        }

        private void LoadNewGame_Checked(object sender, RoutedEventArgs e)
        {
            EnableControlsPlayerXPlayerO();
            UncheckRadioButtonsPlayerXPlayerO();
            DisableControlsCoverPlayerXPlayerO();
            StartGameButton.IsEnabled = true;
        }

        private void LoadLastGame_Checked(object sender, RoutedEventArgs e)
        {
            ProtectControlsWithCoverPlayerXPlayerO();
            EnableControlsPlayerXPlayerO();
            StartGameButton.IsEnabled = true;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            ControlsCoverGameOptions.Visibility = Visibility.Visible;
            LoadLastGame.Focusable = false;
            NewGame.Focusable = false;
            ProtectControlsWithCoverPlayerXPlayerO();
            if ((bool)NewGame.IsChecked!)
            {
                LoadLastGame.IsEnabled = false;
            }
            else
            {
                NewGame.IsEnabled = false;   
            }
        }

        private void SelectHumanPlayerX_Checked(object sender, RoutedEventArgs e)
        {
            SelectDifficultyLevelPlayerX.IsEnabled = false;
        }

        private void SelectAiPlayerX_Checked(object sender, RoutedEventArgs e)
        {
            SelectDifficultyLevelPlayerX.IsEnabled = true;
        }

        private void SelectHumanPlayerO_Checked(object sender, RoutedEventArgs e)
        {
            SelectDifficultyLevelPlayerO.IsEnabled = false;
        }

        private void SelectAiPlayerO_Checked(object sender, RoutedEventArgs e)
        {
            SelectDifficultyLevelPlayerO.IsEnabled = true;
        }

        private void EnableControlsPlayerXPlayerO()
        {
            SelectHumanPlayerX.IsEnabled = true;
            SelectHumanPlayerO.IsEnabled = true;
            SelectAiPlayerX.IsEnabled = true;
            SelectAiPlayerO.IsEnabled = true;
            NamePlayerX.IsEnabled = true;
            NamePlayerO.IsEnabled = true;
            SelectDifficultyLevelPlayerX.IsEnabled = true;
            SelectDifficultyLevelPlayerO.IsEnabled = true;
            HasNextTurnPlayerX.IsEnabled = true;
            HasNextTurnPlayerO.IsEnabled = true;
        }

        private void DisableControlsPlayerXPlayerO()
        {
            SelectHumanPlayerX.IsEnabled = false;
            SelectHumanPlayerO.IsEnabled = false;
            SelectAiPlayerX.IsEnabled = false;
            SelectAiPlayerO.IsEnabled = false;
            NamePlayerX.IsEnabled = false;
            NamePlayerO.IsEnabled = false;
            SelectDifficultyLevelPlayerX.IsEnabled = false;
            SelectDifficultyLevelPlayerO.IsEnabled = false;
            HasNextTurnPlayerX.IsEnabled = false;
            HasNextTurnPlayerO.IsEnabled = false;
        }

        private void UncheckRadioButtonsPlayerXPlayerO()
        {
            SelectHumanPlayerX.IsChecked = false;
            SelectHumanPlayerO.IsChecked = false;
            SelectAiPlayerX.IsChecked = false;
            SelectAiPlayerO.IsChecked = false;
            HasNextTurnPlayerX.IsChecked = false;
            HasNextTurnPlayerO.IsChecked = false;
        }

        private void ProtectControlsWithCoverPlayerXPlayerO()
        {
            ControlsCoverPlayerX.Visibility = Visibility.Visible;
            ControlsCoverPlayerO.Visibility = Visibility.Visible;
            SelectHumanPlayerX.Focusable = false;
            SelectHumanPlayerO.Focusable = false;
            SelectAiPlayerX.Focusable = false;
            SelectAiPlayerO.Focusable = false;
            NamePlayerX.Focusable = false;
            NamePlayerO.Focusable = false;
            SelectDifficultyLevelPlayerX.Focusable = false;
            SelectDifficultyLevelPlayerO.Focusable = false;
            HasNextTurnPlayerX.Focusable = false;
            HasNextTurnPlayerO.Focusable = false;
        }

        private void DisableControlsCoverPlayerXPlayerO()
        {
            ControlsCoverPlayerX.Visibility = Visibility.Hidden;
            ControlsCoverPlayerO.Visibility = Visibility.Hidden;
            SelectHumanPlayerX.Focusable = true;
            SelectHumanPlayerO.Focusable = true;
            SelectAiPlayerX.Focusable = true;
            SelectAiPlayerO.Focusable = true;
            NamePlayerX.Focusable = true;
            NamePlayerO.Focusable = true;
            SelectDifficultyLevelPlayerX.Focusable = true;
            SelectDifficultyLevelPlayerO.Focusable = true;
            HasNextTurnPlayerX.Focusable = true;
            HasNextTurnPlayerO.Focusable = true;
        }

        private void HasNextTurnPlayerX_Checked(object sender, RoutedEventArgs e)
        {
            HasNextTurnPlayerO.IsChecked = false;
        }

        private void HasNextTurnPlayerO_Checked(object sender, RoutedEventArgs e)
        {
            HasNextTurnPlayerX.IsChecked = false;
        }

        private void ResetGameOptionButtons()
        {
            NewGame.IsEnabled = true;
            NewGame.IsChecked = false;
            LoadLastGame.IsEnabled = true;
            LoadLastGame.IsChecked = false;
            ControlsCoverGameOptions.Visibility = Visibility.Hidden;
        }

        private void ResetGameMenu()
        {
            ResetGameOptionButtons();
            DisableControlsPlayerXPlayerO();
            UncheckRadioButtonsPlayerXPlayerO();
        }
    }
}
