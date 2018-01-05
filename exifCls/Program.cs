using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace exifCls
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyPath = null;
            try
            {
                MyPath = args[0];
            }
            catch (Exception)
            {
                Console.WriteLine("启动参数为空");
            }
            while (string.IsNullOrEmpty(MyPath))
            {
                MyPath = Console.ReadLine();
            }

            Image image = Image.FromFile(MyPath);
            foreach (PropertyItem p in image.PropertyItems)
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
