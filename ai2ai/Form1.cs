using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ai2ai.OyunAlani;

namespace ai2ai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] butonDizi;
        private OyunAlani alan;
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Button item in butonDizi)
            {
                item.Enabled = true;
                item.Text = "";
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    alan[i, j] = Oyuncu.Berabere;
                }
            }
            Kullanici(sender, e, MiniMax.TheBest(alan, Oyuncu.O),Oyuncu.O);
        }
        public string kimkazandi()
        {
            switch (alan.Kazanan)
            {
                case Oyuncu.X:
                    return "X kazandı";
                case Oyuncu.O:
                    return "Y kazandı";
                default:
                    if (alan.Dolu)
                        return "berabere";
                    break;
            }
            return null;
        }
        private void kilitle(int i, int j)
        {
            butonDizi[i, j].Enabled = false;
        }
        private void move()
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (alan[i, j] != Oyuncu.Berabere)
                    {
                        String text = alan[i, j] == Oyuncu.O ? "O" : "X";
                        butonDizi[i, j].Text = text;
                        kilitle(i, j);
                    }
                }
            }
        }
        //kullanıcı
        private void Kullanici(object sender, EventArgs e, Hamle? hamle, Oyuncu o)
        {
            if (hamle != null)
            {
                alan[hamle.Value.X, hamle.Value.Y] = o;
                move();
                if (o == Oyuncu.O)
                {
                    var eniyihamle = MiniMax.TheBest(alan, Oyuncu.X);
                    if (eniyihamle != null)
                        hamle = (Hamle)eniyihamle;
                    else
                        hamle = null;
                    if (hamle != null)
                        alan[hamle.Value.X, hamle.Value.Y] = Oyuncu.X;
                }
                else if (o == Oyuncu.X)
                {
                    var eniyihamle = MiniMax.TheBest(alan, Oyuncu.O);
                    if (eniyihamle != null)
                        hamle = (Hamle)eniyihamle;
                    else
                        hamle = null;
                    if (hamle != null)
                        alan[hamle.Value.X, hamle.Value.Y] = Oyuncu.O;
                }
            }
            move();
            if (kimkazandi() != null)
            {
                String text = kimkazandi();
                label1.Text = text;
                MessageBox.Show("Oyun Sonu!" + text);
                foreach (Button b in butonDizi)
                    b.Enabled = false;
                label1.Visible = true;
            }
            else
            { 
                Kullanici(sender, e, MiniMax.TheBest(alan, o),o);
            }
         
        }

        private void ciz()
        {
            int sayi = 3;
            butonDizi = new Button[sayi, sayi];
            // dizi = new int[sayi, sayi];
            int i, j;
            int point1 = 0, point2 = 0;
            for (i = 0; i < sayi; i++)
            {
                for (j = 0; j < sayi; j++)
                {

                    // dizi[i, j] = (int)Oyuncu.Berabere;
                    Button b = new Button();
                    b.FlatStyle = FlatStyle.Flat;
                    b.Top = point2;
                    b.Left = point1;
                    b.Height = 100;
                    b.Width = 100;
                    b.Tag = i + "," + j;
                    //b.Click += delegate { Kullanici(b, new EventArgs(), new Hamle(butonunKonumu(b)[0], butonunKonumu(b)[1])); };//*************
                    panel1.Controls.Add(b);
                    butonDizi[i, j] = b;
                    if (j == 2)
                    {
                        point1 = 0;
                        point2 += 100;
                    }
                    else
                    {
                        point1 += 100;
                    }

                }
            }
            alan = new Game();
            move();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ciz();
        }
    }


}
