using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Npgsql;

namespace veritabanifabrika
{
    public partial class yeniUye : Form
    {

        public yeniUye()
        {
            InitializeComponent();
        }

        
        Giris frm1 = new Giris();

        private void yeniUye_Load(object sender, EventArgs e)
        {
            foreach (Control txt in this.Controls)
            {
                if (txt is TextBox || txt is MaskedTextBox || txt is RadioButton)
                {
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                }
                if (txt is TextBox || txt is MaskedTextBox)
                {
                    txt.Text = "";
                }
                if (txt is MaskedTextBox)
                {
                    txt.Text = "1";
                    txt.Text = "";
                }
            }
        }

        void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }


        bool hata_Varmi = false;

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            uyeEkle();
        }

        void uyeEkle()
        {
            string tc = maskedtxtTC.ToString();
            string sifre = txtParola.ToString();
            string cinsiyet = "";
            if (radioButton1.Checked == true)
                cinsiyet = "Bay";
            if (radioButton2.Checked == true)
                cinsiyet = "Bayan";

            try
            {
                KontrollerPasif();
                bool oncedenKayitYapilmismi = false;
                frm1.conn.Open();
                // Veritabanında bir tablo üzerinde işlem yapmak için NpgsqlCommand nesnesi oluştur
                NpgsqlCommand cmd = new NpgsqlCommand();
                

                // SQL sorgusu gönder
                cmd.CommandText = "SELECT COUNT(*) FROM uyeler WHERE tc = @tc AND sifre = @sifre";
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.ExecuteNonQuery();
                int count = (int)cmd.ExecuteScalar();

                    if (count>0)
                    {
                        MessageBox.Show("Daha Önceden Kaydınız Bulunmaktadır.");
                        oncedenKayitYapilmismi = true;
                        KontrollerEtkin();
                        this.Close();
                    }
                

                if (oncedenKayitYapilmismi == false)
                {
                    // SQL sorgusu gönder
                    cmd.CommandText = "INSERT INTO uyeler WHERE tc = @tc AND sifre = @sifre";
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@sifre", sifre); 
                    cmd.ExecuteNonQuery();


                    frm1.conn.Close();
                    MessageBox.Show("İşlem Başarılı");
                    this.Close();
                    kontrolleriTemizleme();

                    frm1.conn.Close();
                }

            }
            catch (Exception mse)
            {
                MessageBox.Show(mse.Message);
                kontrolleriTemizleme();
                this.Close();
            }

        }
        void kontrolleriTemizleme()
        {
            foreach (Control kontrol in this.Controls)
            {
                if (kontrol is MaskedTextBox || kontrol is TextBox)
                {
                    kontrol.Text = null;
                }
                kontrol.Enabled = true;
            }
        }

        void KontrollerPasif()
        {
            foreach (Control asd in this.Controls)
            {
                asd.Enabled = false;
            }
        }
        void KontrollerEtkin()
        {
            foreach (Control asd in this.Controls)
            {
                asd.Enabled = true;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (Control txt in this.Controls)
            {
                if (txt is TextBox || txt is MaskedTextBox)
                {
                    txt.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yeniUye_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm1.conn.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedtxtTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtParola_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
