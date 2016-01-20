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
        private int dirCount = 0;
        private Bitmap bitmap;

        public void download(ArrayList images, string title)
        {
            Console.WriteLine(images.Count);
            MakeDir(title);

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
                    SaveImage(bitmap.RawFormat);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void MakeDir(string title)
        {
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(@"c:\\saves\\" + title))
                {
                    dirCount++;
                    MakeDir(title + dirCount);

                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(@"c:\\saves\\" + title);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(@"c:\\saves\\" + title));

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            } 
        }

        public Bitmap GetImage()
        {
            return bitmap;
        }

        public void SaveImage(ImageFormat format)
        {
            count++;
            if (bitmap != null)
            {
                Console.Write(format.ToString());
                bitmap.Save(@"c:\\saves\\" + count +".jpeg", ImageFormat.Jpeg);

            }
        }
    }
}
