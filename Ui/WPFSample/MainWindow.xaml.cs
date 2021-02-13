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

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IList<GameBoardArea> GameBoardAreaList = new List<GameBoardArea>();

        public MainWindow()
        {
            InitializeComponent();

            GameBoardAreaList.Add(new GameBoardArea() { Area = "X", AreaID = 0, RowIndex = 0, ColumnIndex = 0 });
            GameBoardAreaList.Add(new GameBoardArea() { Area = " ", AreaID = 1, RowIndex = 0, ColumnIndex = 1 });
            GameBoardAreaList.Add(new GameBoardArea() { Area = "X", AreaID = 2, RowIndex = 0, ColumnIndex = 2 });
            GameBoardAreaList.Add(new GameBoardArea() { Area = " ", AreaID = 3, RowIndex = 1, ColumnIndex = 0 });
            GameBoardAreaList.Add(new GameBoardArea() { Area = "X", AreaID = 4, RowIndex = 1, ColumnIndex = 1 });
            GameBoardAreaList.Add(new GameBoardArea() { Area = " ", AreaID = 5, RowIndex = 1, ColumnIndex = 2 });
            GameBoardAreaList.Add(new GameBoardArea() { Area = "X", AreaID = 6, RowIndex = 2, ColumnIndex = 0 });
            GameBoardAreaList.Add(new GameBoardArea() { Area = " ", AreaID = 7, RowIndex = 2, ColumnIndex = 1 });
            GameBoardAreaList.Add(new GameBoardArea() { Area = "X", AreaID = 8, RowIndex = 2, ColumnIndex = 2 });

            gameBoardControl.ItemsSource = GameBoardAreaList;
        }
    }

    public class GameBoardArea
    {
        public string Area { get; set; }
        public int AreaID { get; set; }
        public bool IsWinArea { get; set; }
        public bool IsOccupied { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public GameBoardArea()
        {
            IsWinArea = false;
            IsOccupied = false;
        }
    }
}
