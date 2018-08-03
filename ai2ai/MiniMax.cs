using System;
using System.Collections.Generic;
using static ai2ai.OyunAlani;

namespace ai2ai
{
    public class MiniMax
    {
        public static Hamle? TheBest(OyunAlani alan, Oyuncu o)
        {
            Hamle? eniyiHamle = null;
            List<Hamle> kullanilabilir = alan.Kullanilabilir;
            foreach (Hamle hamle in kullanilabilir)
            {
                OyunAlani yeniAlan = alan.Kopyala();
                Hamle yeniHamle = hamle;
                yeniAlan[yeniHamle.X, yeniHamle.Y] = o;
                if (yeniAlan.Kazanan == Oyuncu.Berabere && yeniAlan.Kullanilabilir.Count > 0)
                {
                    var iyi = TheBest(yeniAlan, ((Oyuncu)(-(int)o)));
                    if (iyi != null)
                        yeniHamle.Deger = iyi.Value.Deger;
                }
                else
                {
                    switch (yeniAlan.Kazanan)
                    {
                        case Oyuncu.X:
                            yeniHamle.Deger = -1;
                            break;
                        case Oyuncu.O:
                            yeniHamle.Deger = 1;
                            break;
                        case Oyuncu.Berabere:
                            yeniHamle.Deger = 0;
                            break;
                        default:
                            break;
                    }
                }
                if (eniyiHamle == null || (o == Oyuncu.X && yeniHamle.Deger < ((Hamle)eniyiHamle).Deger) || (o == Oyuncu.O && yeniHamle.Deger > ((Hamle)eniyiHamle).Deger))
                    eniyiHamle = yeniHamle;
            }
            return eniyiHamle;

        }
    }
}