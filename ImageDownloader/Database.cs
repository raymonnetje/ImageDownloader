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
    public class Database
    {
        Crypt crypt = new Crypt();

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
            cmd.CommandText = "insert into Query (queryString) values (@query)";
            cmd.Parameters.Add(new SQLiteParameter("@query", crypt.EncryptString(query)));
            int r = cmd.ExecuteNonQuery();
            
            Console.WriteLine("Query resultaat: " + r.ToString());
            long queryId = sqliteDbConnection.LastInsertRowId;

            foreach (Image image in images)
            {
                try
                {
                    cmd = sqliteDbConnection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Image (Title, Url, QueryId, Path) values (@imageTitle, @imageLink, @queryId, @path)";
                    cmd.Parameters.Add(new SQLiteParameter("@imageTitle", crypt.EncryptString(image.title)));
                    cmd.Parameters.Add(new SQLiteParameter("@imageLink", crypt.EncryptString(image.link)));
                    cmd.Parameters.Add(new SQLiteParameter("@queryId", queryId));
                    cmd.Parameters.Add(new SQLiteParameter("@path", image.path));
                    r = cmd.ExecuteNonQuery();
                }
                catch (Exception crap)
                {
                    Console.WriteLine(crap.ToString());
                }
            }

            sqliteDbConnection.Close();
        }

        public List<Query> loadQuerys()
        {
            List<Query> queryList = new List<Query>();
            sqliteDbConnection.Open();

            SQLiteCommand cmd = sqliteDbConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Query INNER JOIN Image ON Query.QueryId=Image.QueryId GROUP BY Query.QueryId";
            SQLiteDataReader reader = cmd.ExecuteReader();

            Query tempQuery;
            while(reader.Read())
            {
                tempQuery = new Query();
                tempQuery.queryId = (reader["queryId"].ToString());
                tempQuery.queryText = crypt.DecryptString(reader["queryString"].ToString());
                queryList.Add(tempQuery);
            }

            sqliteDbConnection.Close();

            return queryList;
        }

        public List<Image> loadQueryImages(Query query)
        {
            sqliteDbConnection.Open();

            List<Image> imageList = new List<Image>();

            SQLiteCommand cmd = sqliteDbConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Query INNER JOIN Image ON Query.QueryId=Image.QueryId WHERE Query.QueryId = @queryId";
            cmd.Parameters.Add(new SQLiteParameter("@queryId", query.queryId));

            SQLiteDataReader reader = cmd.ExecuteReader();

            Image tempImage;
            while (reader.Read())
            {
                tempImage = new Image();
                tempImage.link =    crypt.DecryptString(reader["Url"].ToString());
                tempImage.title =   crypt.DecryptString(reader["Title"].ToString());
                tempImage.path =    reader["Path"].ToString();
                imageList.Add(tempImage);
            }

            sqliteDbConnection.Close();

            return imageList;
        }

    }
}
