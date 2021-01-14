using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class QueryValidation
    {
        public bool ValidatePlayerName(string userInput)
        {
            if (String.IsNullOrEmpty(userInput))
                return false;

            Regex pattern = new Regex(@"^[a-zA-Z0-9\s]{0,14}$");
            return pattern.IsMatch(userInput);
        }
    }
}
