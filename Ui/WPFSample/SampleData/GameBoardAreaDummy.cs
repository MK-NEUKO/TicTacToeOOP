namespace WPFSample.SampleData
{
    public class GameBoardAreaDummy
    {
        public string Area { get; set; }
        public int AreaID { get; set; }
        public bool IsWinArea { get; set; }
        public bool IsOccupied { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public GameBoardAreaDummy()
        {
            IsWinArea = false;
            IsOccupied = false;
        }
    }
}
