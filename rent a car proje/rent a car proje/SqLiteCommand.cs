using System;
using System.Data.SQLite;

namespace rent_a_car_proje
{
    public class SqLiteCommand
    {
        public SQLiteConnection Connection { get; internal set; }
        public string CommandText { get; internal set; }
        public object Parameters { get; internal set; }

        internal void EndExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }
    }
}