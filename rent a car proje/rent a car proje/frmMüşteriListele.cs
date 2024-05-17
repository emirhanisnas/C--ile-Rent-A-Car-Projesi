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
    public partial class frmMüşteriListele : Form
    {
        
        Araç_Kiralama araçkiralama = new Araç_Kiralama();
        public frmMüşteriListele()
        {
            InitializeComponent();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {

            SQLiteConnection baglan = new SQLiteConnection();
            baglan.ConnectionString = ("Data Source=db/Araç_Kiralama.db");
            baglan.Open();
            string sql = "UPDATE  Müşteri SET AdSoyad=@AdSoyad,Telefon=@Telefon,Adres=@Adres,Email=@Email where TC=@TC";

            SQLiteParameter komut = new SQLiteParameter("@TC", txtTC.Text);
            SQLiteParameter komut1 = new SQLiteParameter("@AdSoyad", txtAdSoyad.Text);
            SQLiteParameter komut2 = new SQLiteParameter("@Telefon", txtTelefon.Text);
            SQLiteParameter komut3 = new SQLiteParameter("@Adres", txtAdres.Text);
            SQLiteParameter komut4 = new SQLiteParameter("@Email", txtEmail.Text);
            SQLiteCommand cmd = new SQLiteCommand(sql, baglan);
            cmd.Parameters.Add(komut);
            cmd.Parameters.Add(komut1);
            cmd.Parameters.Add(komut2);
            cmd.Parameters.Add(komut3);
            cmd.Parameters.Add(komut4);
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            araçkiralama.ekle_sil_güncelle(cmd, sql);

            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            YenileListele();

        }

        private void frmMüşteriListele_Load(object sender, EventArgs e)
        {
            YenileListele();
        }
        private void YenileListele()
        {
            string sql = "Select *from Müşteri";
            SQLiteDataAdapter adtr2 = new SQLiteDataAdapter();
            dataGridView1.DataSource = araçkiralama.listele(adtr2, sql);
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cümle = "Select *from Müşteri where TC like '%" + textBox1.Text + "%'";
            SQLiteDataAdapter adtr2 = new SQLiteDataAdapter();
            dataGridView1.DataSource = araçkiralama.listele(adtr2, cümle);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtTC.Text = satır.Cells[0].Value.ToString();
            txtAdSoyad.Text = satır.Cells[1].Value.ToString();
            txtTelefon.Text = satır.Cells[2].Value.ToString();
            txtAdres.Text = satır.Cells[3].Value.ToString();
            txtEmail.Text = satır.Cells[4].Value.ToString();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglan = new SQLiteConnection();
            baglan.ConnectionString = "Data Source=db/Araç_Kiralama.db";
            baglan.Open();
            string sql = "DELETE FROM Müşteri WHERE TC=@TC";

            SQLiteParameter komut = new SQLiteParameter("@TC", txtTC.Text);
            SQLiteCommand cmd = new SQLiteCommand(sql, baglan);
            cmd.Parameters.Add(komut);
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            araçkiralama.ekle_sil_güncelle(cmd, sql);

            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            YenileListele();


            /* SQLiteConnection baglan = new SQLiteConnection();
             baglan.ConnectionString = ("Data Source=db/Araç_Kiralama.db");
             baglan.Open();
             DataGridViewRow satır = dataGridView1.CurrentRow;
             string sql = "delete from Müşteri where TC='" + satır.Cells["TC"].Value.ToString() + "'";

             SQLiteCommand cmd = new SQLiteCommand();

             araçkiralama.ekle_sil_güncelle(cmd, sql);
             YenileListele(); */



            /*DataGridViewRow satır = dataGridView1.CurrentRow;
            string sql = "delete from Müşteri where TC='" + satır.Cells["TC"].Value.ToString() + "'";
            SQLiteCommand cmd = new SQLiteCommand();
           
            
            araçkiralama.ekle_sil_güncelle(cmd, sql);
            YenileListele();*/
        }
    }
}
