using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
            //throw new NotImplementedException();
        }
    }
}
