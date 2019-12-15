using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Image_Steganography
{
    class RSA
    {
        static private string n, phi, e;
        static private bool Generated = false;

        public static string MultiplyByTwo(string x)
        {
            string result = "";
            int carry = 0;

            for(int i = x.Length - 1; i >= 0; i --)
            {
                result = (((x[i] - '0') * 2 + carry) % 10).ToString() + result;
                carry = ((x[i] - '0') * 2) / 10;
            }

            if (carry > 0)
                result = carry.ToString() + result;

            return result;
        }

        public static string Multiply(string first, string second)
        {
            MakeLengthEqual(ref first, ref second);

            if (first.Length == 1 || second.Length == 1)
                return (long.Parse(first) * long.Parse(second)).ToString();

            int cutPos = GetPostion(ref first);
            string a = GetFirstPart(ref first, cutPos);
            string b = GetSecondPart(ref first, cutPos);
            string c = GetFirstPart(ref second, cutPos);
            string d = GetSecondPart(ref second, cutPos);

            string ac = Multiply(a, c);
            string bd = Multiply(b, d);
            string ab_cd = Multiply(StringAddation(a, b), StringAddation(c, d));

            return CalculateAnswer(ref ac, ref bd, ref ab_cd, b.Length + d.Length);
        }

        static string CalculateAnswer(ref string ac, ref string bd, ref string ab_cd, int padding)
        {
            string t = StringSubtraction(StringSubtraction(ab_cd, ac),   bd);
            string tt = t.PadRight(t.Length + padding / 2, '0');
            string ttt = ac.PadRight(ac.Length + padding, '0');

            return StringAddation(StringAddation(tt, ttt), bd);
        }

        static string GetFirstPart(ref string str, int cutPos)
        {
            return str.Substring(0, str.Length - cutPos);
        }

        static string GetSecondPart(ref string str, int cutPos)
        {
            return str.Substring(str.Length - cutPos);
        }

        static int GetPostion(ref string first)
        {
            return (first.Length + 1) / 2;
        }

        public static string StringAddation(string a, string b)
        {
            string result = "";
            
            if (a.Length > b.Length)
            {
                Swap(ref a, ref b);
            }
            
            MakeLengthEqual(ref a, ref b);
            int length = a.Length;
            int carry = 0, res;

            for (int i = length - 1; i >= 0; i--)
            {
                int n1 = int.Parse(a.Substring(i, 1));
                int n2 = int.Parse(b.Substring(i, 1));
                res = (n1 + n2 + carry) % 10;
                carry = (n1 + n2 + carry) / 10;
                result = res.ToString() + result;
            }

            if (carry != 0)
                result = carry.ToString() + result;
            
            return SanitizeResult(ref result);
        }

        public static string GCD(string a, string b)
        {
            if (b == "0")
                return a;

            return GCD(b, Div(a, b).r);
        }


        public static string StringSubtraction(string a, string b)
        {
            bool resultNegative = false;
            string result = "";

            if (StringIsSmaller(ref a, ref b))
            {
                Swap(ref a, ref b);
                resultNegative = true;
            }

            MakeLengthEqual(ref a, ref b);
            int length = a.Length;
            int carry = 0, res;
            
            for (int i = length - 1; i >= 0; i--)
            {
                bool nextCarry = false;
                int n1 = int.Parse(a.Substring(i, 1));
                int n2 = int.Parse(b.Substring(i, 1));

                if (n1 - carry < n2)
                {
                    n1 = n1 + 10;
                    nextCarry = true;
                }
                res = (n1 - n2 - carry);
                result = res.ToString() + result;
                if (nextCarry)
                    carry = 1;
                else
                    carry = 0;
            }
            
            result = SanitizeResult(ref result);
            
            if (resultNegative)
                return result = "-" + result;
            
            return result;
        }

        static bool StringIsSmaller(ref string a, ref string b)
        {
            if (a.Length < b.Length)
                return true;
            if (a.Length > b.Length)
                return false;
            
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < b[i])
                    return true;
                if (a[i] > b[i])
                    return false;
            }
            
            return false;
        }

        static void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        static string SanitizeResult(ref string result)
        {
            result = result.TrimStart(new char[] { '0' });
            
            if (result.Length == 0)
                result = "0";
            
            return result;
        }

        static void MakeLengthEqual(ref string x, ref string y)
        {
            if (x.Length == y.Length)
                return;
            
            if (x.Length > y.Length)
            {
                while (x.Length > y.Length)
                    y = '0' + y;
                return;
            }
            
            if (y.Length > x.Length)
            {
                while (y.Length > x.Length)
                    x = '0' + x;
                return;
            }
        }

        public class Pair
        {
            public string q, r;
        }

        public static string DivByTwo(string x)
        {
            string result = "";
            int last = 0;

            if (x[0] > '0')
            {
                if((x[0] - '0') % 2 != 0)
                    last = 5;

                if(x[0] > '1')
                    result += (x[0] - '0') / 2;
            }

            for(int i = 1; i < x.Length; i ++)
            {
                result += ((x[i] - '0') / 2 + last);

                if ((x[i] - '0') % 2 != 0)
                    last = 5;
                else
                    last = 0;
            }

            if (result.Length == 0)
                result = "0";

            return result;
        }

        public static Pair Div(string a, string b)
        {
            if (StringIsSmaller(ref a, ref b))
            {
                Pair p = new Pair()
                {
                    q = "0",
                    r = a
                };

                return p;
            }

            Pair p2 = Div(a, MultiplyByTwo(b));
            p2.q = MultiplyByTwo(p2.q);

            if (StringIsSmaller(ref p2.r, ref b))
                return p2;

            p2.q = StringAddation(p2.q, "1");
            p2.r = StringSubtraction(p2.r, b);
            return p2;
        }

        public static string FastPower(string a, string p, string mod)
        {
            string ans = "1", zero = "0";

            while (StringIsSmaller(ref zero, ref p))
            {
                if ((p[p.Length - 1] - '0') % 2 != 0)
                {
                    ans = Multiply(ans, a);

                    if (StringIsSmaller(ref mod, ref ans))
                        ans = Div(ans, mod).r;
                }

                a = Multiply(a, a);
                p = DivByTwo(p);

                if(StringIsSmaller(ref mod, ref a))
                    a = Div(a, mod).r;
            }

            return ans;
        }


        static public string ConvertToNumber(string s)
        {
            string result = "", temp;
            int sz = s.Length, x;
            
            for (int i = 0; i < sz; i++)
            {
                x = s[i];
                temp = x.ToString();
                temp = temp.PadLeft(3, '0');
                result += temp;
            }

            return result;
        }
        static public string ConvertToText(string s)
        {
            string result = "";
            int x = 0;
            
            if(s.Length % 3 != 0)
            {
                s = s.PadLeft(s.Length + (3 - s.Length % 3), '0');
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

                result += (char)x;
            }

            return result;
        }

        static private string[] BlocksSplit(string text)
        {
            int blockSize = (n.Length - 1) / 3, rem = 0;

            if (text.Length % blockSize != 0)
                rem = 1;
            
            string[] blocks = new string[text.Length / blockSize + rem];
            string temp = "";

            for(int i = 0; i < text.Length; i ++)
            {
                if(i % blockSize == 0 && i != 0)
                {
                    blocks[i / blockSize - 1] = temp;
                    temp = "";
                }

                temp += text[i];
            }

            if (temp.Length > 0)
                blocks[blocks.Length - 1] = temp;

            return blocks;
        }

        static private void ConvertNumToBits(BitArray bitArray, int s, string text)
        {
            foreach (var ch in text)
            {
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


        static private BitArray ConvertBlocksToBits(KeyValuePair<string, List<string>> encryption)
        {
            int sz = encryption.Value.Count * 4;

            foreach (var text in encryption.Value)
            {
                sz += text.Length * 4;
            }

            BitArray bitArray = new BitArray(sz);
            sz = 0;

            foreach (var text in encryption.Value)
            {
                ConvertNumToBits(bitArray, sz, text);
                sz += text.Length * 4;

                for (int i = 0; i < 4; i++)
                    bitArray[sz++] = true;
            }

            return bitArray;
        }

        static private string ConvertBitsToNumbers(BitArray bitarray, ref int s)
        {
            string text = "";
            int x = 0, p = 1, i;

            for (i = s; i < bitarray.Count; i++)
            {
                if (i % 4 == 0 && p != 1)
                {
                    if (x == 15)
                        break;

                    text += x;
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


        public static KeyValuePair <string, BitArray> RSAEncryption(string text)
        {
            GeneratePublickKey();
            string privateKey = GeneratePrivateKey();
            string[] blocks = BlocksSplit(text);
            List<string> encryptedTexts = new List<string>();

            for(int i = 0; i < blocks.Length; i ++)
            {
                blocks[i] = ConvertToNumber(blocks[i]);
                encryptedTexts.Add(Div(FastPower(blocks[i], e, n), n).r);
            }

            KeyValuePair<string, List < string> > ret = new KeyValuePair<string, List <string>> (privateKey, encryptedTexts);
            return new KeyValuePair<string, BitArray>(privateKey, ConvertBlocksToBits(ret));
        }

        public static string RSADecryption(BitArray bitArray, string d)
        {
            GeneratePublickKey();

            int sz = 0;
            string decryptedText = "";

            while (sz != bitArray.Length)
            {
                string subText = Div(FastPower(ConvertBitsToNumbers(bitArray, ref sz), d, n), n).r;
                subText = ConvertToText(subText);
                decryptedText += subText;
            }


            return decryptedText;
        }

        private static int GetAsYouCan(long timeStamp)
        {
            long seed = 0;
            int p = 1;

            while(seed + (timeStamp % 10) * p < int.MaxValue)
            {
                seed += (timeStamp % 10) * p;
                timeStamp /= 10;
                p *= 10;
            }

            return Convert.ToInt32(seed);
        }

        public static string RandomValue()
        {
            var timeStamp = new DateTimeOffset(DateTime.UtcNow).ToFileTime();
            int seed = GetAsYouCan(timeStamp);
            Random rand = new Random(seed);
            return rand.Next(2, 1000).ToString();
        }

        public static string GeneratePrivateKey()
        {
            string k = "1"; // (k * phie + 1) % e == 0

            while (RSA.Div(RSA.StringAddation(RSA.Multiply(phi, k), "1"), e).r != "0")// 0000 0000 
            {
                k = RSA.StringAddation(k, "1");
            }

            return RSA.Div(RSA.StringAddation(RSA.Multiply(phi, k), "1"), e).q;
        }

        public static void GeneratePublickKey()
        {
            if (!Generated)
            {
                string p = "1000000007", q = "20988936657440586486151264256610222593863921"; // function tgbln el arkam el prime must be not equal
                n = RSA.Multiply(p, q);
                phi = RSA.Multiply(RSA.StringSubtraction(p, "1"), RSA.StringSubtraction(q, "1"));
                Generated = true;
            }

            e = RandomValue(); // coprime to phi

            while (RSA.GCD(e, phi) != "1")
            {
                e = RSA.StringAddation(e, "1");
            }

        }

        public static void Test()
        {
            FileStream input = new FileStream("C:\\Users\\Ahmed\\Downloads\\[MS2 Tests] RSA\\Complete Test\\TestRSA.txt", FileMode.OpenOrCreate, FileAccess.Read);
            FileStream output = new FileStream("C:\\Users\\Ahmed\\Downloads\\[MS2 Tests] RSA\\Complete Test\\output.txt", FileMode.Create, FileAccess.Write);
            StreamReader sr = new StreamReader(input);
            StreamWriter sw = new StreamWriter(output);
            int n = Convert.ToInt32(sr.ReadLine());
            string x, M, N, e;
            
            while(n -- > 0)
            {
                N = sr.ReadLine();
                e = sr.ReadLine();
                M = sr.ReadLine();
                x = sr.ReadLine();
                /*
                if (x == "0")
                    x = RSA.RSAEncryption(M, e, N);
                else
                    x = RSA.RSADecryption(M, e, N);
                */
                Console.WriteLine("m: " + M.Length);
                Console.WriteLine("n: " + N.Length);
                Console.WriteLine("e: " + e.Length);

                sw.WriteLine(x);
            }
            
            sr.Close();
            sw.Close();
            output.Close();
            input.Close();
        }
    }
}
