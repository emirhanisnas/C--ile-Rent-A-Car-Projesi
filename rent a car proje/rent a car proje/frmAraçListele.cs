using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rent_a_car_proje
{
    public partial class frmAraçListele : Form
    {
        Araç_Kiralama araçkiralama = new Araç_Kiralama();
        public frmAraçListele()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            Plakatxt.Text = satır.Cells["plaka"].Value.ToString();
            Markacombo.Text = satır.Cells["marka"].Value.ToString();
            Sericombo.Text = satır.Cells["seri"].Value.ToString();
            Yıltxt.Text = satır.Cells["yıl"].Value.ToString();
            Renktxt.Text = satır.Cells["renk"].Value.ToString();
            Kmtxt.Text = satır.Cells["km"].Value.ToString();
            Yakıtcombo.Text = satır.Cells["yakıt"].Value.ToString();
            Ücrettxt.Text = satır.Cells["kiraücreti"].Value.ToString();
            pictureBox2.ImageLocation = satır.Cells["resim"].Value.ToString();
          

        }

        private void frmAraçListele_Load(object sender, EventArgs e)
        {
            YenileAraçlarLisetesi();
        }

        private void YenileAraçlarLisetesi()
        {
            string cümle = "select * from araç";
            SQLiteDataAdapter adtr2 = new SQLiteDataAdapter();
            dataGridView1.DataSource= araçkiralama.listele(adtr2, cümle);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}
