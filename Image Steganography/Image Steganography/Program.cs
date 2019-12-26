using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Image_Steganography
{
    class Program
    {
        public static void TextTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            CoverImage coverImage = new CoverImage();
            String coverImagePath =new String( "C:\\Users\\Ahmed\\Desktop\\Screenshot_1564373281.png");
            String stegoImagePath =new String("C:\\Users\\Ahmed\\Desktop\\Screenshot_15643732812.png");
            coverImage.ReadImage(coverImagePath);
            Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");

            stopwatch = Stopwatch.StartNew();
            var encryption = RSA.RSAEncryption(new String("Hello, Hello, Can you hear me ? <3 <3 :* :*"));
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

        public static void ImageTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            CoverImage coverImage = new CoverImage();
            StegoImage stegoImage = new StegoImage();
            String coverImagePath = new String("C:\\Users\\Ahmed\\Desktop\\Screenshot_1564373281.png");
            String stegoImagePath = new String("C:\\Users\\Ahmed\\Desktop\\Screenshot_15643732812.png");
            var encryption = ImageCyptography.Encrypte("C:\\Users\\Ahmed\\Desktop\\1.png");
            
            coverImage.ReadImage(coverImagePath);
            coverImage.EmbedData(encryption.Value, (int)FileType.image);
            coverImage.SaveImage(stegoImagePath);
            stegoImage.ReadImage(stegoImagePath);
            
            var encryptedData = stegoImage.GetData();
            var path = (string)File.GetCorrespondingData(encryptedData, FileType.image, encryption.Key, "C:\\Users\\Ahmed\\Desktop\\1.png");
            
            Console.WriteLine(path);
            Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");
        }

        public static void FileTest()
        {
            FileStream inputStream = new FileStream("C:\\Users\\Ahmed\\Downloads\\[MS2 Tests] RSA\\Complete Test\\TestRSA.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(inputStream);

            sr.ReadLine(); 

            while(!sr.EndOfStream)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                string n = sr.ReadLine();
                string e = sr.ReadLine();
                string m = sr.ReadLine();
                string x = sr.ReadLine();

                
                Console.WriteLine(BigInteger.FastPower(new String(m), new String(e), new String(n)).ToString());
   
                Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");
            }

            inputStream.Close();
        }

        public static void MultiplyFileTest()
        {
            FileStream inputStream = new FileStream("C:\\Users\\Ahmed\\Downloads\\[MS1 Tests] RSA\\SampleRSA_I\\SubtractTestCases.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(inputStream);

            sr.ReadLine();
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                string n = sr.ReadLine();
                string e = sr.ReadLine();
                sr.ReadLine();


                Console.WriteLine(n + "\n" + e);
                Console.WriteLine(BigInteger.StringSubtraction(new String(n), new String(e)).ToString());
                Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");
                Console.WriteLine();
            }

            inputStream.Close();
        }

        static unsafe void Main()
        {
            ImageTest();
            //MultiplyFileTest();
            //TextTest();
            //FileTest();
            //Thread thread = new Thread(Program.FileTest, 1024 * 1024 * 1024);
            //thread.Start();
            //Console.WriteLine(BigInteger.Div(new String("16"), new String("5")).ToString());
            //Console.WriteLine(BigInteger.FastMultiply(new String("5"), new String("5")).ToString());
            //Console.WriteLine(BigInteger.FastPower(new String("5"), new String("2"), new String("7")).ToString());
            //Console.WriteLine(BigInteger.Div(new String("41766942386500566296578237070670959299719447915305139877556131342637463900048558377157395064819754504877734317556821079"), new String("12345678908765435451231232435465767657456453453465475654264325")).r.ToString());
            //Console.WriteLine(BigInteger.StringSubtraction(new String("321"), new String("123")).ToString());
        }
    }
}
