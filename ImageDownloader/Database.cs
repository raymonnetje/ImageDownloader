using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ImageDownloader
{
    class Database
    {
        SQLiteConnection sqliteDbConnection; 

        public Database()
        {
            sqliteDbConnection = new SQLiteConnection("Data Source=ImageDownloader.s3db; FailIfMissing=True;");

            
        }

        public Boolean storeQuery(String query, ArrayList<Image> images)
        {
            try
            {
                string sql = "insert into Queryawsdf (queryString) values ('" + query + "')";

                sqliteDbConnection.Open();
                
                SQLiteCommand command = new SQLiteCommand(sql, sqliteDbConnection);
                int r = command.ExecuteNonQuery();
                Console.WriteLine("Query resultaat: " + r.ToString());
                long queryId = sqliteDbConnection.LastInsertRowId;
                sqliteDbConnection.Close();
                return true;
            }
            catch (Exception crap)
            {
                Console.WriteLine(crap.ToString());
                return false;

            }
        }
    }
}
