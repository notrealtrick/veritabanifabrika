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
    public partial class Giris : Form
    {

        public Giris()
        {
            InitializeComponent();
        }
        public NpgsqlConnection connsql = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgre; Password=admin; Database=veritabanı_adı");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool Admin_Girdimi = false;
        void Admin_Girisi()
        {
            if (maskedtxtTC.Text == "00000000000" && txtParola.Text == "0")
            {
                AdminPaneli AmdPanel = new AdminPaneli();
                AmdPanel.Show();
                this.Hide();
                Admin_Girdimi = true;
            }
        }

        void Admin_Girisi2()
        {
            string tc = maskedtxtTC.Text;
            string sifre = txtParola.Text;
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM users WHERE tc = @tc AND sifre = @sifre AND gorevid=100";//gorevid100 admin
            cmd.Parameters.AddWithValue("@tc", tc);
            cmd.Parameters.AddWithValue("@sifre", sifre);

        }

        public NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port=5432; User Id = postgre; Password=admin; Database=veritabanı_adı");
        void Uye_Girisi()
        {
            // textBoxtc ve textBoxsifre nesnelerinden değerleri al
            string tc = maskedtxtTC.Text;
            string sifre = txtParola.Text;

            // Veritabanına bağlanmak için NpgsqlConnection nesnesi oluştur
            string connString = "Server = localhost; Port = 5432; User Id = postgre; Password = admin; Database = veritabanı_adı";
            NpgsqlConnection conn = new NpgsqlConnection(connString);

            try
            {
                // Veritabanına bağlan
                conn.Open();

                // Veritabanında bir tablo üzerinde işlem yapmak için NpgsqlCommand nesnesi oluştur
                NpgsqlCommand cmd = new NpgsqlCommand();

                // SQL sorgusu gönder
                cmd.CommandText = "SELECT COUNT(*) FROM users WHERE tc = @tc AND sifre = @sifre";
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                // Sorgunun sonucunu oku
                int count = (int)cmd.ExecuteScalar();

                // Eğer sonuç 0'dan büyükse, veritabanında kayıtlı bir kullanıcı olduğu anlamına gelir
                if (count > 0)
                {
                    // kullaniciSayfasi nesnesini oluştur ve kullaniciSayfasi'ni aç
                    kullaniciSayfasi kullaniciSayfasi = new kullaniciSayfasi();
                    kullaniciSayfasi.Show();
                }
                else
                {
                    // Veritabanında kayıtlı bir kullanıcı bulunamadı, uyarı mesajı göster
                    MessageBox.Show("Girilen kullanıcı adı ve şifre bilgilerine göre veritabanında kayıtlı bir kullanıcı bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                connsql.Close();
                MessageBox.Show("Bağlantı Sağlanamadı");
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Admin_Girisi2();
            
            if (Admin_Girdimi == false)
            {
                Uye_Girisi();
            }
        }

        private void btnYeniUye_Click(object sender, EventArgs e)
        {
            yeniUye yeniuye = new yeniUye();
            yeniuye.ShowDialog();
        }

        private void maskedtxtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtParola_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnGiris_Click(sender, e);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            connsql.Close();
        }

        private void maskedtxtTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtParola_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
