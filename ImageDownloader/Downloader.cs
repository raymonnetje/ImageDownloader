using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader
{
    public class Downloader
    {
        private int count = 0;
        private Bitmap bitmap;

        public void download(ArrayList images, string title)
        {
            Console.WriteLine(images.Count);
            foreach (Image tmpImage in images)
            {
                try
                {
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead(tmpImage.link);
                    bitmap = new Bitmap(stream);
                    stream.Flush();
                    stream.Close();
                    Console.WriteLine(tmpImage.link);
                    SaveImage(title, bitmap.RawFormat);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public Bitmap GetImage()
        {
            return bitmap;
        }

        public void SaveImage(string filename, ImageFormat format)
        {
            count++;
            if (bitmap != null)
            {
                Console.Write(format.ToString());
                bitmap.Save(@"c:\\saves\\" + filename + count +".jpeg", ImageFormat.Jpeg);

            }
        }
    }
}
