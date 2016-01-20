using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;
using System.Data;

namespace ImageDownloader
{
    class Database
    {
        SQLiteConnection sqliteDbConnection; 

        public Database()
        {
            sqliteDbConnection = new SQLiteConnection("Data Source=ImageDownloader.s3db; FailIfMissing=True;");            
        }

        public void storeQuery(String query, ArrayList images)
        {
            sqliteDbConnection.Open();

            SQLiteCommand cmd = sqliteDbConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Query (queryString) values ('" + query + "')";
            cmd.Parameters.Add(new SQLiteParameter("@parameter", query));
            int r = cmd.ExecuteNonQuery();
            
            Console.WriteLine("Query resultaat: " + r.ToString());
            long queryId = sqliteDbConnection.LastInsertRowId;

            foreach (Image image in images)
            {
                try
                {
                    cmd = sqliteDbConnection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Image (Title, Url, QueryId) values (@imageTitle, @imageLink, @queryId)";
                    cmd.Parameters.Add(new SQLiteParameter("@imageTitle", image.title));
                    cmd.Parameters.Add(new SQLiteParameter("@imageLink", image.link));
                    cmd.Parameters.Add(new SQLiteParameter("@queryId", queryId));
                    r = cmd.ExecuteNonQuery();
                }
                catch (Exception crap)
                {
                    Console.WriteLine(crap.ToString());
                }
            }

            sqliteDbConnection.Close();
        }
    }
}
