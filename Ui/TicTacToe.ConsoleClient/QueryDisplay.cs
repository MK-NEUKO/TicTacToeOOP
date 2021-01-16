using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.ConsoleClient
{
    public class QueryDisplay
    {
        public void ShowMenuGetSettings()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Willkommen im Spiel TicTacToe ");
            Console.WriteLine(" ----------------------------- ");
            Console.WriteLine(" Standart Einstellungen...: 1  ");
            Console.WriteLine(" Erweiterte Einstellungen.: 2  ");
            Console.ResetColor();
        }

        public void ShowInputGetSettings()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Eingabe.:");
            Console.ResetColor();
            Console.Write(" ");
        }

        public void ShowWhenWrongInputGetSettings()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" Falsche Eingabe, bitte wähle '1' oder '2'! ");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
