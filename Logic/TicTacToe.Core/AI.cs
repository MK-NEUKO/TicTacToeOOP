using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public class AI : IAI
    {
        #region Minimax Aögorythmus Wikipedia
        /*
           gespeicherterZug = NULL;
           int gewuenschteTiefe = 4;

           int bewertung = max(gewuenschteTiefe, -unendlich, +unendlich);

           if (gespeicherterZug == NULL)
               es gab keine weiteren Zuege mehr(Matt oder Patt);
           else
               gespeicherterZug ausführen;



           int max(int tiefe, int alpha, int beta)
           {
               if (tiefe == 0 or keineZuegeMehr(spieler_max))
                   return bewerten();
               int maxWert = alpha;
               Zugliste = generiereMoeglicheZuege(spieler_max);
               for each (Zug in Zugliste)
               {
                   fuehreZugAus(Zug);
                   int wert = min(tiefe-1, maxWert, beta);
                   macheZugRueckgaengig(Zug);
                   if (wert > maxWert)
                   {
                       maxWert = wert;
                       if (tiefe == gewuenschteTiefe)
                       gespeicherterZug = Zug;
                       if (maxWert >= beta)
                           break;
                   }
           }
           return maxWert;



           int min(int spieler, int tiefe) 
           {
               if (tiefe == 0 or keineZuegeMehr(spieler))
                   return bewerten();
               int minWert = unendlich;
               generiereMoeglicheZuege(spieler);
               while (noch Zug da) 
               {
                   fuehreNaechstenZugAus();
                   int wert = max(-spieler, tiefe-1);
                   macheZugRueckgaengig();
                   if (wert < minWert) 
                   {
                       minWert = wert;
                   }
               }
               return minWert;
           }
           */
        #endregion

        private IList<GameBoardArea> _evaluationList;
        private IGameBoard _board;
        private readonly int[,] _winConstellation;
        private int _valuation;

        public AI(IList<GameBoardArea> evaluationList, IGameBoard board)
        {
            _evaluationList = evaluationList;
            _board = board;
            _winConstellation = new int[8, 3]
            {
                {0,1,2}, /* +---+---+---+*/
                {3,4,5}, /* | 0 | 1 | 2 |*/
                {6,7,8}, /* +---+---+---+*/
                {0,3,6}, /* | 3 | 4 | 5 |*/
                {1,4,7}, /* +---+---+---+*/
                {2,5,8}, /* | 6 | 7 | 8 |*/
                {0,4,8}, /* +---+---+---+*/
                {2,4,6},
            };
        }

        // ergibt 10 wenn X gewonnen hat
        // ergibt -10 wenn O gewonnen hat
        // ergibt 0 bei Unentschieden
        // ergibt -1 wenn alles offen ist

        public int Evaluate()
        {
            for (int i = 0; i < 8; i++)
            {
                string actualContent = _evaluationList[_winConstellation[i, 0]].Area;
                actualContent += _evaluationList[_winConstellation[i, 1]].Area;
                actualContent += _evaluationList[_winConstellation[i, 2]].Area;

                if (actualContent == "XXX")
                    return 10;

                if (actualContent == "OOO")
                    return -10;

            }

            foreach (GameBoardArea area in _evaluationList)
            {
                if (!area.AreaHasToken)
                    return -1;
            }
            return 0;
        }

        public void ShowAITest()
        {
            _evaluationList = _board.BoardAreaList;
            Console.WriteLine(Evaluate());
        }
    }
}