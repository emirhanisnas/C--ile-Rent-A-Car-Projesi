using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rent_a_car_proje
{
    internal class Araç_Kiralama
    {

        //SQLiteConnection connection = new SQLiteConnection("Data Source=db/Araç_Kiralama.db");
       
        SQLiteConnection baglan = new SQLiteConnection("Data Source=db/Araç_Kiralama.db");
        DataTable tablo;
        //baglan.ConnectionString = ("Data Source=db/Araç_Kiralama.db");
        public void ekle_sil_güncelle(SqLiteCommand komut, string sorgu)
        {
           //burdakini aşağıdakine aktarman gerek referanslar orada end değil norlam execute olacak!!! hocaya sor
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = sorgu;
            komut.EndExecuteNonQuery();
            baglan.Close();
            


        }
        public DataTable listele(SQLiteDataAdapter adtr, string sorgu)
        {
            baglan.Open();
            tablo = new DataTable();
            adtr = new SQLiteDataAdapter(sorgu, baglan);
            adtr.Fill(tablo);
            baglan.Close();
            return tablo;

        }

        internal void ekle_sil_güncelle(SQLiteCommand komut2, string cümle)
        {
           
        }

        internal void ekle_sil_güncelle(SqlCommand komut2, string cümle)
        {
            //throw new NotImplementedException();
        }
        public void Boş_Araclar(ComboBox combo,string sorgu)
        {   
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand(sorgu, baglan);
            SQLiteDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read["plaka"].ToString());
            }
            baglan.Close();
        }
        public void TC_Ara(TextBox tcara ,TextBox tc, TextBox adsoyad, TextBox telefon, string sorgu)
        {
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand(sorgu, baglan);
            SQLiteDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                tc.Text = read["tc"].ToString();
                adsoyad.Text = read["adsoyad"].ToString();
                telefon.Text = read["telefon"].ToString(); 
            }
            baglan.Close();
        }
        public void Hesapla(ComboBox combokiraşekl,TextBox ücret,  string sorgu)
        {
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand(sorgu, baglan);
            SQLiteDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
               
                if (combokiraşekl.SelectedIndex == 0)
                {
                    // read["kiraücreti"] değerini string'den integer'a çevirme ve sonra tekrar string'e çevirme
                    int kiraUcreti = int.Parse(read["kiraücreti"].ToString());

                    // Değeri tekrar string'e çevirip, gerekli yere atama
                    ücret.Text = (kiraUcreti * 1).ToString(); // Aslında *1 gereksiz ama örneğinizi baz alarak koydum
                }

                if (combokiraşekl.SelectedIndex == 1)
                {
                    // read["kiraücreti"] değerini string'den integer'a çevirme
                    int kiraUcreti = int.Parse(read["kiraücreti"].ToString());

                    // Kira ücretinin %80'ini hesaplama
                    double sonuc = kiraUcreti * 0.90;

                    // Hesaplanan sonucu string'e çevirip ücret.Text'e atama
                    ücret.Text = sonuc.ToString();
                }
                if (combokiraşekl.SelectedIndex == 2)
                {
                    // read["kiraücreti"] değerini string'den integer'a çevirme
                    int kiraUcreti = int.Parse(read["kiraücreti"].ToString());

                    // Kira ücretinin %80'ini hesaplama
                    double sonuc = kiraUcreti * 0.80;

                    // Hesaplanan sonucu string'e çevirip ücret.Text'e atama
                    ücret.Text = sonuc.ToString();
                }
                if (combokiraşekl.SelectedIndex == 3)
                {
                    // read["kiraücreti"] değerini string'den integer'a çevirme
                    int kiraUcreti = int.Parse(read["kiraücreti"].ToString());

                    // Kira ücretinin %80'ini hesaplama
                    double sonuc = kiraUcreti * 0.70;

                    // Hesaplanan sonucu string'e çevirip ücret.Text'e atama
                    ücret.Text = sonuc.ToString();
                }

            }
            baglan.Close();
        }
        public void CombodanGetir(ComboBox araclar,TextBox marka, TextBox seri, TextBox yıl,TextBox renk, string sorgu)
        {
            baglan.Open();
            SQLiteCommand komut = new SQLiteCommand(sorgu, baglan);
            SQLiteDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                marka.Text = read["marka"].ToString();
                seri.Text = read["seri"].ToString();
                yıl.Text = read["yıl"].ToString();
                renk.Text = read["renk"].ToString();
            }
            baglan.Close();
        }
        public void satışhesapla(Label label1)
        {
            baglan.Open();
            SQLiteCommand komut =new SQLiteCommand("select sum(tutar) from satış",baglan);
            label1.Text = "Toplam Tutar = " + komut.ExecuteScalar() + "TL";
            baglan.Close();
        }
    }
}
