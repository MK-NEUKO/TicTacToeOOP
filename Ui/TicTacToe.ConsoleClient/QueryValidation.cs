using NEUKO.TicTacToe.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class QueryValidation
    {
        private readonly IList<GameBoardArea> _boardAreaList;

        public QueryValidation(IList<GameBoardArea> boardAreaList)
        {
            _boardAreaList = boardAreaList;
        }

        public bool ValidatePlayerName(string userInput)
        {
            if (String.IsNullOrEmpty(userInput))
                return false;

            Regex pattern = new Regex(@"^[a-zA-Z0-9\s]{0,14}$");
            return pattern.IsMatch(userInput);
        }

        public bool ValidateAreaID(int areaID)
        {

            if (areaID < 0 || areaID > 8)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ungültige Eingabe, gültige Eingabe währe z.B. 'B1' od. 'c2'!");
                Console.ResetColor();
                Console.WriteLine();
                return true;
            }
            else if (_boardAreaList[areaID].AreaHasToken)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Das Feld ist bereits besetzt!");
                Console.ResetColor();
                Console.WriteLine();
                return true;
            }
            else
                return false;
        }
    }
}
