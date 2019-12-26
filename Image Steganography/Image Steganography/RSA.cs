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
        private static String one = new String("1");
        private static readonly String zero = new String("0");
        private static String n, phi, e;
        private static bool Generated = false;

        public static String ConvertToNumber(String s)
        {
            String result = new String(), temp;
            int sz = s.Size(), x;

            for (int i = 0; i < sz; i++)
            {
                x = s[i];
                temp = new String(x.ToString());
                
                if(temp.Size() % 3 != 0)
                    temp = PadLeft(temp, 3 - temp.Size() % 3);
               
                result.PushBack(temp);
            }

            return result;
        }
        public static String ConvertToText(String s)
        {
            s = s.Clone();
            String result = new String();
            int x = 0;

            if (s.Size() % 3 != 0)
            {
                s = PadLeft(s,  3 - s.Size() % 3); 
            }

            for (int i = 0, j; i < s.Size();)
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

                result.PushBack((char)x);
            }

            return result;
        }

        private static String[] BlocksSplit(String text)
        {
            int blockSize = (n.Size() - 1) / 3, rem = 0;

            if (text.Size() % blockSize != 0)
                rem = 1;

            String[] blocks = new String[text.Size() / blockSize + rem];
            String temp = new String("");

            for (int i = 0; i < text.Size(); i++)
            {
                if (i % blockSize == 0 && i != 0)
                {
                    blocks[i / blockSize - 1] = temp;
                    temp = new String("");
                }

                temp.PushBack(text[i]);
            }

            if (temp.Size() > 0)
                blocks[blocks.Length - 1] = temp;

            return blocks;
        }

        private static void ConvertNumToBits(BitArray bitArray, int s, String text)
        {
            for (int i = 0; i < text.Size(); i++)
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


        private static BitArray ConvertBlocksToBits(List<String> encryption)
        {
            int sz = encryption.Count * 4;

            foreach (var text in encryption)
            {
                sz += text.Size() * 4;
            }

            BitArray bitArray = new BitArray(sz);
            sz = 0;

            foreach (var text in encryption)
            {
                ConvertNumToBits(bitArray, sz, text);
                sz += text.Size() * 4;

                for (int i = 0; i < 4; i++)
                    bitArray[sz++] = true;
            }

            return bitArray;
        }

        private static String ConvertBitsToNumbers(BitArray bitarray, ref int s)
        {
            String text = new String();
            int x = 0, p = 1, i;

            for (i = s; i < bitarray.Count; i++)
            {
                if (i % 4 == 0 && p != 1)
                {
                    if (x == 15)
                        break;

                    text.PushBack(x.ToString());
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


        public static KeyValuePair<String, BitArray> RSAEncryption(String text)
        {
            GeneratePublickKey();
            String privateKey = GeneratePrivateKey();
            String[] blocks = BlocksSplit(text);
            List<String> encryptedTexts = new List<String>();

            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = ConvertToNumber(blocks[i]);
                encryptedTexts.Add(FastPower(blocks[i], e.Clone(), n.Clone()));
            }

            return new KeyValuePair<String, BitArray>(privateKey, ConvertBlocksToBits(encryptedTexts));
        }

        public static String RSADecryption(BitArray bitArray, String d)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            GeneratePublickKey();
            int sz = 0;
            String decryptedText = new String("");
      
            while (sz != bitArray.Length)
            {
                String subText = FastPower(ConvertBitsToNumbers(bitArray, ref sz), d.Clone(), n);
                subText = ConvertToText(subText);
                decryptedText.PushBack(subText);
            }
            
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

        public static String RandomValue()
        {
            var timeStamp = new DateTimeOffset(DateTime.UtcNow).ToFileTime();
            int seed = GetAsYouCan(timeStamp);
            Random rand = new Random(seed);
            return new String(rand.Next(2, 1000).ToString());
        }

        public static String GeneratePrivateKey()
        {

            String k = one.Clone(); // (k * phie + 1) % e == 0

            while (!Div(StringAddation(FastMultiply(phi, k), one), e.Clone()).r.Equals(zero))// 0000 0000 
            {
                k = StringAddation(k, one.Clone());  // add one 
            }

            return Div(StringAddation(FastMultiply(phi, k), one), e.Clone()).q;
        }

        public static void GeneratePublickKey()
        {
            if (!Generated)
            {
                String p =new String("1000000007"), q = new String("20988936657440586486151264256610222593863921"); // function tgbln el arkam el prime must be not equal
                n = FastMultiply(p, q);
                phi = FastMultiply(StringSubtraction(p, one), StringSubtraction(q, one));
                Generated = true;
            }

            e = RandomValue(); // coprime to phi

            while (!one.Equals(GCD(e.Clone(), phi.Clone())))
            {
                e = StringAddation(e, one);
            }

        }

    }
}
