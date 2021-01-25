using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    public class VisualMiniMax
    {
        private TestData _testData;
        private MiniMax _minimax;
        private bool _repeatQuery = true;

        public VisualMiniMax(TestData testData, MiniMax minimax)
        {
            _testData = testData;
            _minimax = minimax;
        }

        public void VisualizeMiniMaxAlgorithem()
        {
            do
            {
                // Eingaben für die Testkonfiguration holen
                _testData.GetTestData();
                // Testkonfiguraton Anzeigen
                _testData.ShowTestData();
                Console.WriteLine();
                Console.WriteLine($" Evatuate(): {_minimax.Evaluate()}");
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
