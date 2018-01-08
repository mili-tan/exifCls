using System;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace exifCls
{
    class Program
    {
        static void Main(string[] args)
        {
            string myPath = null;
            try
            {
                myPath = args[0];
            }
            catch (Exception)
            {
                Console.WriteLine("启动参数为空");
            }
            while (string.IsNullOrEmpty(myPath))
            {
                myPath = Console.ReadLine();
            }

            Image image = Image.FromFile(myPath);
            foreach (PropertyItem unused in image.PropertyItems)
            {
                PropertyItem pi = image.PropertyItems[0];
                pi.Id = 0;
                pi.Type = 0;
                pi.Value = Encoding.UTF7.GetBytes("CSCWORM");
                pi.Len = 0;
                image.SetPropertyItem(pi);
            }
            image.Save("cls.png");
            image.Dispose();
        }
    }
}
