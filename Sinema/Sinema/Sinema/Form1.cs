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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string kullanici;

        SqlConnection bag = new SqlConnection("server=202-09; uid=sa;password=1234;database=Sinema");
        SqlCommand kmt = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();

        private void button_giris_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                //MessageBox.Show("Connection Succesful");                
                if (bag != null && bag.State == ConnectionState.Closed) ;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanici WHERE KullaniciAdi='" + textBox_kullaniciadi.Text + "' and Sifre='" + textBox_sifre.Text + "'", bag);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    kullanici = textBox_kullaniciadi.Text;
                    MessageBox.Show("Giriş Başarılı.");
                    AnaMenu anamenu = new AnaMenu();
                    this.Hide();
                    anamenu.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı.");
                    
                }
                bag.Close();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantı Başarısız.");                
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            AcceptButton = button_giris;
            this.ActiveControl = textBox_kullaniciadi;
        }
    }
}
