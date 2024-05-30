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
    public partial class frmSatış : Form
    {
        public frmSatış()
        {
            InitializeComponent();
        }
        Araç_Kiralama araç = new Araç_Kiralama();
        private void frmSatış_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from satış";
            SQLiteDataAdapter adtr2 =new SQLiteDataAdapter();
            dataGridView1.DataSource = araç.listele(adtr2,sorgu); 
            araç.satışhesapla(label1);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
