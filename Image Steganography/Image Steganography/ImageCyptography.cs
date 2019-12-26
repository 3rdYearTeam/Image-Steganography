using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;
using static Image_Steganography.Tools;

namespace Image_Steganography
{
    class ImageCyptography
    {
        static public KeyValuePair<string , BitArray> Encrypte(string path)
        {
            Bitmap bitmap = new Bitmap(path);
            StringBuilder str = new StringBuilder("");

            BitArray bitArray1 = ConvertIntToBits(bitmap.Width);
            BitArray bitArray2 = ConvertIntToBits(bitmap.Height);
            byte Byte = 0;
            
            for(int i = 0; i < 2; i ++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int x;

                    if (bitArray1[i * 8 + j])
                        x = 1;
                    else
                        x = 0;

                    Byte = SetBitValue(Byte, j, x);
                }

                str.Append((char)(Byte));
            }


            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int x;

                    if (bitArray2[i * 8 + j])
                        x = 1;
                    else
                        x = 0;

                    Byte = SetBitValue(Byte, j, x);
                }

                str.Append((char)Byte);
            }


            for (int i = 0; i < bitmap.Width; i ++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    str.Append((char)pixel.R);
                    str.Append((char)pixel.G);
                    str.Append((char)pixel.B);
                }
            }

            var temp = Vigenere.EncryptText(str);
            return new KeyValuePair<string, BitArray>(temp.Key, ConvertStringToBits(temp.Value.ToString()));
        }

        static public string Decrypt(string text, string key)
        {
            return Vigenere.DecryptText(new System.Text.StringBuilder(text), key).ToString();
        }

        static public string BytesArrayToImage(byte[] bytesArr, string path)
        {
            string newPath = path.Replace(".png", "Decrepted.png");
            BitArray bitArray = new BitArray(16);
            int width = (int)bytesArr[0];
            int height = (int)bytesArr[2];

            
            for(int j = 0; j < 8; j ++)
            {
                width = SetBitValue(width, 8 + j, GetBit(bytesArr[1], j));
            }

            for (int j = 0; j < 8; j++)
            {
                height = SetBitValue(height, 8 + j, GetBit(bytesArr[3], j));
            }

            Bitmap bitmap = new Bitmap(width, height);
            int k = 4;

            for(int i = 0; i < width; i ++)
            {
                for(int j = 0; j < height; j ++, k += 3)
                {
                    Color color = Color.FromArgb(bytesArr[k], bytesArr[k + 1], bytesArr[k + 2]);
                    bitmap.SetPixel(i, j, color);
                }
            }

            bitmap.Save(newPath);
            return newPath;
        }

        static public byte[] ConvertStringToBytes(string text)
        {
            byte []byteArray = new byte[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                byteArray[i] = (byte)text[i];
            }

            return byteArray;
        }
    }
}
