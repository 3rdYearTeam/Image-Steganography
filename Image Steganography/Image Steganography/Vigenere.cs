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

        static public KeyValuePair<string, string> EncryptText(StringBuilder text)
        {
            StringBuilder encryptedText = new StringBuilder("");
            GenerateKey(text);

            for (int i = 0; i < text.Length; i++)
            {
                int x = (text[i] + key[i]) % 255;

                encryptedText.Append((char)x);
            }

            return new KeyValuePair<string, string>(key.ToString(), encryptedText.ToString());
        }

        static public StringBuilder DecryptText(StringBuilder encText, string key)
        {
            StringBuilder originalText = new StringBuilder("");
           
            for (int i = 0; i < encText.Length; i++)
            {
                int x = (encText[i] - key[i] + 255) % 255;
                originalText.Append((char)x);
            }

            return originalText;
        }

    }
}
