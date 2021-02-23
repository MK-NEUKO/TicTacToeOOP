using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFSample.SampleData;

namespace WPFSample
{
    public partial class MainWindow : Window
    {
        private readonly GameBoardViewModelSampleData _gameBoardViewModelSampleData;
        public MainWindow()
        {
            InitializeComponent();

            _gameBoardViewModelSampleData = new GameBoardViewModelSampleData();
        }

        private void ButtonIsPlayed_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void GameBoardAreaButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
