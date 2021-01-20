using NEUKO.TicTacToe.Core;
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

        public void ShowMenuAskForDefaultSettings()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Standart Einstellungen                                                    ");
            Console.WriteLine(" ------------------------------------------------------------------------- ");
            Console.WriteLine(" Grundeinstellungen: - Spieler 'O' ist der Computergegner.                 ");
            Console.WriteLine("                     - Der Computergegner hat den Namen Aimimax.           ");
            Console.WriteLine("                     - Als Erstes wird nach dem Namen von PlayerX gefragt. ");
            Console.WriteLine("                     - Als Zweites nach dem Schwierigkeitsgrad.            ");
            Console.WriteLine();
        }

        public void ShowMenuAskForAdvancedSettings()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Erweiterte Einstellungen                                           ");
            Console.WriteLine(" ------------------------------------------------------------------ ");
            Console.WriteLine(" - PlayerX, sowie PlayerO können nach belieben konfiguriert werden. ");
            Console.WriteLine();
        }

        public void ShowMenuAskPlayerForDiffecultyLevel()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Schwierigkeitsgrad ");
            Console.WriteLine(" ------------------ ");
            Console.WriteLine(" Leicht......: 1    ");
            Console.WriteLine(" Normal......: 2    ");
            Console.WriteLine(" Schwer......: 3    ");
            Console.WriteLine(" Unbesiegbar.: 4    ");
            Console.ResetColor();
        }

        public void ShowMenuAskPlayerForHumanOrAi(IPlayer askedPlayer)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($" Einstellungen für {askedPlayer.Name} ");
            Console.WriteLine(" ------------------------- ");
            Console.WriteLine(" Mensch...: 1 ");
            Console.WriteLine(" Computer.: 2 ");
        }

        public void ShowMenuAskForContinue()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Noch ein Spiel?     ");
            Console.WriteLine(" ------------------- ");
            Console.WriteLine(" Weiter Spielen.: 1  ");
            Console.WriteLine(" Einstellungen..: 2  ");
            Console.ResetColor();
        }

        public void ShowInputQueryGetSettings()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Eingabe.:");
            Console.ResetColor();
            Console.Write(" ");
        }

        public void ShowInputQueryAskPlayerForName(IPlayer askedPlayer)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($" {askedPlayer.Name}, wähle einen Namen, erlaubt sind 14 Zeichen (A-Z, a-z, 0-9, Leerzeichen). ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Eingabe.:");
            Console.ResetColor();
            Console.Write(" ");
        }

        public void ShowInputQueryAskPlayerForDiffecultyLevel(IPlayer askedPlayer)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($" Schwierigkeitsgrad für {askedPlayer.Name} ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Eingabe.:");
            Console.ResetColor();
            Console.Write(" ");
        }

        public void ShowInputQueryAskPlayerForHumanOrAi()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Eingabe.:");
            Console.ResetColor();
            Console.Write(" ");
        }

        public void ShowInputQueryAskForContinue()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Eingabe.:");
            Console.ResetColor();
            Console.Write(" ");
        }
            
        public void ShowWhenWrongInput(string massage)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(massage);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
