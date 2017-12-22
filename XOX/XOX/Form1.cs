using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static XOX.OyunAlani;

namespace XOX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // int[,] dizi;
        Button[,] butonDizi;
        private OyunAlani alan;
        private void Form1_Load(object sender, EventArgs e)
        {
            ciz();          
        }
        public int[] butonunKonumu(Button b)
        {
            int[] dizi = new int[2];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (butonDizi[i, j] == b)
                    {
                        dizi[0] = i;
                        dizi[1] = j;
                        break;
                    }
                }
            }
            return dizi;
            
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
                    b.Click += delegate { Kullanici(b, new EventArgs(), new Hamle(butonunKonumu(b)[0], butonunKonumu(b)[1])); };//*************
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
      
        private void Kullanici(object sender, EventArgs e,Hamle? hamle)
        {
            if (hamle != null)
            {
                alan[hamle.Value.X, hamle.Value.Y] = Oyuncu.O;
                move();
                var eniyihamle = MiniMax.TheBest(alan, Oyuncu.X);
                if (eniyihamle != null)
                    hamle = (Hamle)eniyihamle;
                else
                    hamle = null;
                if (hamle != null)
                    alan[hamle.Value.X, hamle.Value.Y] = Oyuncu.X;
            }
            move();
            if (kimkazandi() != null)
            {
                String text = kimkazandi();
                lblKazanan.Text = text;
                MessageBox.Show("Oyun Sonu!" + text);
                foreach (Button b in butonDizi)
                    b.Enabled = false;
                lblKazanan.Visible = true;
            }
            if (kimkazandi() == null)
                lblKazanan.Text = kimkazandi();
            lblKazanan.Visible = true;
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
        private void kilitle(int i,int j)
        {
            butonDizi[i, j].Enabled = false;
        }
        public string kimkazandi()
        {
            switch (alan.Kazanan)
            {
                case Oyuncu.X:
                    return "yapay zeka kazandı";
                case Oyuncu.O:
                    return "siz kazandınız";
                default:
                    if (alan.Dolu)
                        return "berabere";
                    break;
            }
            return null;
        }

        private void btnYenidenBasla_Click(object sender, EventArgs e)
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
           
        }
    }
}
