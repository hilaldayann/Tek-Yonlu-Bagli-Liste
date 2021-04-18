using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ödev
{
    public partial class Form1 : Form
    {
        public class Dugum
        {
            public string ad;
            public string soyad;
            //public string dogum; // neden int kabul etmedi 
            //public string tel;
            public int no;
            public Dugum sonraki;

        }

        Dugum ilk = null;
        Dugum son = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dugum yeni = new Dugum();
            yeni.ad = textBox1.Text;
            yeni.soyad = textBox2.Text;
            //yeni.dogum = maskedTextBox1.Text;
            //yeni.tel = maskedTextBox2.Text;
            yeni.no = Convert.ToInt32(textBox4.Text);
            if (ilk == null)
            {
                ilk = yeni;
                son = ilk;
                ilk.sonraki = yeni;
                son.sonraki = null;
            }
            else
            {
                yeni.sonraki = ilk;
                ilk = yeni;
                son.sonraki = null;//burası emin değilim
            }
        }

        private void arayaEkle()
        {
            Dugum yeni = new Dugum();
            int aranan = Convert.ToInt32(textBox3.Text);
            yeni.ad = textBox1.Text;
            yeni.soyad = textBox2.Text;
            yeni.no = Convert.ToInt32(textBox4.Text);
            Dugum gecici = ilk;
            while (gecici.sonraki != null)
            {
                if (gecici.no == aranan)
                {
                    yeni.sonraki = gecici.sonraki;
                    gecici.sonraki = yeni;
                    break;
                }
                else
                {
                    gecici = gecici.sonraki;
                }

            }
            if (gecici == son && gecici.no == aranan)
            {
                son.sonraki = yeni;
                son = yeni;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            arayaEkle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dugum yeni = new Dugum();
            yeni.ad = textBox1.Text;
            yeni.soyad = textBox2.Text;
            yeni.no = Convert.ToInt32(textBox4.Text);
            if (ilk == null)
            {
                ilk = yeni;
                son = ilk;
                ilk.sonraki = yeni;
                son.sonraki = null;
            }
            else
            {
                son.sonraki = yeni;
                son = yeni;
                son.sonraki = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                if (ilk == son)
                {
                    ilk = null;
                    son = null;
                }
                else
                {
                    Dugum yeniBas = ilk.sonraki; 
                    ilk.sonraki = null;
                    ilk = yeniBas;
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox4.Text);
            int aranan = Convert.ToInt32(textBox3.Text);

            Dugum yedek = ilk;
            Dugum once = null;

            while (yedek != null)
            {
                if (yedek.no == aranan)
                {
                    break;
                }
                else
                {
                    once = yedek;
                    yedek = yedek.sonraki;
                }
            }
            if (once == null)
            {
                ilk = ilk.sonraki;
            }
            else if (once != null)
            {
                once.sonraki = yedek.sonraki;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ilk == son)
                {                   
                    ilk = null;
                    son = null;
                }
                else
                {
                    Dugum isaretci = ilk;
                    while (isaretci.sonraki != son)
                    {
                        isaretci = isaretci.sonraki;
                    }
                    isaretci.sonraki = null;
                    son = isaretci;
                }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listeyiYazdir(ilk);
        }

        private void listeyiYazdir(Dugum ilk)
        {
            richTextBox1.Text = null;
            int sayac = 0;
            richTextBox1.Text += "Listemiz : ";
            while (ilk != null)
            {
                richTextBox1.Text += "\n";
                richTextBox1.Text += ilk.ad + " : " + ilk.soyad + " : " + ilk.no.ToString() + " : " /*+ ilk.dogum.ToString() + " : " + ilk.tel.ToString() +*/ + "  -----  ";
                richTextBox1.Text += " --> ";
                ilk = ilk.sonraki;
                sayac++;
            }
            richTextBox1.Text += "null";
            richTextBox1.Text += "\n";
            richTextBox1.Text += "  " + (sayac) + " Tane Eleman Var";
        }
    }
}
