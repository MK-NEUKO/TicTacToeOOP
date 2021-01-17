using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class QueryConverter
    {
        public int ConvertUserInput(string userInput)
        {
            userInput = userInput.ToUpper();
            switch (userInput)
            {
                case "A1":
                    return 0;
                case "A2":
                    return 1;
                case "A3":
                    return 2;
                case "B1":
                    return 3;
                case "B2":
                    return 4;
                case "B3":
                    return 5;
                case "C1":
                    return 6;
                case "C2":
                    return 7;
                case "C3":
                    return 8;

            }
            return 9;
        }
    }
}
