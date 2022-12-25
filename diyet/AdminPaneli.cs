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
    public partial class AdminPaneli : Form
    {
        public AdminPaneli()
        {
            InitializeComponent();
        }

        Giris frm1 = new Giris();
        int uye_Sayisi = 0;

        private void AdminPaneli_Load(object sender, EventArgs e)
        {
            UyeleriGetir();
            uyeSayisiHesapla();

        }

        private void AdminPaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Giris frm1 = new Giris();
            frm1.Show();
            this.Hide();
        }

        private void timerSaat_Tick(object sender, EventArgs e)
        {
            DateTime dateSaat = DateTime.Now;
            lblSaat.Text = dateSaat.ToLongTimeString();
            lblTarih.Text = dateSaat.ToLongDateString();
        }

        void UyeleriGetir()
        {
            listView1.Items.Clear();
            int i = 0;
            try
            {
                frm1.conn.Open();
                // Veritabanında bir tablo üzerinde işlem yapmak için NpgsqlCommand nesnesi oluştur
                NpgsqlCommand cmd = new NpgsqlCommand();
                // SQL sorgusu gönder
                cmd.CommandText = "SELECT * FROM uyeler ";
                cmd.ExecuteNonQuery();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    listView1.Items.Add(rd["TC"].ToString());
                    listView1.Items[i].SubItems.Add(rd["Adı"].ToString());
                    listView1.Items[i].SubItems.Add(rd["Soyadı"].ToString());
                    listView1.Items[i].SubItems.Add(rd["Gorevid"].ToString());
                    listView1.Items[i].SubItems.Add(rd["Maas"].ToString());
                    listView1.Items[i].SubItems.Add(rd["Dogumtarihi"].ToString());
                    listView1.Items[i].SubItems.Add(rd["Cinsiyet"].ToString());

                    i++;
                }
                frm1.conn.Close();
            }
            catch (Exception)
            {

            }
        }

        private void btnUyeSil_Click(object sender, EventArgs e)
        {
            string TC = "";
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem itm = listView1.SelectedItems[0];
                TC = itm.SubItems[0].Text;
            }
            try
            {
                frm1.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("Delete * From Uyeler where TC='" + TC + "'", frm1.conn);
                cmd.ExecuteNonQuery();
                frm1.conn.Close();
                UyeleriGetir();
                uye_Sayisi = 0;
                uyeSayisiHesapla();
            }
            catch (Exception)
            {
                frm1.conn.Close();
                MessageBox.Show("Beklenmeyen hata");
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TC = "";
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem itm = listView1.SelectedItems[0];
                TC = itm.SubItems[0].Text;
            }


            try
            {
                frm1.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * From Uyeler where TC='" + TC + "'", frm1.conn);
                cmd.ExecuteNonQuery();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                frm1.conn.Close();
            }
            catch (Exception)
            {
                frm1.conn.Close();
                MessageBox.Show("Beklenmeyen hata");
            }
        }
        void uyeSayisiHesapla()
        {
            try
            {
                frm1.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * From Uyeler", frm1.conn);
                cmd.ExecuteNonQuery();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    uye_Sayisi++;
                }
                frm1.conn.Close();
                lblUyeSayisi.Text = "Sistemde " + uye_Sayisi + " Adet Üye Bulunmaktadır";
            }
            catch (Exception)
            {
                frm1.conn.Close();
                MessageBox.Show("Beklenmeyen hata");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Giris frm1 = new Giris();
            frm1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
