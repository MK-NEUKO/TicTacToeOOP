using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    class AI
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
        private int _valuation;

        public AI(IList<GameBoardArea> evaluationList, IGameBoard board)
        {
            _evaluationList = evaluationList;
            _board = board;
        }

        // ergibt 10 wenn X gewonnen hat
        // ergibt -10 wenn O gewonnen hat
        // ergibt 0 bei Unentschieden
        // ergibt -1 wenn alles offen ist
        //public void Evaluate()
        //{
        //    CheckForWinner();
        //    if (_valuation == 10 || _valuation == -10)
        //        return;
        //    foreach (GameBoardArea area in _evaluationList)
        //    {
        //        if (!area.AreaHasToken)
        //            _valuation = -1;
        //    }
        //}



        //public void CheckForWinner()
        //{
        //    for (int winConstellation = 0; winConstellation < 8; winConstellation++)
        //    {
        //        if (winConstellation == 0) CheckTheWinConstellation(0, 1, 2);
        //        if (winConstellation == 1) CheckTheWinConstellation(3, 4, 5);
        //        if (winConstellation == 2) CheckTheWinConstellation(6, 7, 8);
        //        if (winConstellation == 3) CheckTheWinConstellation(0, 3, 6);
        //        if (winConstellation == 4) CheckTheWinConstellation(1, 4, 7);
        //        if (winConstellation == 5) CheckTheWinConstellation(2, 5, 8);
        //        if (winConstellation == 6) CheckTheWinConstellation(0, 4, 8);
        //        if (winConstellation == 7) CheckTheWinConstellation(2, 4, 6);
        //    }
        //}

        //private void CheckTheWinConstellation(int areaIDOne, int areaIDTwo, int areaIDThree)
        //{
        //    string actualContent = _evaluationList[areaIDOne].Area;
        //    actualContent += _evaluationList[areaIDTwo].Area;
        //    actualContent += _evaluationList[areaIDThree].Area;

        //    if (actualContent == "XXX")
        //    {
        //        _valuation = 10;
        //    }
        //    else if (actualContent == "OOO")
        //    {
        //        _valuation = -10;
        //    }

        //}
    }
}