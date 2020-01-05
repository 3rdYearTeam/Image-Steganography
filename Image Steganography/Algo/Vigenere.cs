using System;
using System.Text;
using System.Collections.Generic;

namespace Image_Steganography
{
    class Vigenere
    {
        static private StringBuilder key;

        static private void RandomizeKey(int sz)
        {
            var charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            key = new StringBuilder("");
            Random random = new Random();

            for (int i = 0; i < sz; i++)
            {
                key.Append(charArray[random.Next(charArray.Length)]);
            }
        }

        static private void GenerateKey(StringBuilder text)
        {
            RandomizeKey(text.Length);
        }

        static public KeyValuePair<string, string> EncryptText(StringBuilder text)// O(N^2)
        {
            StringBuilder encryptedText = new StringBuilder("");// O(1)
            GenerateKey(text);// O(N)
            // O(N)
            for (int i = 0; i < text.Length; i++)// O(1)
            {
                int x = (text[i] + key[i]) % 255;// O(1)

                encryptedText.Append((char)x);// O(1)
            }

            return new KeyValuePair<string, string>(key.ToString(), encryptedText.ToString());// O(N)
        }

        static public StringBuilder DecryptText(StringBuilder encText, string key) // O(N)
        {
            StringBuilder originalText = new StringBuilder("");// O(1)
           // O(n)
            for (int i = 0; i < encText.Length; i++)// O(1)
            {
                int x = (encText[i] - key[i] + 255) % 255;// O(1)
                originalText.Append((char)x);// O(1)
            }// O(1)

            return originalText;// O(1)
        }

    }
}
