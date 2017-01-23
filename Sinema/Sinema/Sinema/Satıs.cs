using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema
{

    public partial class Satıs : Form
    {
        int secilenKoltukSayisi = 0, toplamFiyat = 0, kisiSayisi = 0, biletDiziGostergeci = 0;
        int sinir = 0;
        List<String> koltuklar = new List<String>();
        string[] biletDizisi = new String[110];
        public Satıs()
        {
            InitializeComponent();
        }

        SqlConnection bag = new SqlConnection("server=DESKTOP-NP65TK1; uid=sa;password=!Q'W3e4r;database=Sinema");
        SqlCommand kmt = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlDataReader dr;


        public int toplam = 0;
        int sufiyat = 0;
        int mesrubatfiyat = 0;
        int omisirfiyat = 0;
        int bmisirfiyat = 0;


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_misirorta.Enabled == true)
                textBox_misirorta.Enabled = false;
            else
                textBox_misirorta.Enabled = true;
        }

        private void Satıs_Load(object sender, EventArgs e)
        {
            CancelButton = button_geri;

            kmt.CommandText = "SELECT *FROM Filmler";
            kmt.Connection = bag;
            kmt.CommandType = CommandType.Text;
            bag.Open();
            dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                comboBox_filmsatis.Items.Add(dr["Filmİsim"]);
            }
            dr.Close();
            bag.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {

            Button btn = (sender as Button);
            if (btn.BackColor == Color.Green)
            {
                btn.BackColor = Color.Blue;
                secilenKoltukSayisi += 1;
                toplamFiyat += 10;
                kisiSayisi += 1;
                biletDizisi[biletDiziGostergeci] = btn.Text;
                biletDiziGostergeci += 1;
            }
            else
            {
                btn.BackColor = Color.Green;
                secilenKoltukSayisi -= 1;
                toplamFiyat -= 10;
                kisiSayisi -= 1;
                biletDizisi[biletDiziGostergeci] = "";
                biletDiziGostergeci -= 1;
            }

            textBox_kisisayisisatis.Text = kisiSayisi.ToString();
            textBox_toplam.Text = toplamFiyat.ToString();
        }

        private void button_geri_Click(object sender, EventArgs e)
        {
            AnaMenu menu = new AnaMenu();
            this.Hide();
            menu.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox_filmsatis_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_seanssatis.Items.Clear();
            textBox_salonsatıs.Text = "";
            kmt.CommandText = "SELECT Seans FROM Seans where FilmID=(select FilmID from Filmler where Filmİsim=@filmad)";
            kmt.Parameters.Clear();
            kmt.Parameters.AddWithValue("@filmad", comboBox_filmsatis.SelectedItem);
            kmt.Connection = bag;
            kmt.CommandType = CommandType.Text;
            bag.Open();
            dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                comboBox_seanssatis.Items.Add(dr["Seans"]);
            }
            dr.Close();
            bag.Close();
            dt.Clear();
            adp.SelectCommand = kmt;
            kmt.CommandText = "select Afis from Filmler where Filmİsim=@filmad";
            adp.Fill(dt);
            pictureBox1.Image = Image.FromFile(dt.Rows[0][0].ToString());
            //MusterBiletEkrani.ActiveForm.Controls.
        }

        private void comboBox_seanssatis_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_satis.Controls.Clear();
            adp.SelectCommand = kmt;
            kmt.CommandText = "SELECT SalonID FROM Seans where Seans=@seans and FilmID=(select FilmID from Filmler where Filmİsim=@filmad)";
            kmt.Parameters.Clear();
            kmt.Parameters.AddWithValue("@filmad", comboBox_filmsatis.SelectedItem);
            kmt.Parameters.AddWithValue("@seans", comboBox_seanssatis.SelectedItem);
            kmt.Connection = bag;
            kmt.CommandType = CommandType.Text;
            bag.Open();
            dr = kmt.ExecuteReader();            
            dr.Read();
            textBox_salonsatıs.Text = dr[0].ToString();
            dr.Close();
            bag.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_su.Enabled == true)
                textBox_su.Enabled = false;
            else
                textBox_su.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_mesrubat.Enabled == true)
                textBox_mesrubat.Enabled = false;
            else
                textBox_mesrubat.Enabled = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_misirbüyük.Enabled == true)
                textBox_misirbüyük.Enabled = false;
            else
                textBox_misirbüyük.Enabled = true;
        }

        private void textBox_su_TextChanged(object sender, EventArgs e)
        {
            ////su5tl
            if (textBox_su.Text == string.Empty)
                sufiyat = 0;
            else
            {
                int girilen = Convert.ToInt32(textBox_su.Text);
                sufiyat = girilen * 5;
            }
            textBox_toplam.Text = sufiyat.ToString();

        }

        private void textBox_mesrubat_TextChanged(object sender, EventArgs e)
        {
            if (textBox_mesrubat.Text == string.Empty)
                mesrubatfiyat = 0;
            else
            {
                int girilen = Convert.ToInt32(textBox_mesrubat.Text);
                mesrubatfiyat = girilen * 8;
            }
            textBox_toplam.Text = mesrubatfiyat.ToString();
        }

        private void textBox_misirorta_TextChanged(object sender, EventArgs e)
        {
            if (textBox_misirorta.Text == string.Empty)
                omisirfiyat = 0;
            else
            {
                int girilen = Convert.ToInt32(textBox_misirorta.Text);
                omisirfiyat = girilen * 18;
            }
            textBox_toplam.Text = omisirfiyat.ToString();
        }

        private void textBox_misirbüyük_TextChanged(object sender, EventArgs e)
        {
            if (textBox_misirbüyük.Text == string.Empty)
                bmisirfiyat = 0;
            else
            {
                int girilen = Convert.ToInt32(textBox_misirbüyük.Text);
                bmisirfiyat = girilen * 25;
            }
            textBox_toplam.Text = bmisirfiyat.ToString();
        }

        private void textBox_toplam_TextChanged(object sender, EventArgs e)
        {
            textBox_toplam.Text = (sufiyat + mesrubatfiyat + omisirfiyat + bmisirfiyat + toplamFiyat).ToString();
        }

        private void textBox_kisisayisisatis_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_salonsatıs_TextChanged(object sender, EventArgs e)
        {
            int i = 0;            
            if (textBox_salonsatıs.Text != String.Empty)
            {                
                dt.Clear();
                kmt.Connection = bag;
                kmt.CommandText = "Select KoltukNo from Bilet where SalonFilmID = (select SalonFilmID from Seans where SalonID=@sid and Seans = @seans)";
                kmt.Parameters.Clear();
                kmt.Parameters.AddWithValue("@sid", Convert.ToInt32(textBox_salonsatıs.Text));
                kmt.Parameters.AddWithValue("@seans", comboBox_seanssatis.Text);
                dr.Close();
                dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    koltuklar.Add(dr[0].ToString());
                }
                dr.Close();                
                dt.Clear();
                kmt.Connection = bag;
                kmt.CommandText = "SELECT KoltukSayisi FROM Salonlar where SalonID=@sid";
                kmt.Parameters.Clear();
                kmt.Parameters.AddWithValue("@sid", Convert.ToInt32(textBox_salonsatıs.Text));
                using (dr = kmt.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sinir = Convert.ToInt32(dr[0]);
                    }
                    dr.Close();
                }
                ButonCiz(sinir, koltuklar, panel_satis);
            }
        }
        public void ButonCiz(int sinir, List<string> koltuklar, Panel panel)
        {
            #region Butonlar
            Button[] btn = new Button[200];
            char[] dizi = { 'A', 'B', 'C', 'D', 'E' };
            if (sinir == 100)
            {
                int satir = sinir / 20;
                int sutun = sinir / 5;
                for (int y = 0; y < satir; y++)
                {
                    for (int x = 0; x < sutun; x++)
                    {
                        btn[x] = new Button();
                        btn[x].Text = dizi[y].ToString() + (x + 1).ToString();
                        if (koltuklar.Contains(btn[x].Text))
                        {
                            btn[x].BackColor = Color.Red;
                            btn[x].Enabled = false;
                        }
                        else
                            btn[x].BackColor = Color.Green;
                        btn[x].Size = new Size(35, 35);
                        btn[x].BackColor = Color.Green;
                        btn[x].ForeColor = Color.White;
                        btn[x].Location = new Point((x + 1) * 35, (y + 1) * 55);
                        btn[x].Click += new EventHandler(btn_Click);
                        panel.Controls.Add(btn[x]);

                    }
                }
            }
            else if (sinir == 110)
            {
                int satir = sinir / 22;
                int sutun = sinir / 5;

                for (int y = 0; y < satir; y++)
                {

                    for (int x = 0; x < sutun; x++)
                    {
                        btn[x] = new Button();
                        btn[x].Text = dizi[y].ToString() + (x + 1).ToString();
                        if (koltuklar.Contains(btn[x].Text))
                        {
                            btn[x].BackColor = Color.Red;
                            btn[x].Enabled = false;
                        }
                        else
                            btn[x].BackColor = Color.Green;
                        btn[x].Size = new Size(35, 35);
                        btn[x].BackColor = Color.Green;
                        btn[x].ForeColor = Color.White;
                        btn[x].Location = new Point((x) * 33, (y + 1) * 55);
                        btn[x].Click += new EventHandler(btn_Click);
                        panel.Controls.Add(btn[x]);

                    }
                }
            }
            else if (sinir == 70)
            {
                int satir = sinir / 14;
                int sutun = sinir / 5;
                for (int y = 0; y < satir; y++)
                {

                    for (int x = 0; x < sutun; x++)
                    {
                        btn[x] = new Button();
                        btn[x].Text = dizi[y].ToString() + (x + 1).ToString();
                        if (koltuklar.Contains(btn[x].Text))
                        {
                            btn[x].BackColor = Color.Red;
                            btn[x].Enabled = false;
                        }
                        else
                            btn[x].BackColor = Color.Green;
                        btn[x].Size = new Size(35, 35);
                        btn[x].BackColor = Color.Green;
                        btn[x].ForeColor = Color.White;
                        btn[x].Location = new Point((x + 1) * 50, (y + 1) * 55);
                        btn[x].Click += new EventHandler(btn_Click);
                        panel.Controls.Add(btn[x]);

                    }
                }
            }
            else if (sinir == 50)
            {
                int satir = sinir / 10;
                int sutun = sinir / 5;
                for (int y = 0; y < satir; y++)
                {

                    for (int x = 0; x < sutun; x++)
                    {
                        btn[x] = new Button();
                        btn[x].Text = dizi[y].ToString() + (x + 1).ToString();
                        if (koltuklar.Contains(btn[x].Text))
                        {
                            btn[x].BackColor = Color.Red;
                            btn[x].Enabled = false;
                        }
                        else
                            btn[x].BackColor = Color.Green;
                        btn[x].Size = new Size(35, 35);
                        btn[x].BackColor = Color.Green;
                        btn[x].ForeColor = Color.White;
                        btn[x].Location = new Point((x + 1) * 65, (y + 1) * 55);
                        btn[x].Click += new EventHandler(btn_Click);
                        panel.Controls.Add(btn[x]);
                    }
                }

            }
            else if (sinir == 30)
            {
                int satir = sinir / 6;
                int sutun = sinir / 5;
                for (int y = 0; y < satir; y++)
                {

                    for (int x = 0; x < sutun; x++)
                    {
                        btn[x] = new Button();
                        btn[x].Text = dizi[y].ToString() + (x + 1).ToString();
                        if (koltuklar.Contains(btn[x].Text))
                        {
                            btn[x].BackColor = Color.Red;
                            btn[x].Enabled = false;
                        }
                        else
                            btn[x].BackColor = Color.Green;
                        btn[x].Size = new Size(70, 35);
                        btn[x].ForeColor = Color.White;
                        btn[x].Location = new Point((x + 1) * 96, (y + 1) * 55);
                        btn[x].Click += new EventHandler(btn_Click);
                        panel.Controls.Add(btn[x]);
                    }
                }
            }
            #endregion Butonlar
        }

        private void button_kes_Click(object sender, EventArgs e)
        {
            int exeCuteInt = 0, salonFilmID = 0;
            string BiletYazilacakKoltuklar = "";
            try
            {
                adp.SelectCommand = kmt;
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select SalonFilmID from Seans where SalonID=@sid and Seans = @seans";
                kmt.Parameters.Clear();
                kmt.Parameters.AddWithValue("@sid", Convert.ToInt32(textBox_salonsatıs.Text));
                kmt.Parameters.AddWithValue("@seans", comboBox_seanssatis.Text);
                using (dr = kmt.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        salonFilmID = Convert.ToInt32(dr[0]);
                    }
                    dr.Close();
                }
                for (int i = 0; i < biletDiziGostergeci; i++)
                {
                    kmt.CommandText = "insert into Bilet (SalonFilmID,KoltukNo)values ('" + salonFilmID + "','" + biletDizisi[i] + "')";
                    exeCuteInt = kmt.ExecuteNonQuery();
                    BiletYazilacakKoltuklar += " " + biletDizisi[i];
                    koltuklar.Add(biletDizisi[i]);
                }
                bag.Close();
                if (exeCuteInt > 0)
                {
                    panel_satis.Controls.Clear();
                    ButonCiz(sinir, koltuklar, panel_satis);
                    MessageBox.Show("Film Adı : " + comboBox_filmsatis.Text + "\nSeans : " + comboBox_seanssatis.Text + "\nKoltuk No : " + BiletYazilacakKoltuklar + "\nToplam Fiyat : " + textBox_toplam.Text + " TL");
                    textBox_kisisayisisatis.Text = string.Empty;
                    toplamFiyat = 0;
                    textBox_toplam.Text = string.Empty;
                    textBox_su.Text = string.Empty;
                    textBox_misirorta.Text = string.Empty;
                    textBox_mesrubat.Text = string.Empty;
                    textBox_misirbüyük.Text = string.Empty;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
