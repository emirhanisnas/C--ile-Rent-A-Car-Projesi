using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            try 
            {
                comboAraçlar.SelectedIndex = 0;

            }
            catch
            {
                ;
            }
        }

        private void YenileAraçlarLisetesi()
        {
            string cümle = "select * from araç";
            SQLiteDataAdapter adtr2 = new SQLiteDataAdapter();
            dataGridView1.DataSource = araçkiralama.listele(adtr2, cümle);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            SQLiteConnection baglan = new SQLiteConnection();
            baglan.ConnectionString = "Data Source=db/Araç_Kiralama.db";
            baglan.Open();
            string sql = "DELETE FROM araç WHERE Plaka=@plaka";
            SQLiteParameter komut = new SQLiteParameter("@plaka", Plakatxt.Text);
            SQLiteCommand cmd = new SQLiteCommand(sql , baglan);
            cmd.Parameters.Add(komut);
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            araçkiralama.ekle_sil_güncelle(cmd, sql);
            YenileAraçlarLisetesi();
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglan = new SQLiteConnection();
            baglan.ConnectionString = ("Data Source=db/Araç_Kiralama.db");
            baglan.Open();
            string cümle = "UPDATE araç set marka=@marka, seri=@seri,yıl=@yıl,renk=@renk,km=@km,yakıt=@yakıt,kiraücreti=@kiraücreti,resim=@resim where plaka=@plaka";
            
            SQLiteParameter komut1 = new SQLiteParameter("@plaka", Plakatxt.Text);
            SQLiteParameter komut2 = new SQLiteParameter("@marka", Markacombo.Text);
            SQLiteParameter komut3 = new SQLiteParameter("@seri", Sericombo.Text);
            SQLiteParameter komut4 = new SQLiteParameter("@yıl", Yıltxt.Text);
            SQLiteParameter komut5 = new SQLiteParameter("@renk", Renktxt.Text);
            SQLiteParameter komut6 = new SQLiteParameter("@km", Kmtxt.Text);
            SQLiteParameter komut7 = new SQLiteParameter("@yakıt", Yakıtcombo.Text);
            SQLiteParameter komut8 = new SQLiteParameter("@kiraücreti", Ücrettxt.Text);
            SQLiteParameter komut9 = new SQLiteParameter("@resim", pictureBox2.ImageLocation);
            SQLiteParameter komut10 = new SQLiteParameter("@durumu", "BOŞ");
            SQLiteCommand cmd = new SQLiteCommand(cümle, baglan);
            cmd.Parameters.Add(komut1);
            cmd.Parameters.Add(komut2);
            cmd.Parameters.Add(komut3);
            cmd.Parameters.Add(komut4);
            cmd.Parameters.Add(komut5);
            cmd.Parameters.Add(komut6);
            cmd.Parameters.Add(komut7);
            cmd.Parameters.Add(komut8);
            cmd.Parameters.Add(komut9);
            cmd.Parameters.Add(komut10);
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            araçkiralama.ekle_sil_güncelle(cmd,cümle );
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";

            YenileAraçlarLisetesi();
            baglan.Close();
            
          
        }

        private void comboAraçlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                if (comboAraçlar.SelectedIndex==0)
                {
                    YenileAraçlarLisetesi();
                }
                if (comboAraçlar.SelectedIndex == 1)
                {
                    string cümle = "select * from araç where durumu='BOŞ'";
                    SQLiteDataAdapter adtr2 = new SQLiteDataAdapter();
                    dataGridView1.DataSource = araçkiralama.listele(adtr2, cümle);
                }
                if (comboAraçlar.SelectedIndex == 2)
                {
                    string cümle = "select * from araç where durumu='DOLU'";
                    SQLiteDataAdapter adtr2 = new SQLiteDataAdapter();
                    dataGridView1.DataSource = araçkiralama.listele(adtr2, cümle);
                }
            }
            catch
            {
                ;
            }
        }

        private void Markacombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sericombo.Items.Clear();
                if (Markacombo.SelectedIndex == 0)
                {
                    Sericombo.Items.Add("Astra");
                    Sericombo.Items.Add("Vectra");
                    Sericombo.Items.Add("Corsa");
                }
                else if (Markacombo.SelectedIndex == 1)
                {
                    Sericombo.Items.Add("Megane");
                    Sericombo.Items.Add("Clio");

                }
                else if (Markacombo.SelectedIndex == 2)
                {
                    Sericombo.Items.Add("Linea");
                    Sericombo.Items.Add("Egea");

                }
                else if (Markacombo.SelectedIndex == 3)
                {
                    Sericombo.Items.Add("Fiesta");
                    Sericombo.Items.Add("Focus");
                }
            }
            catch
            {
                ;
            }
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Plakatxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Yıltxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void Kmtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void Ücrettxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Renktxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void Markacombo_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = true;
        }

        private void Sericombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Yakıtcombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboAraçlar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
