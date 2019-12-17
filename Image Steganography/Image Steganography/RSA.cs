using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using static Image_Steganography.BigInteger;

namespace Image_Steganography
{
    class RSA
    {
        private static readonly StringBuilder one = new StringBuilder("1");
        private static readonly StringBuilder zero = new StringBuilder("0");
        private static StringBuilder n, phi, e;
        private static bool Generated = false;

        public static StringBuilder ConvertToNumber(StringBuilder s)
        {
            StringBuilder result = new StringBuilder(""), temp;
            int sz = s.Length, x;

            for (int i = 0; i < sz; i++)
            {
                x = s[i];
                temp = new StringBuilder(x.ToString());
                
                if(temp.Length % 3 != 0)
                    temp = PadLeft(temp, 3 - temp.Length % 3);
               
                result.Append(temp);
            }

            return result;
        }
        public static StringBuilder ConvertToText(StringBuilder s)
        {
            StringBuilder result = new StringBuilder("");
            int x = 0;

            if (s.Length % 3 != 0)
            {
                s = PadLeft(s,  3 - s.Length % 3); 
            }

            for (int i = 0, j; i < s.Length;)
            {
                j = 2;
                x = 0;

                while (j >= 0)
                {
                    if (j == 2)
                        x += (s[i] - '0') * 100;
                    else if (j == 1)
                        x += (s[i] - '0') * 10;
                    else
                        x += (s[i] - '0');
                    j--;
                    i++;
                }

                result.Append((char)x);
            }

            return result;
        }

        private static StringBuilder[] BlocksSplit(StringBuilder text)
        {
            int blockSize = (n.Length - 1) / 3, rem = 0;

            if (text.Length % blockSize != 0)
                rem = 1;

            StringBuilder[] blocks = new StringBuilder[text.Length / blockSize + rem];
            StringBuilder temp = new StringBuilder("");

            for (int i = 0; i < text.Length; i++)
            {
                if (i % blockSize == 0 && i != 0)
                {
                    blocks[i / blockSize - 1] = temp;
                    temp = new StringBuilder("");
                }

                temp.Append(text[i]);
            }

            if (temp.Length > 0)
                blocks[blocks.Length - 1] = temp;

            return blocks;
        }

        private static void ConvertNumToBits(BitArray bitArray, int s, StringBuilder text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                int x = ch - '0', c = 0;

                while (x != 0)
                {
                    if (x % 2 == 1)
                        bitArray[s++] = true;
                    else
                        bitArray[s++] = false;

                    x >>= 1;
                    c++;
                }

                for (int j = 0; j < 4 - c % 4 && c != 4; j++)
                    bitArray[s++] = false;
            }
        }


        private static BitArray ConvertBlocksToBits(List<StringBuilder> encryption)
        {
            int sz = encryption.Count * 4;

            foreach (var text in encryption)
            {
                sz += text.Length * 4;
            }

            BitArray bitArray = new BitArray(sz);
            sz = 0;

            foreach (var text in encryption)
            {
                ConvertNumToBits(bitArray, sz, text);
                sz += text.Length * 4;

                for (int i = 0; i < 4; i++)
                    bitArray[sz++] = true;
            }

            return bitArray;
        }

        private static StringBuilder ConvertBitsToNumbers(BitArray bitarray, ref int s)
        {
            StringBuilder text = new StringBuilder("");
            int x = 0, p = 1, i;

            for (i = s; i < bitarray.Count; i++)
            {
                if (i % 4 == 0 && p != 1)
                {
                    if (x == 15)
                        break;

                    text.Append(x);
                    x = 0;
                    p = 1;
                }

                if (bitarray[i])
                    x += p;

                p <<= 1;
            }

            s = i;
            return text;
        }


        public static KeyValuePair<StringBuilder, BitArray> RSAEncryption(StringBuilder text)
        {
            GeneratePublickKey();
            StringBuilder privateKey = GeneratePrivateKey();
            StringBuilder[] blocks = BlocksSplit(text);
            List<StringBuilder> encryptedTexts = new List<StringBuilder>();

            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = ConvertToNumber(blocks[i]);
                encryptedTexts.Add(Div(FastPower(blocks[i], e, n), n).r);
            }

            return new KeyValuePair<StringBuilder, BitArray>(privateKey, ConvertBlocksToBits(encryptedTexts));
        }

        public static StringBuilder RSADecryption(BitArray bitArray, StringBuilder d)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            GeneratePublickKey();
            Console.WriteLine("public: " + stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");

            int sz = 0;
            StringBuilder decryptedText = new StringBuilder("");
            
            stopwatch = Stopwatch.StartNew();

            while (sz != bitArray.Length)
            {
                StringBuilder subText = Div(FastPower(ConvertBitsToNumbers(bitArray, ref sz), d, n), n).r;
                subText = ConvertToText(subText);
                decryptedText.Append(subText);
            }
            Console.WriteLine("Decrypt: " + stopwatch.ElapsedMilliseconds + "ms," + stopwatch.ElapsedMilliseconds / 1000 + "s");

            return decryptedText;
        }

        private static int GetAsYouCan(long timeStamp)
        {
            long seed = 0;
            int p = 1;

            while (seed + (timeStamp % 10) * p < int.MaxValue)
            {
                seed += (timeStamp % 10) * p;
                timeStamp /= 10;
                p *= 10;
            }

            return Convert.ToInt32(seed);
        }

        public static StringBuilder RandomValue()
        {
            var timeStamp = new DateTimeOffset(DateTime.UtcNow).ToFileTime();
            int seed = GetAsYouCan(timeStamp);
            Random rand = new Random(seed);
            return new StringBuilder(rand.Next(2, 1000).ToString());
        }

        public static StringBuilder GeneratePrivateKey()
        {

            StringBuilder k = one; // (k * phie + 1) % e == 0

            while (!Div(StringAddation(Multiply(phi, k), one), e).r.Equals(zero))// 0000 0000 
            {
                k = StringAddation(k, one);  // add one 
            }

            return Div(StringAddation(Multiply(phi, k), one), e).q;
        }

        public static void GeneratePublickKey()
        {
            if (!Generated)
            {
                StringBuilder p =new StringBuilder("1000000007"), q = new StringBuilder("20988936657440586486151264256610222593863921"); // function tgbln el arkam el prime must be not equal
                n = Multiply(p, q);
                phi = Multiply(StringSubtraction(p, one), StringSubtraction(q, one));
                Generated = true;
            }

            e = RandomValue(); // coprime to phi

            while (!one.Equals(GCD(e, phi)))
            {
                e = StringAddation(e, one);
            }

        }

    }
}
