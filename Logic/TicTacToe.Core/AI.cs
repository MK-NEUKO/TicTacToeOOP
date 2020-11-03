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
        private string[] _testGameBoard;
        private int _areaIDForX;
        private int _areaIDForO;

        

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

            _testGameBoard = new string[9]
            {
                " ","O"," ",
                "X"," ","O",
                " ","X","O"
            };
        }

        public int AreaIDForO { get => _areaIDForO; }

        public int AreaIDForX { get => _areaIDForX; }


        // ergibt 2 wenn X gewonnen hat
        // ergibt 0 wenn O gewonnen hat
        // ergibt 1 bei Unentschieden
        // ergibt -1 wenn alles offen ist

        private int Evaluate()
        {
            _evaluationList = _board.BoardAreaList;

            for (int i = 0; i < 8; i++)
            {
                string actualContent = _evaluationList[_winConstellation[i, 0]].Area;
                actualContent += _evaluationList[_winConstellation[i, 1]].Area;
                actualContent += _evaluationList[_winConstellation[i, 2]].Area;

                if (actualContent == "XXX")
                    return 2;

                if (actualContent == "OOO")
                    return 0;

            }

            foreach (GameBoardArea area in _evaluationList)
            {
                if (!area.AreaHasToken)
                    return -1;
            }
            return 1;
        }

        private int Min()
        {
            if (Evaluate() != -1)
                return Evaluate();

            int minValue = 999;

            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    int max = Max();
                    if (max < minValue)
                        minValue = max;
                    area.Area = " ";
                }
            }
            return minValue;
        }

        private int Max()
        {
            if (Evaluate() != -1)
                return Evaluate();

            int maxValue = -999;

            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    int min = Min();
                    if (min > maxValue)
                        maxValue = min;
                    area.Area = " ";
                }
            }
            return maxValue;
        }


        public int GetAreaIDForX()
        {
            if (Evaluate() != -1)
                return Evaluate();

            int maxValue = -999;

            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    int min = Min();
                    if (min > maxValue)
                    {
                        maxValue = min;
                        _areaIDForX = area.AreaID;
                    }
                    area.Area = " ";
                }
            }
            return maxValue;
        }

        public int GetAreaIDForO()
        {
            if (Evaluate() != -1)
                return Evaluate();

            int minValue = 999;

            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    int max = Max();
                    if (max < minValue)
                    {
                        minValue = max;
                        _areaIDForO = area.AreaID;
                    }                       
                    area.Area = " ";
                }
            }
            return minValue;
        }

        public void ShowAITest()
        {
            //_evaluationList = _board.BoardAreaList;
            //for (int i = 0; i < 9; i++)
            //{
            //    _evaluationList[i].Area = _testGameBoard[i];
            //}

            Console.WriteLine("#### TestGameBoard ####");
            for (int i = 0; i < 9; i++)
            {
                if(i == 3 || i == 6)
                    Console.WriteLine();
                Console.Write("| {0} |", _evaluationList[i].Area);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Evaluate..: " + Evaluate());
            Console.WriteLine("Min.......: " + Min() + " ||  AreaIDForX..: " + GetAreaIDForX());
            Console.WriteLine("Max.......: " + Max() + " ||  AreaIDForO..: " + GetAreaIDForO());
            Console.WriteLine();
        }      
    }
}