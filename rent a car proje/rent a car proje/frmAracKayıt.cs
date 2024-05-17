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
    public partial class frmAracKayıt : Form
    {
        Araç_Kiralama araçkiralama = new Araç_Kiralama();
        public frmAracKayıt()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglan = new SQLiteConnection();
            baglan.ConnectionString = ("Data Source=db\\Araç_Kiralama.db");
            baglan.Open();
            string cümle = "INSERT INTO araç(plaka, marka, seri,yıl,renk,km,yakıt,kiraücreti,resim,durumu) VALUES (@plaka, @marka,@seri,@yıl,@renk,@km,@yakıt,@kiraücreti,@resim,@durumu)";
            SQLiteCommand cmd = new SQLiteCommand(cümle, baglan);
            /*SQLiteParameter komut = new SQLiteParameter("@plaka", Plakatxt.Text);
            SQLiteParameter komut1 = new SQLiteParameter("@marka", Markacombo.Text);
            SQLiteParameter komut2 = new SQLiteParameter("@seri", Sericombo.Text);
            SQLiteParameter komut3 = new SQLiteParameter("@yıl", Yıltxt.Text);
            SQLiteParameter komut4 = new SQLiteParameter("@renk", Renktxt.Text);
            SQLiteParameter komut5 = new SQLiteParameter("@km", Kmtxt.Text);
            SQLiteParameter komut6 = new SQLiteParameter("@yakıt", Yakıtcombo.Text);
            SQLiteParameter komut7 = new SQLiteParameter("@kiraücreti", Ücrettxt.Text);
            SQLiteParameter komut8 = new SQLiteParameter("@resim", pictureBox1.ImageLocation);
           // SQLiteParameter komut9 = new SQLiteParameter("@tarih", DataTime.Now.ToString);
            SQLiteParameter komut10 = new SQLiteParameter("@durumu", "BOŞ");
            SQLiteCommand cmd = new SQLiteCommand(cümle, baglan);
            cmd.Parameters.Add(komut);
            cmd.Parameters.Add(komut1);
            cmd.Parameters.Add(komut2);
            cmd.Parameters.Add(komut3);
            cmd.Parameters.Add(komut4);
            cmd.Parameters.Add(komut6);
            cmd.Parameters.Add(komut7);
            cmd.Parameters.Add(komut8);
           // cmd.Parameters.Add(komut9);
            cmd.Parameters.Add(komut10);*/
            cmd.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            cmd.Parameters.AddWithValue("@marka", Markacombo.Text);
            cmd.Parameters.AddWithValue("@seri", Sericombo.Text);
            cmd.Parameters.AddWithValue("@yıl", Yıltxt.Text);
            cmd.Parameters.AddWithValue("@renk", Renktxt.Text);
            cmd.Parameters.AddWithValue("@km", Kmtxt.Text);
            cmd.Parameters.AddWithValue("@yakıt", Yakıtcombo.Text);
            cmd.Parameters.AddWithValue("@kiraücreti", Ücrettxt.Text);
            cmd.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            //cmd.Parameters.AddWithValue("@tarih", DataTime.Now.ToString);
            cmd.Parameters.AddWithValue("@durumu", "BOŞ");
            cmd.ExecuteNonQuery();
        
           //araçkiralama.ekle_sil_güncelle(cmd, cümle);
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            
            
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                throw;
            }
        }
    }
}
