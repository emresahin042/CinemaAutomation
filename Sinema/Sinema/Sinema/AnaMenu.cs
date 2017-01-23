using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void button_satis_Click(object sender, EventArgs e)
        {
            Satıs bsat = new Satıs();
            this.Hide();
            bsat.Show();
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            Guncelleme bgun = new Guncelleme();
            this.Hide();
            bgun.Show();
        }

        private void button_iptal_Click(object sender, EventArgs e)
        {
            Guncelleme bipt = new Guncelleme();
            this.Hide();
            bipt.Show();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            label2.Text = Login.kullanici;
        }
    }
}
