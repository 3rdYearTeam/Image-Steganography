using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography
{
    class Vigenere
    {
        private string key;
        private int keyLength;
        public Vigenere()
        {
            this.key = "saber";
        }
        public void updateKey(string s)
        {
            this.key = s;
            this.keyLength = s.Length;
        }
        public void generateKey(string text)
        {
            this.keyLength = key.Length;
            string k = this.key;
            for (int i = 0; i < text.Length; i++)
            {
                if (k.Length == text.Length)
                    break;
                if (i == keyLength)
                    i = 0;
                k += (key[i]);
            }
            key = k;
        }

        public string encryptText(string text)
        {
            string encryptedText = "";
            generateKey(text);

            for (int i = 0; i < text.Length; i++)
            {
                int x = (text[i] + this.key[i]) % 255;

                encryptedText += (char)x;
            }
            return encryptedText;

        }

        public string decryptText(string encText)
        {
            string originalText = "";
            for (int i = 0; i < encText.Length; i++)
            {
                int x = (encText[i] - this.key[i] + 255) % 255;
                originalText += (char)x;
            }
            return originalText;
        }

    }
}
