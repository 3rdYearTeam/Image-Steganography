using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;
using static Image_Steganography.Tools;
using System.Drawing.Imaging;
namespace Image_Steganography
{
    class ImageCyptography
    {
        static public KeyValuePair<string , BitArray> Encrypte(string path)
        {
            Bitmap bitmap = new Bitmap(path);// O(1)
            StringBuilder str = new StringBuilder("");// O(1)

            BitArray bitArray1 = ConvertIntToBits(bitmap.Width);// O(1)
            BitArray bitArray2 = ConvertIntToBits(bitmap.Height);// O(1)
            byte Byte = 0;// O(1)
            // O(1)
            for (int i = 0; i < 2; i ++)// O(1)
            {// O(1)
                for (int j = 0; j < 8; j++)// O(1)
                {
                    int x;// O(1)

                    if (bitArray1[i * 8 + j])// O(1)
                        x = 1;// O(1)
                    else
                        x = 0;// O(1)

                    Byte = SetBitValue(Byte, j, x);// O(1)
                }

                str.Append((char)(Byte));// O(1)
            }

            // O(1)
            for (int i = 0; i < 2; i++)
            {// O(1)
                for (int j = 0; j < 8; j++)// O(1)
                {// O(1)
                    int x;// O(1)

                    if (bitArray2[i * 8 + j])// O(1)
                        x = 1;// O(1)
                    else
                        x = 0;// O(1)

                    Byte = SetBitValue(Byte, j, x);// O(1)
                }

                str.Append((char)Byte);// O(1)
            }

            // O(N^2)
            for (int i = 0; i < bitmap.Width; i ++)// O(1)
            {
                for(int j = 0; j < bitmap.Height; j++)// O(1)
                {
                    var pixel = bitmap.GetPixel(i, j);// O(1)
                    str.Append((char)pixel.R);// O(1)
                    str.Append((char)pixel.G);// O(1)
                    str.Append((char)pixel.B);// O(1)
                }
            }

            var temp = Vigenere.EncryptText(str);// O(n)
            return new KeyValuePair<string, BitArray>(temp.Key, ConvertStringToBits(temp.Value.ToString())); // O(n)
        }

        static public string Decrypt(string text, string key)// O(N)
        {
            return Vigenere.DecryptText(new System.Text.StringBuilder(text), key).ToString();// O(N)
        }

        static public string BytesArrayToImage(byte[] bytesArr, string path)
        {
            string newPath = path.Replace(".png", "Decrepted.png");// O(1)
            BitArray bitArray = new BitArray(16);// O(1)
            int width = (int)bytesArr[0];// O(1)
            int height = (int)bytesArr[2];// O(1)

            // O(1)
            for (int j = 0; j < 8; j ++)// O(1)
            {
                width = SetBitValue(width, 8 + j, GetBit(bytesArr[1], j));// O(1)
            }
            // O(1)
            for (int j = 0; j < 8; j++)// O(1)
            {
                height = SetBitValue(height, 8 + j, GetBit(bytesArr[3], j));// O(1)
            }

            Bitmap bitmap = new Bitmap(width, height);// O(N^2)
            int k = 4;// O(1)
            // O(N^2)
            for (int i = 0; i < width; i ++)// O(1)
            {
                for(int j = 0; j < height; j ++, k += 3)// O(1)
                {
                    Color color = Color.FromArgb(bytesArr[k], bytesArr[k + 1], bytesArr[k + 2]);// O(1)
                    bitmap.SetPixel(i, j, color);// O(1)
                }
            }

            bitmap.Save(newPath, ImageFormat.Png);// O(1)
            return newPath;// O(1)
        }

        static public byte[] ConvertStringToBytes(string text)// O(N)
        {
            byte []byteArray = new byte[text.Length];// O(1)
            // O(N)
            for (int i = 0; i < text.Length; i++)// O(1)
            {
                byteArray[i] = (byte)text[i];// O(1)
            }

            return byteArray;// O(1)
        }
    }
}
