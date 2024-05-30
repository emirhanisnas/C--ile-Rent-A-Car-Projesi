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
    public partial class frmMüsşteriEkle : Form
    {
        
        Araç_Kiralama araç_kiralama = new Araç_Kiralama();
        public frmMüsşteriEkle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtTC.Text) ||
            string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
            string.IsNullOrWhiteSpace(txtTelefon.Text) ||
            string.IsNullOrWhiteSpace(txtAdres.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Lütfen tüm bilgileri doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source=.\\db\\Araç_Kiralama.db");
                baglan.Open();
                    
                string sql = "INSERT INTO Müşteri(TC, AdSoyad, Telefon, Adres, Email) VALUES (@TC, @AdSoyad, @Telefon, @Adres, @Email)";
                SQLiteCommand cmd = new SQLiteCommand(sql, baglan);
                /*cmd.Parameters.AddWithValue("@TC", txtTC.Text);
                cmd.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
                cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                cmd.Parameters.AddWithValue("@Adres", txtAdres.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                */
                cmd.Parameters.AddWithValue("@TC", txtTC.Text);
                cmd.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
                cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                cmd.Parameters.AddWithValue("@Adres", txtAdres.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    txtTC.Text = "";
                    txtAdSoyad.Text = "";
                    txtTelefon.Text = "";
                    txtAdres.Text = "";
                    txtEmail.Text = "";
                    MessageBox.Show("Müşteri başarıyla eklendi.");

                }
                else
                {
                    MessageBox.Show("Müşteri eklenirken bir hata oluştu veya etkilenen satır yok.");
                }

                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }

        }
        // SQLiteCommand komut = new SQLiteCommand("insert into TABLENAME(kolon1,kolon2) values (@veri1,@veri2)", baglanti);
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            if (txtTC.Text.Length > 11)
            {
                MessageBox.Show("En fazla 11 karakter girebilirsiniz.");
                txtTC.Text = txtTC.Text.Substring(0, 11);
                txtTC.SelectionStart = txtTC.Text.Length; // İmleci sona getir
            }
        }

        private void txtTC_CausesValidationChanged(object sender, EventArgs e)
        {

        }

        private void txtTC_Validating(object sender, CancelEventArgs e)
        {
            if (txtTC.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli olmalıdır.", "Geçersiz TC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTC.Focus(); // Kullanıcıyı hatalı alana odakla
                e.Cancel = true; // Odak kaybını iptal et
            }
        }

        private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
