using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    class AI
    {
        // Auszug aus Wikipedia
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
for each (Zug in Zugliste) {
fuehreZugAus(Zug);
int wert = min(tiefe-1,
              maxWert, beta);
macheZugRueckgaengig(Zug);
if (wert > maxWert) {
  maxWert = wert;
  if (tiefe == gewuenschteTiefe)
     gespeicherterZug = Zug;
  if (maxWert >= beta)
     break;
}
}
return maxWert;
}
}
}


int min(int spieler, int tiefe) {
if (tiefe == 0 or keineZuegeMehr(spieler))
return bewerten();
int minWert = unendlich;
generiereMoeglicheZuege(spieler);
while (noch Zug da) {
fuehreNaechstenZugAus();
int wert = max(-spieler, tiefe-1);
macheZugRueckgaengig();
if (wert < minWert) {
  minWert = wert;
}
}
return minWert;
}
