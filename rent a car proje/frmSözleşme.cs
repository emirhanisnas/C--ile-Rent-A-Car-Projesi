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
    public partial class frmSözleşme : Form
    {
        public frmSözleşme()
        {
            InitializeComponent();
        }
        Araç_Kiralama arac = new Araç_Kiralama();
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmSözleşme_Load(object sender, EventArgs e)
        {
           

            Boş_Araçlar();
            Yenile();
        }

        private void Boş_Araçlar()
        {
            string sorgu2 = "select * from araç where durumu='BOŞ'";

            arac.Boş_Araclar(comboAraçlar, sorgu2);
        }

        private void Yenile()
        {
            string sorgu3 = "select * from sözleşme";
            SQLiteDataAdapter adtr2 = new SQLiteDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr2, sorgu3);
        }

        private void comboAraçlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select * from araç where plaka like '" + comboAraçlar.SelectedItem + "'";
            arac.CombodanGetir(comboAraçlar, txtMarka, txtSeri, txtYıl, txtRenk, sorgu2);
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboKiraŞekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select * from araç where plaka like '" + comboAraçlar.SelectedItem + "'";
            arac.Hesapla(comboKiraŞekli, txtKiraÜcreti, sorgu2);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            TimeSpan gunfarkı = DateTime.Parse(dateDönüş.Text) - DateTime.Parse(dateÇıkış.Text);
            int gunfarkı2 = gunfarkı.Days;
            txtGün.Text = gunfarkı2.ToString();
            txtTutar.Text = (gunfarkı2 * int.Parse(txtKiraÜcreti.Text)).ToString();


        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            dateÇıkış.Text = DateTime.Now.ToShortDateString();
            dateDönüş.Text = DateTime.Now.ToShortDateString();
            comboKiraŞekli.Text = "";
            txtKiraÜcreti.Text = "";
            txtGün.Text = "";
            txtTutar.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTc.Text) ||
            string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
            string.IsNullOrWhiteSpace(txtTelefon.Text) ||
            string.IsNullOrWhiteSpace(txtE_No.Text) ||
            string.IsNullOrWhiteSpace(txtE_Tarih.Text) ||
            string.IsNullOrWhiteSpace(txtE_Yer.Text) ||
            string.IsNullOrWhiteSpace(comboAraçlar.Text) ||
            string.IsNullOrWhiteSpace(txtMarka.Text) ||
            string.IsNullOrWhiteSpace(txtSeri.Text) ||
            string.IsNullOrWhiteSpace(txtYıl.Text) ||
            string.IsNullOrWhiteSpace(txtRenk.Text) ||
            string.IsNullOrWhiteSpace(comboKiraŞekli.Text) ||
            string.IsNullOrWhiteSpace(txtKiraÜcreti.Text) ||
            string.IsNullOrWhiteSpace(txtGün.Text) ||
            string.IsNullOrWhiteSpace(txtTutar.Text) ||
            string.IsNullOrWhiteSpace(dateÇıkış.Text) ||
            string.IsNullOrWhiteSpace(dateDönüş.Text))
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                SQLiteConnection baglan = new SQLiteConnection();
            baglan.ConnectionString = ("Data Source=.\\db\\Araç_Kiralama.db");
            baglan.Open();

            string sorgu2 = "insert into sözleşme(tc, adsoyad, telefon, ehliyetno,e_tarih,e_yer ,plaka,marka,seri,yil,renk,kiraşekli,kiraucreti,gun,tutar,ctarih,dtarih) " +
                             "values(@tc, @adsoyad, @telefon, @ehliyetno,@e_tarih,@e_yer ,@plaka,@marka,@seri,@yil,@renk,@kiraşekli,@kiraucreti,@gun,@tutar,@ctarih,@dtarih)";
            SQLiteCommand komut2 = new SQLiteCommand(sorgu2, baglan);
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_tarih", txtE_Tarih.Text);
            komut2.Parameters.AddWithValue("@e_yer", txtE_Yer.Text);
            komut2.Parameters.AddWithValue("@plaka", comboAraçlar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtYıl.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kiraşekli", comboKiraŞekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiraÜcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGün.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@ctarih", dateÇıkış.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateDönüş.Text);
            komut2.ExecuteNonQuery();
            arac.ekle_sil_güncelle(komut2, sorgu2);

            string sorgu3 = "update araç set durumu ='DOLU' where plaka='" + comboAraçlar.Text + "'";

            SQLiteCommand komut3 = new SQLiteCommand(sorgu3, baglan);
            komut3.ExecuteNonQuery();

            arac.ekle_sil_güncelle(komut3, sorgu3);

            comboAraçlar.Items.Clear();
            Boş_Araçlar();
            
            Yenile();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            baglan.Close();
            comboAraçlar.Text = "";
            Temizle();

          
            MessageBox.Show("Sözleşme Eklendi.");

        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            if (txtTcAra.Text == "") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            string sorgu2 = "select * from müşteri where tc like '" + txtTcAra.Text + "'";
            arac.TC_Ara(txtTcAra, txtTc, txtAdSoyad, txtTelefon, sorgu2);
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglan = new SQLiteConnection();
            baglan.ConnectionString = ("Data Source=.\\db\\Araç_Kiralama.db");
            baglan.Open();

            string sorgu2 = "update sözleşme set tc=@tc,adsoyad=@adsoyad,telefon=@telefon,ehliyetno=@ehliyetno,e_tarih=@e_tarih,e_yer=@e_yer,marka=@marka,seri=@seri,yil=@yil ,renk=@renk,kiraşekli=@kiraşekli,kiraucreti=@kiraucreti,gun=@gun, tutar=@tutar,ctarih=@ctarih,dtarih=@dtarih where plaka=@plaka";
            SQLiteCommand komut2 = new SQLiteCommand(sorgu2, baglan);
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_tarih", txtE_Tarih.Text);
            komut2.Parameters.AddWithValue("@e_yer", txtE_Yer.Text);
            komut2.Parameters.AddWithValue("@plaka",comboAraçlar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtYıl.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kiraşekli", comboKiraŞekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiraÜcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGün.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@ctarih", dateÇıkış.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateDönüş.Text);
            komut2.ExecuteNonQuery();
            arac.ekle_sil_güncelle(komut2, sorgu2);
            comboAraçlar.Items.Clear();
            Boş_Araçlar();
            Yenile();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            baglan.Close();
            Temizle();
            comboAraçlar.Text = "";
            MessageBox.Show("Sözleşme Güncellendi.");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır =dataGridView1.CurrentRow;
            txtTc.Text = satır.Cells[0].Value.ToString();
            txtAdSoyad.Text = satır.Cells[1].Value.ToString();
            txtTelefon.Text = satır.Cells[2].Value.ToString();
            txtE_No.Text = satır.Cells[3].Value.ToString();
            txtE_Tarih.Text = satır.Cells[4].Value.ToString();
            txtE_Yer.Text = satır.Cells[5].Value.ToString();
            comboAraçlar.Text = satır.Cells[6].Value.ToString();
            txtMarka.Text = satır.Cells[7].Value.ToString();
            txtSeri.Text = satır.Cells[8].Value.ToString();
            txtYıl.Text = satır.Cells[9].Value.ToString();
            txtRenk.Text = satır.Cells[10].Value.ToString();
            comboKiraŞekli.Text = satır.Cells[11].Value.ToString();
            txtKiraÜcreti.Text = satır.Cells[12].Value.ToString();
            txtGün.Text = satır.Cells[13].Value.ToString();
            txtTutar.Text = satır.Cells[14].Value.ToString();
            dateÇıkış.Text = satır.Cells[15].Value.ToString();
            dateDönüş.Text = satır.Cells[16].Value.ToString();


        }

        private void txtSeri_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGün_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime dönüş = DateTime.Parse(satır.Cells["dtarih"].Value.ToString());
            int ücret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
            TimeSpan gunfarkı = bugün - dönüş;
            int _günfarkı = gunfarkı.Days;
            int ücretfarkı;
            //ücret farkı hesap
            ücretfarkı = _günfarkı * ücret;
            txtEkstra.Text=ücretfarkı.ToString();
            //toplam hesap tutar

        }

        private void btnAraçTeslim_Click(object sender, EventArgs e)
        {
         
            if (int.Parse(txtEkstra.Text)>0 || int.Parse(txtEkstra.Text)<0)
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = "Data Source=db/Araç_Kiralama.db";
                baglan.Open();

                DataGridViewRow satır =dataGridView1.CurrentRow;
                DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
                int ücret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
                int tutar = int.Parse(satır.Cells["tutar"].Value.ToString());
                DateTime çıkış = DateTime.Parse(satır.Cells["ctarih"].Value.ToString());
                TimeSpan gun = bugün - çıkış;
                int _gun = gun.Days;
                int toplamtutar = _gun * ücret;
                //Toplamtutar ,_gun ve ücret satıs  tablosuna aktarılacak
                string sorgu1 = "delete from sözleşme where plaka='" + satır.Cells["plaka"].Value.ToString() +"'";
                txtEkstra.Text = "";
                SQLiteCommand komut = new SQLiteCommand(sorgu1, baglan);
                komut.ExecuteNonQuery();
                arac.ekle_sil_güncelle(komut, sorgu1);
                string sorgu2 = "update araç set durumu= 'BOŞ' where plaka='" + satır.Cells["plaka"].Value.ToString() +"'";

                SQLiteCommand komut2 = new SQLiteCommand(sorgu2, baglan);
                komut2.ExecuteNonQuery();
                arac.ekle_sil_güncelle(komut2, sorgu2);

                string sorgu3 = "insert into satış(tc, adsoyad,plaka,marka,seri,yil,renk,gun,fiyat,tutar,tarih1,tarih2) " +
                            "values(@tc, @adsoyad,@plaka,@marka,@seri,@yil,@renk,@gun,@fiyat,@tutar,@tarih1,@tarih2)";
                SQLiteCommand komut3 = new SQLiteCommand(sorgu3, baglan);
                komut3.Parameters.AddWithValue("@tc", satır.Cells["tc"].Value.ToString());
                komut3.Parameters.AddWithValue("@adsoyad", satır.Cells["adsoyad"].Value.ToString());
                komut3.Parameters.AddWithValue("@plaka", satır.Cells["plaka"].Value.ToString());
                komut3.Parameters.AddWithValue("@marka", satır.Cells["marka"].Value.ToString());
                komut3.Parameters.AddWithValue("@seri", satır.Cells["seri"].Value.ToString());
                komut3.Parameters.AddWithValue("@yil", satır.Cells["yil"].Value.ToString());
                komut3.Parameters.AddWithValue("@renk", satır.Cells["renk"].Value.ToString());
                komut3.Parameters.AddWithValue("@gun", _gun);
                komut3.Parameters.AddWithValue("@fiyat", ücret);
                komut3.Parameters.AddWithValue("@tutar", toplamtutar);
                komut3.Parameters.AddWithValue("@tarih1", satır.Cells["ctarih"].Value.ToString());
                komut3.Parameters.AddWithValue("@tarih2", DateTime.Now.ToShortDateString());
                
                komut3.ExecuteNonQuery();
                arac.ekle_sil_güncelle(komut3, sorgu3);
                comboAraçlar.Text = "";
                comboAraçlar.Items.Clear();
                Boş_Araçlar();
                Yenile();
                foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
                baglan.Close();
                comboAraçlar.Text = "";
                Temizle();
                MessageBox.Show("Araç Teslim Edildi.");
                

            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız.","Uyarı");
            }
        }

        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtE_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txtE_Tarih_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }

            
        }

        private void txtE_Yer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void comboAraçlar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtMarka_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtSeri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtYıl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtRenk_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboKiraŞekli_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void txtKiraÜcreti_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtEkstra_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
