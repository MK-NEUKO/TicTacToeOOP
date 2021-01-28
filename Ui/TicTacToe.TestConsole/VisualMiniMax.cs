using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    public class VisualMiniMax
    {
        private TestDateInput _testDataInput;
        private MiniMax _minimax;
        private bool _repeatQuery = true;

        public VisualMiniMax(TestDateInput testDataInput, MiniMax minimax)
        {
            _testDataInput = testDataInput;
            _minimax = minimax;
        }

        public void VisualizeMiniMaxAlgorithem()
        {
            do
            {
                // Eingaben für die Testkonfiguration holen.
                _testDataInput.GetTestData();
                // Testkonfiguraton Anzeigen
                _testDataInput.ShowTestData();
                // Testdaten werde´n ausgegeben.
                Console.WriteLine();
                Console.WriteLine($" Evatuate()...: {_minimax.Evaluate()}");        
                Console.WriteLine($" Zugbewertung.: {_minimax.NextMove(_testDataInput.NextPlayer)}");
                Console.WriteLine($" ZugO.........: {_minimax.NextMoveO}");
                Console.WriteLine($" ZugX.........: {_minimax.NextMoveX}");
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
