using System.Text;

namespace Image_Steganography
{
    class Vigenere
    {
        private StringBuilder key;
        private int keyLength;
        public Vigenere()
        {
            this.key = new StringBuilder("saberr");
        }
        public void updateKey(StringBuilder s)
        {
            this.key = s;
            this.keyLength = s.Length;
        }
        public void generateKey(StringBuilder text)
        {
            this.keyLength = key.Length;
            StringBuilder k = this.key;
            for (int i = 0; i < text.Length; i++)
            {
                if (k.Length == text.Length)
                    break;
                if (i == keyLength)
                    i = 0;
                k.Append((key[i]));
            }
            key = k;
        }

        public StringBuilder encryptText(StringBuilder text)
        {
            StringBuilder encryptedText = new StringBuilder("");
            generateKey(text);

            for (int i = 0; i < text.Length; i++)
            {
                int x = (text[i] + this.key[i]) % 255;

                encryptedText.Append((char)x);
            }
            return encryptedText;

        }

        public StringBuilder decryptText(StringBuilder encText)
        {
            StringBuilder originalText = new StringBuilder("");
            for (int i = 0; i < encText.Length; i++)
            {
                int x = (encText[i] - this.key[i] + 255) % 255;
                originalText.Append((char)x);
            }
            return originalText;
        }

    }
}
