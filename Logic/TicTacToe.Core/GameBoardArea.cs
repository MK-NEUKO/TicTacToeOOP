namespace NEUKO.TicTacToe.Core
{
    public class GameBoardArea
    {
        private readonly int _areaId;
        private readonly bool _signeIsX;
        private readonly bool _signeIsO;
        private readonly bool _areaIsEmpty;

        public GameBoardArea(int areaId)
        {
            _areaId = areaId;
            _signeIsX = false;
            _signeIsO = false;
            _areaIsEmpty = true;
        }
    }
}
