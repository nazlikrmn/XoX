using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX
{
    public enum Oyuncu
    {
        X = 1,
        O = -1,
        Berabere = 0
    }
    public abstract class OyunAlani
    {
        public Oyuncu[,] Hamleler;
        public abstract Oyuncu this[int x,int t] { get;set; }
        public abstract bool Dolu { get; }
        public abstract int Boyut { get; }
        public abstract List<Hamle> Kullanilabilir { get; }
        public abstract Oyuncu Kazanan { get; }
        public abstract OyunAlani Kopyala();
        public struct Hamle
        {
            public int X, Y;
            public double Deger;
            public Hamle(int x, int y)
            {
                X = x;
                Y = y;
                Deger = 0;
            }
        }
    }
}
