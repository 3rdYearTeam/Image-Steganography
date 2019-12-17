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
            StringBuilder coverImagePath =new StringBuilder( "C:\\Users\\Ahmed\\Desktop\\Screenshot_1564373281.png");
            StringBuilder stegoImagePath =new StringBuilder("C:\\Users\\Ahmed\\Desktop\\Screenshot_15643732812.png");
            coverImage.ReadImage(coverImagePath);
            Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");

            stopwatch = Stopwatch.StartNew();
            var encryption = RSA.RSAEncryption(new StringBuilder("Hello, Hello, CAN you hear me ? :D :D :* :* <3 <3"));
            coverImage.EmbedData(encryption.Value, (int)FileType.text);
            coverImage.SaveImage(stegoImagePath);
            Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");

            stopwatch = Stopwatch.StartNew();
            StegoImage stegoImage = new StegoImage();
            stegoImage.ReadImage(stegoImagePath);
            var embeddedData = stegoImage.GetData();
            Console.WriteLine(RSA.RSADecryption(embeddedData, encryption.Key).ToString());
            Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");
        }


        static void Main()
        {
            Test();
        }
    }
}
