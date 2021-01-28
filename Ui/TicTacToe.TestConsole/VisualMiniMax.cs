using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    public class VisualMiniMax
    {
        private UserInput _userInput;
        private MiniMax _minimax;
        private bool _repeatQuery = true;

        public VisualMiniMax(UserInput userInput, MiniMax minimax)
        {
            _userInput = userInput;
            _minimax = minimax;
        }

        public void VisualizeMiniMaxAlgorithem()
        {
            do
            {
                // Eingaben für die Testkonfiguration holen.
                _userInput.GetTestData();
                // Testkonfiguraton Anzeigen
                _userInput.ShowTestData();
                // Testdaten werde´n ausgegeben.
                Console.WriteLine();
                Console.WriteLine($" Evatuate().: {_minimax.Evaluate()}");        
                Console.WriteLine($" NextMove().: {_minimax.NextMove(_userInput.NextPlayer)}");
                Console.WriteLine($" ZugO.......: {_minimax.NextMoveO}");
                Console.WriteLine($" ZugX.......: {_minimax.NextMoveX}");
                AskForRepeat();

            } while (_repeatQuery);
        }

        private void AskForRepeat()
        {
            string userInput = "";

            Console.WriteLine();
            Console.WriteLine(" Neuer Testlauf: 1 ");
            Console.WriteLine(" Beenden.......: 2 ");
            Console.Write(" Eingabe: ");
            userInput = Console.ReadLine();
            if (userInput == "1")
            {
                _repeatQuery = true;
                Console.Clear();
            }            
                
            if (userInput == "2")
                _repeatQuery = false;
            
        }
    }
}
