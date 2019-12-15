using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace Image_Steganography
{
    class Program
    {

        static void Test()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            CoverImage coverImage = new CoverImage();
            string coverImagePath = "C:\\Users\\Ahmed\\Desktop\\Screenshot_1564373281.png";
            string stegoImagePath = "C:\\Users\\Ahmed\\Desktop\\Screenshot_15643732812.png";
            coverImage.ReadImage(coverImagePath);

            var encryption = RSA.RSAEncryption("Hello, Hello, CAN you hear me ? :D :D :* :* <3 <3");
            coverImage.EmbedData(encryption.Value, (int)FileType.text);
            coverImage.SaveImage(stegoImagePath);

            StegoImage stegoImage = new StegoImage();
            stegoImage.ReadImage(stegoImagePath);
            var embeddedData = stegoImage.GetData();
            Console.WriteLine(RSA.RSADecryption(embeddedData, encryption.Key));

            Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");
        }

        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
