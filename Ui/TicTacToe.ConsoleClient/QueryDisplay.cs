﻿using System;
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
    }
}
