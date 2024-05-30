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
            if (string.IsNullOrWhiteSpace(Plakatxt.Text) ||
       string.IsNullOrWhiteSpace(Markacombo.Text) ||
       string.IsNullOrWhiteSpace(Sericombo.Text) ||
       string.IsNullOrWhiteSpace(Yıltxt.Text) ||
       string.IsNullOrWhiteSpace(Renktxt.Text) ||
       string.IsNullOrWhiteSpace(Kmtxt.Text) ||
       string.IsNullOrWhiteSpace(Yakıtcombo.Text) ||
       string.IsNullOrWhiteSpace(Ücrettxt.Text) ||
       string.IsNullOrWhiteSpace(pictureBox1.ImageLocation))
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SQLiteConnection baglan = new SQLiteConnection();
            baglan.ConnectionString = ("Data Source=db\\Araç_Kiralama.db");
            baglan.Open();
            string cumle = @"INSERT INTO araç(plaka, marka, seri,yıl,renk,km,yakıt,kiraücreti,resim,durumu) 
                                VALUES (@plaka, @marka,@seri,@yıl,@renk,@km,@yakıt,@kiraücreti,@resim,@durumu)";
            SQLiteCommand komut2 = new SQLiteCommand(cumle, baglan);

            komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@yıl", Yıltxt.Text);
            komut2.Parameters.AddWithValue("@renk", Renktxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakıt", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@kiraücreti", Ücrettxt.Text);
            komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            //komut2.Parameters.AddWithValue("@tarih", DataTime.Now.ToString);
            komut2.Parameters.AddWithValue("@durumu", "BOŞ");
            komut2.ExecuteNonQuery();
        
           araçkiralama.ekle_sil_güncelle(komut2, cumle);
            MessageBox.Show("Araç Kaydedildi.");
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox1.ImageLocation = "";
            
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
                ;
            }
        }

        private void frmAracKayıt_Load(object sender, EventArgs e)
        {

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

        private void Renktxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
    }
}
