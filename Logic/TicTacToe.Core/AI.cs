using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public class AI : IAI
    {
        #region Minimax Algorythmus Wikipedia
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
        private readonly double[] _boardAreaFineValue;
        private int _areaIDForX;
        private int _areaIDForO;
        private int _maximumDepth;

        

        public AI(IList<GameBoardArea> evaluationList, IGameBoard board)
        {
            _evaluationList = evaluationList;
            _board = board;
            _maximumDepth = 10;
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

            _boardAreaFineValue = new double[9]
            {
                0.03,0.02,0.03,
                0.02,0.04,0.02,
                0.03,0.02,0.03
            };
        }

        public int AreaIDForO { get => _areaIDForO; }
        public int AreaIDForX { get => _areaIDForX; }
        public int MaximumDepth { get => _maximumDepth; set => _maximumDepth = value; }


        // ergibt 2 wenn X gewonnen hat
        // ergibt 0 wenn O gewonnen hat
        // ergibt 1 bei Unentschieden
        // ergibt -1 wenn alles offen ist
        private int EvaluateGameBoard()
        {
            _evaluationList = _board.BoardAreaList;

            //for (int i = 0; i < 9; i++)
            //{
            //    _evaluationList[i].Area = _testGameBoard[i];
            //}

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
                if (area.Area == " ")
                    return -1;
            }
            return 1;
        }

        private double EvaluateBoardAreas()
        {
            double value = 1;
            int i = 0;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == "O")
                    value -= _boardAreaFineValue[i];
                if (area.Area == "X")
                    value += _boardAreaFineValue[i];
                i++;
            }
            return value;
        }

        private double Min(int depth, double alpha, double beta)
        {
            if (EvaluateGameBoard() != -1)
                return EvaluateGameBoard();
            if (depth == 0)
                return EvaluateBoardAreas();

            //double minValue = 999;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    double max = Max(depth - 1, alpha, beta);
                    area.Area = " ";
                    if (max < beta)
                        beta = max;
                    if (beta <= alpha)
                        return alpha;
                }
            }
            return beta;
        }

        private double Max(int depth, double alpha, double beta)
        {
            if (EvaluateGameBoard() != -1)
                return EvaluateGameBoard();
            if (depth == 0)
                return EvaluateBoardAreas();
            
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    double min = Min(depth - 1, alpha, beta);
                    area.Area = " ";
                    if (min > alpha)
                        alpha = min;
                    if (alpha >= beta)
                        return beta;
                }
            }
            return alpha;
        }


        public double GetAreaIDForX()
        {
            if (EvaluateGameBoard() != -1)
                return EvaluateGameBoard();

            double alpha = -999;
            double beta = 999;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "X";
                    double min = Min(_maximumDepth, alpha, beta);
                    area.Area = " ";
                    if (min > alpha)
                    {
                        alpha = min;
                        _areaIDForX = area.AreaID;
                    }                    
                }
            }
            return alpha;
        }

        public double GetAreaIDForO()
        {
            if (EvaluateGameBoard() != -1)
                return EvaluateGameBoard();

            double alpha = -999;
            double beta = 999;
            foreach (GameBoardArea area in _evaluationList)
            {
                if (area.Area == " ")
                {
                    area.Area = "O";
                    double max = Max(_maximumDepth, alpha, beta);
                    area.Area = " ";
                    if (max < beta)
                    {
                        beta = max;
                        _areaIDForO = area.AreaID;
                    }                    
                }
            }
            return beta;
        }

        public void ShowAITest()
        {
            _evaluationList = _board.BoardAreaList;
            //for (int i = 0; i < 9; i++)
            //{
            //    _evaluationList[i].Area = _testGameBoard[i];
            //}

            //Console.WriteLine("#### TestGameBoard ####");
            //for (int i = 0; i < 9; i++)
            //{
            //    if(i == 3 || i == 6)
            //        Console.WriteLine();
            //    Console.Write("| {0} |", _evaluationList[i].Area);
            //}
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Evaluate().......: " + EvaluateGameBoard());
            //Console.WriteLine("Min()............: " + Min());
            //Console.WriteLine("Max()............: " + Max());
            Console.WriteLine("EvaluateBoardAreas().: " + EvaluateBoardAreas());
            Console.WriteLine("GerAreaIDForX()..: " + GetAreaIDForX());
            Console.WriteLine("GetAreaIDForO()..: " + GetAreaIDForO());            
            Console.WriteLine("_areaIDForX......: " + _areaIDForX);
            Console.WriteLine("_areaIDForO......: " + _areaIDForO);
            Console.WriteLine();
        }      
    }
}