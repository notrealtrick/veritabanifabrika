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
    public partial class uyeGuncelle : Form
    {
        string tcNo = "";
        string Parola = "";
        public uyeGuncelle()
        {
            InitializeComponent();
        }
        public uyeGuncelle(string tc, string parola)
        {
            InitializeComponent();
            tcNo = tc;
            Parola = parola;
        }

        Giris frm1 = new Giris();


        private void uyeGuncelle_Load(object sender, EventArgs e)
        {

            texboxlarEnteraBasinca();
            try
            {
                using (var conn = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgre; Password = admin; Database = veritabanı_adı"))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT * FROM Uyeler WHERE TC = @tcNo", conn))
                    {
                        cmd.Parameters.AddWithValue("@tcNo", tcNo);
                        using (var rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                maskedtxtTC.Text = frm1.maskedtxtTC.Text;
                                txtAd.Text = rd["Adı"].ToString();
                                txtSoyad.Text = rd["Soyadı"].ToString();
                                
                                txtParola.Text = "";
                                txtParolaTekrar.Text = "";
                                if (rd["Cinsiyeti"].ToString() == "Bay")
                                {
                                    radioButton1.Checked = true;
                                }
                                else if (rd["Cinsiyeti"].ToString() == "Bayan")
                                {
                                    radioButton2.Checked = true;
                                }
                            }
                        }
                    }
                }

                frm1.connsql.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        bool hata_Varmi = false;
        bool eposta_Hatalimi = false;
        bool parola_Hatalimi = false;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            foreach (Control kontroller in this.Controls)
            {
                if (kontroller is MaskedTextBox || kontroller is TextBox)
                {
                    if (kontroller.Text.Trim() == "" || maskedtxtTC.Text.Length != 11 || maskedtxtDogumTarihi.Text.Length != 10 )
                    {
                        hata_Varmi = true;
                        break;
                    }
                    else
                        hata_Varmi = false;
                }
            }

            ///PAROLA KONTROLU
            if (txtEskiParola.Text == Parola)
            {

                if (txtParola.Text != txtParolaTekrar.Text)
                {
                    errorProviderPAROLA.SetError(txtParola, "Parolala Eşleşmiyor");
                    parola_Hatalimi = true;
                }
                else
                {
                    errorProviderPAROLA.Dispose();
                    parola_Hatalimi = false;
                }
            }
            else
            {
                parola_Hatalimi = true;
                MessageBox.Show("Parola Hatalı");
            }
            ///PAROLA KONTROLU

            if (hata_Varmi || eposta_Hatalimi || parola_Hatalimi)
            {
                errorProvider1.SetError(btnKaydet, "Bilgileri Kontrol Edin");
            }

            //KONTROLLER TAMAM
            if (hata_Varmi == false && eposta_Hatalimi == false && parola_Hatalimi == false)
            {
                foreach (Control kontroller in this.Controls)
                {
                    kontroller.Enabled = false;
                }

                errorProvider1.Dispose();
                uyeEkle();
            }
        }

        void texboxlarEnteraBasinca()
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

        void uyeEkle()
        {

            string cinsiyet = "Seçilmedi";
            if (radioButton1.Checked == true)
                cinsiyet = "Bay";
            if (radioButton2.Checked == true)
                cinsiyet = "Bayan";


            try
            {
                KontrollerPasif();
                frm1.conn.Open();

                using (frm1.conn)
                {
                    frm1.conn.Open();
                    tcNo = maskedtxtTC.ToString();

                    using (var cmdUpdate = new NpgsqlCommand("UPDATE uyeler SET Adı = @name, Soyadı = @surname, DogumTarihi = @birthDate, Parola = @password, Cinsiyeti = @gender WHERE TC = @tcNo WHERE TC= @tcNo", frm1.conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@name", txtAd.Text);
                        cmdUpdate.Parameters.AddWithValue("@surname", txtSoyad.Text);
                        cmdUpdate.Parameters.AddWithValue("@birthDate", maskedtxtDogumTarihi.Text);
                        cmdUpdate.Parameters.AddWithValue("@password", txtParola.Text);
                        cmdUpdate.Parameters.AddWithValue("@gender", cinsiyet);
                        cmdUpdate.Parameters.AddWithValue("@tcNo", tcNo);

                        cmdUpdate.ExecuteNonQuery();
                        MessageBox.Show("İşlem Başarılı");
                    }
                    frm1.connsql.Close();
                    this.Close();
                }
            }
            catch (Exception mse)
            {
                MessageBox.Show(mse.Message);
                frm1.connsql.Close();
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
                if (txt is TextBox)
                {
                    txt.Text = "";
                    maskedtxtDogumTarihi.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedtxtTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedtxtDogumTarihi_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

