﻿using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
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
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowMenuAskForAdvancedSettings()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Erweiterte Einstellungen                                           ");
            Console.WriteLine(" ------------------------------------------------------------------ ");
            Console.WriteLine(" - PlayerX, sowie PlayerO können nach belieben konfiguriert werden. ");
            Console.ResetColor();
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
            Console.WriteLine();
        }

        public void ShowMenuAskPlayerForHumanOrAi(IPlayer askedPlayer)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($" Einstellungen für {askedPlayer.Name} ");
            Console.WriteLine(" ------------------------- ");
            Console.WriteLine(" Mensch...: 1 ");
            Console.WriteLine(" Computer.: 2 ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowMenuAskForContinue()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Noch ein Spiel?     ");
            Console.WriteLine(" ------------------- ");
            Console.WriteLine(" Weiter Spielen.: 1  ");
            Console.WriteLine(" Einstellungen..: 2  ");
            Console.ResetColor();
            Console.WriteLine();
        }       

        public string GetInputQuery(string question = "Bitte wähle eine Option")
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" {0} ", question);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Eingabe.:");
            Console.ResetColor();
            Console.Write(" ");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            return userInput;
        }
       
        public string GetInputQuery(IPlayer askedPlayer, string question = "Bitte wähle eine Option")
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" {0} | {1} ", askedPlayer.Name, question);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Eingabe.:");
            Console.ResetColor();
            Console.Write(" ");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            return userInput;
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
