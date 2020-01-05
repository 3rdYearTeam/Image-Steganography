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
        private static String one = new String("1");//O(1)
        private static readonly String zero = new String("0");//O(1)
        private static String n, phi, e; //O(1)
        private static bool Generated = false; //O(1)

        public static String ConvertToNumber(String s) // O(N)
        {
            String result = new String(), temp; // O(1)
            int sz = s.Size(), x; // O(1)
             // O(N)
            for (int i = 0; i < sz; i++) // O(1)
            {
                x = s[i]; // O(1)
                temp = new String(x.ToString()); // O(1)

                if (temp.Size() % 3 != 0) // O(1)
                    temp = PadLeft(temp, 3 - temp.Size() % 3); // O(1)

                result.PushBack(temp); // O(1)
            }

            return result; // O(1)
        }
        public static String ConvertToText(String s)  // O(N)
        {
            s = s.Clone(); // O(N)
            String result = new String(); // O(1)
            int x = 0; // O(1)

            if (s.Size() % 3 != 0) // O(1)
            {
                s = PadLeft(s,  3 - s.Size() % 3);  // O(1)
            }
            // O(N)
            for (int i = 0, j; i < s.Size();) // O(1)
            {
                j = 2; // O(1)
                x = 0; // O(1)

                while (j >= 0) // O(1)
                {
                    if (j == 2) // O(1)
                        x += (s[i] - '0') * 100; // O(1)
                    else if (j == 1) // O(1)
                        x += (s[i] - '0') * 10; // O(1)
                    else // O(1)
                        x += (s[i] - '0'); // O(1)
                    j--; // O(1)
                    i++; // O(1)
                }

                result.PushBack((char)x); // O(1)
            }

            return result; // O(1)
        }

        private static String[] BlocksSplit(String text) // O(N)
        {
            int blockSize = (n.Size() - 1) / 3, rem = 0; // O(1)

            if (text.Size() % blockSize != 0) // O(1)
                rem = 1; // O(1)

            String[] blocks = new String[text.Size() / blockSize + rem]; // O(N)
            String temp = new String(""); // O(1)
             // O(N)
            for (int i = 0; i < text.Size(); i++) // O(1)
            {
                if (i % blockSize == 0 && i != 0) // O(1)
                {
                    blocks[i / blockSize - 1] = temp; // O(1)
                    temp = new String(""); // O(1)
                }

                temp.PushBack(text[i]); // O(1)
            }

            if (temp.Size() > 0) // O(1)
                blocks[blocks.Length - 1] = temp; // O(1)

            return blocks; // O(1)
        }

        private static void ConvertNumToBits(BitArray bitArray, int s, String text) // O(TextSize LOG X)
        {
            // O(TextSize LOG X)
            for (int i = 0; i < text.Size(); i++) // O(1)
            {
                char ch = text[i]; // O(1)
                int x = ch - '0', c = 0; // O(1)
                 // O(Log X)
                while (x != 0) // O(1)
                {
                    if (x % 2 == 1) // O(1)
                        bitArray[s++] = true; // O(1)
                    else
                        bitArray[s++] = false; // O(1)

                    x >>= 1; // O(1)
                    c++; // O(1)
                }
                // O(1)
                for (int j = 0; j < 4 - c % 4 && c != 4; j++) // O(1)
                    bitArray[s++] = false; // O(1)
            }
        }


        private static BitArray ConvertBlocksToBits(List<String> encryption)  // O(N * TextSize LOG X)

        {
            int sz = encryption.Count * 4; // O(1)
             // O(N)
            foreach (var text in encryption) // O(1)
            {
                sz += text.Size() * 4; // O(1)
            }

            BitArray bitArray = new BitArray(sz); // O(SZ)
            sz = 0; // O(1)
            // O(N * TextSize LOG X)
            foreach (var text in encryption) // O(1)
            {
                ConvertNumToBits(bitArray, sz, text); // O(TextSize LOG X)
                sz += text.Size() * 4; // O(1)

                for (int i = 0; i < 4; i++) // O(1)
                    bitArray[sz++] = true; // O(1)
            }

            return bitArray; // O(1)
        }

        private static String ConvertBitsToNumbers(BitArray bitarray, ref int s) //O(N)
        {
            String text = new String(); // O(1)
            int x = 0, p = 1, i; // O(1)
            //O(N)
            for (i = s; i < bitarray.Count; i++) // O(1)
            {
                if (i % 4 == 0 && p != 1) // O(1)
                {
                    if (x == 15) // O(1)
                        break; // O(1)

                    text.PushBack(x.ToString()); // O(1)
                    x = 0; // O(1)
                    p = 1; // O(1)
                }

                if (bitarray[i]) // O(1)
                    x += p; // O(1)

                p <<= 1; // O(1)
            }

            s = i; // O(1)
            return text; // O(1)
        }


        public static KeyValuePair<String, BitArray> RSAEncryption(String text)  // O(N^2 * Log n * Log p)
        {
            GeneratePublickKey();//O(log(A * B) * NLogN)
            String privateKey = GeneratePrivateKey(); //O(log(A * B) * NLogN)
            String[] blocks = BlocksSplit(text); //O(N)
            List<String> encryptedTexts = new List<String>(); // O(1)
            // O(N^2 * Log n * Log p)
            for (int i = 0; i < blocks.Length; i++) // O(1)
            {
                blocks[i] = ConvertToNumber(blocks[i]); //O(N)
                encryptedTexts.Add(FastPower(blocks[i], e.Clone(), n.Clone()));// O(N * Log n * Log p)
            }

            return new KeyValuePair<String, BitArray>(privateKey, ConvertBlocksToBits(encryptedTexts));// O(N * TextSize LOG X)
        }

        public static String RSADecryption(BitArray bitArray, String d)  //O(// O(N^2 * Log n * Log p))
        {
            GeneratePublickKey();//O(log(A * B) * NLogN)
            int sz = 0; // O(1)
            String decryptedText = new String("");// O(1)
            //O(// O(N^2 * Log n * Log p))
            while (sz != bitArray.Length) // O(1)
            {
                String subText = FastPower(ConvertBitsToNumbers(bitArray, ref sz), d.Clone(), n);// O(N * Log n * Log p)
                subText = ConvertToText(subText); // O(N)
                decryptedText.PushBack(subText); // O(1)
            }

            return decryptedText; //O(1)
        }

        private static int GetAsYouCan(long timeStamp) //O(1)
        {
            long seed = 0; //O(1)
            int p = 1; //O(1)

            while (seed + (timeStamp % 10) * p < int.MaxValue) //O(1)
            {
                seed += (timeStamp % 10) * p; //O(1)
                timeStamp /= 10; //O(1)
                p *= 10; //O(1)
            }

            return Convert.ToInt32(seed); //O(1)
        }


        public static String RandomValue()//O(1)
        {
            var timeStamp = new DateTimeOffset(DateTime.UtcNow).ToFileTime();//O(1)
            int seed = GetAsYouCan(timeStamp);//O(1)
            Random rand = new Random(seed);//O(1)
            return new String(rand.Next(2, 1000).ToString());//O(1)
        }

        public static String GeneratePrivateKey()  // O(NlogN)
        {

            String k = one.Clone(); // O(1) // (k * phie + 1) % e == 0

            while (!Div(StringAddation(FastMultiply(phi, k), one), e.Clone()).r.Equals(zero)) // O(NllogN)// 0000 0000 
            {
                k = StringAddation(k, one.Clone()); // O(N)  // add one 
            }

            return Div(StringAddation(FastMultiply(phi, k), one), e.Clone()).q; // O(NlogN)
        }

        public static void GeneratePublickKey() //O(log(A * B) * NLogN)
        {
            if (!Generated)
            {
                //var pair = BigInteger.GbeneratePrime();
                String p =new String("1000000000000000000000000000000000000000000000000000000000007"), q = new String("1000000000000000000000000000000000000000000000000000000000067"); //O(1) // function tgbln el arkam el prime must be not equal
                n = FastMultiply(p, q); //O(NlogN)
                phi = FastMultiply(StringSubtraction(p, one), StringSubtraction(q, one));//O(NlogN)
                Generated = true;//O(1)
            }

            e = RandomValue(); //O(1) // coprime to phi

            while (!one.Equals(GCD(e.Clone(), phi.Clone()))) //O(log(A * B) * NLogN)
            {
                e = StringAddation(e, one); //O(N)
            }

        }

    }
}
