using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("TCKN doğrulama uygulamasına hoşgeldiniz. \n\nLütfen bütün harfleri büyük giriniz.", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            
        }

        private void btnDogrula_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "" || txtTcKimlik.Text == "" || txtYil.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz.", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Error);  
            }
            else
            {

                long tckimlik = long.Parse(txtTcKimlik.Text);
                int dgmYil = int.Parse(txtYil.Text);

                bool? durum;


                try
                {

                    using (Kimlik.KPSPublicSoapClient servis = new Kimlik.KPSPublicSoapClient())
                    {

                        durum = servis.TCKimlikNoDogrula(tckimlik, txtAd.Text, txtSoyad.Text, dgmYil);

                    }

                }
                catch (Exception)
                {
                    durum = null;

                }

                if (durum != true)
                {
                    MessageBox.Show("TCKN Doğrulanamadı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("TCKN Doğrulandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (Control btn in this.Controls)
            {
                if (btn is TextBox)
                {
                    TextBox tk = (TextBox)btn;
                    tk.Clear();
                    
                }
            }
        }

        private void btnHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TCKN Doğrulama Uygulaması", "Hakkında", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblTCNo_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://asmglr.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
 