using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.TestConsole
{
    public class VisualMiniMax
    {
        private TestData _testData;
        private MiniMax _minimax;

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
                Console.WriteLine($" Evatuate(): {_minimax.Evaluate()}");
            } while (true);
        }
    }
}
