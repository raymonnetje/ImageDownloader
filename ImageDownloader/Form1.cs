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

namespace ImageDownloader
{
    
   
    public partial class Form1 : Form
    {

        Grabber grabber;
        Downloader downloader;

        public Form1()
        {
             const string apiKey = "AIzaSyC3u5jYwwZVqSq-JQge2gYHqDKErrCo1Sc";
             const string searchEngineId = "002939223692517534743:_6gyhcdvzrg";

             InitializeComponent();

             grabber = new Grabber(apiKey, searchEngineId);
        }

        private void search_Click(object sender, EventArgs e)
        {
            downloader = new Downloader();
            ArrayList temp = grabber.search(searchBox.Text.ToString());
            Console.WriteLine(temp.Count);
            try
            {
                Database db = new Database();
                downloader.download(temp, searchBox.Text);
                db.storeQuery(searchBox.Text, temp);
            }
            catch (Exception exception)
            {
                
                Console.WriteLine(exception);
            }
            
            

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
