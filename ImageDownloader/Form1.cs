using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownloader
{
    
   
    public partial class Form1 : Form
    {

        Downloader downloader;
        public Form1()
        {
             const string apiKey = "AIzaSyC3u5jYwwZVqSq-JQge2gYHqDKErrCo1Sc";
             const string searchEngineId = "002939223692517534743:_6gyhcdvzrg";

             InitializeComponent();

             downloader = new Downloader(apiKey, searchEngineId);
        }

        private void search_Click(object sender, EventArgs e)
        {
            downloader.search(searchBox.Text.ToString());
            
        }
    }
}
