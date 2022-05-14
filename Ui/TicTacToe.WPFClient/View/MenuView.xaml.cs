﻿using System;
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
            selectHumanPlayerX.IsEnabled = true;
            selectAiPlayerX.IsEnabled=true;
            namePlayerX.IsEnabled = true;
            selectDiffecultylevelPlayerX.IsEnabled = true;
        }
    }
}
