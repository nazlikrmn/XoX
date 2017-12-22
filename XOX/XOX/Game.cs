using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX
{
   
    public  class Game:OyunAlani
    {
        public Game()
        {
            Hamleler = new Oyuncu[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public override Oyuncu 
            this[int x, int t]
        { get { return Hamleler[x, t]; }
          set { Hamleler[x, t] = value; } }

        public override bool Dolu
        {
            get
            {
                foreach (Oyuncu item in Hamleler)
                {
                    if (item == Oyuncu.Berabere)
                        return false;
                }
                    return true;
                
            }
        }

        public override int Boyut => 9;

        public override List<Hamle> Kullanilabilir
        {
            get
            {
                List<Hamle> kullanilabilir = new List<Hamle>();
                for (int i = 0; i <=2; i++)
                {
                    for (int j = 0; j <=2; j++)
                    {
                        if (Hamleler[i, j] == Oyuncu.Berabere)
                            kullanilabilir.Add(new Hamle(i, j));
                    }
                }
                return kullanilabilir;
            }
        }

        public override Oyuncu Kazanan
        {
            get
            {
                int count = 0;
                for (int i = 0; i < 3; i++)
                {
                    count = 0;
                    for (int j = 0; j < 3; j++)
                        count += (int)Hamleler[i, j];
                    switch (count)
                    {
                        case 3:return Oyuncu.X;
                        case -3:return Oyuncu.O;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    count = 0;
                    for (int j = 0; j < 3; j++)
                        count += (int)Hamleler[j, i];
                    switch (count)
                    {
                        case 3: return Oyuncu.X;
                        case -3: return Oyuncu.O;
                    }
                }
                count = 0;
                count += (int)Hamleler[0, 0];
                count += (int)Hamleler[1, 1];
                count += (int)Hamleler[2, 2];
                switch (count)
                {
                    case 3: return Oyuncu.X;
                    case -3: return Oyuncu.O;
                }
                count = 0;
                count += (int)Hamleler[0, 2];
                count += (int)Hamleler[1, 1];
                count += (int)Hamleler[2, 0];
                switch (count)
                {
                    case 3: return Oyuncu.X;
                    case -3: return Oyuncu.O;
                }
                return Oyuncu.Berabere;
            }
        }

        public override OyunAlani Kopyala()
        {
            OyunAlani Alan = new Game();
            Alan.Hamleler = (Oyuncu[,])Hamleler.Clone();
            return Alan;
        }
    }
}
