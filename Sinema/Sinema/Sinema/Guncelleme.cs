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
    public partial class Guncelleme : Form
    {
        public Guncelleme()
        {
            InitializeComponent();
        }

        SqlConnection bag = new SqlConnection("server=DESKTOP-NP65TK1; uid=sa;password=!Q'W3e4r;database=Sinema");
        SqlCommand kmt = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlDataReader dr;

        private void button_geri_Click(object sender, EventArgs e)
        {
            AnaMenu menu = new AnaMenu();
            this.Hide();
            menu.Show();
        }

        private void Guncelleme_Load(object sender, EventArgs e)
        {
            CancelButton = button_geri;
        }
    }
}
