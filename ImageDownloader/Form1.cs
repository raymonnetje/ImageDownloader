using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ImageDownloader
{
    
   
    public partial class Form1 : Form
    {

        Grabber grabber;
        Downloader downloader;
        Database db;
        Crypt aes;
        Key sleutels;

        public Form1()
        {
            InitializeComponent();

            const string apiKey = "AIzaSyC3u5jYwwZVqSq-JQge2gYHqDKErrCo1Sc";
            const string searchEngineId = "002939223692517534743:_6gyhcdvzrg";
            
            grabber = new Grabber(apiKey, searchEngineId);
            aes = new Crypt();


            imageTable.AllowUserToAddRows = false;

            db = new Database();

           fillComboBox(db.loadQuerys());
        }

        private void query()
        {
            downloader = new Downloader();
            ArrayList temp = grabber.search(searchBox.Text.ToString());
            Console.WriteLine(temp.Count);
            try
            {
                
                downloader.download(temp, searchBox.Text);
                db.storeQuery(searchBox.Text, temp);
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception);
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            query();
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                query();
                e.Handled = true;
            }
        }
        
        public void fillComboBox(List<Query> queryList)
        {
            foreach(Query tempQuery in queryList)
            {
                queryComboBox.Items.Add(tempQuery);
            }
        }

        private void queryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            imageTable.Rows.Clear();
            imageTable.Refresh();
            List<Image> imageList = db.loadQueryImages(queryComboBox.SelectedItem as Query);
            foreach(Image tempImage in imageList)
            {
                imageTable.Rows.Add(tempImage.title, tempImage.link, tempImage.path);
            }
        }

        private void queryComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            queryComboBox.DroppedDown = true;
        }
    }
}
