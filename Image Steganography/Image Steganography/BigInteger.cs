using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Diagnostics;

namespace Image_Steganography
{
    class BigInteger
    {
        public class Pair
        {
            public String q, r;
        }

        private static readonly String one = new String("1");
        private static String zero = new String("0");

        public static String FastMultiply(String a, String b)
        {
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            BigInteger.ConvertToList(a, ref l1);
            BigInteger.ConvertToList(b, ref l2);
            var l = BigInteger.FFtmultiplication(l1, l2);
            BigInteger.TzbeetElAnswer(ref l);
            String result = new String(l.Count);

            foreach (var digit in l)
                result.PushBack(digit.ToString());

            return result;
        }

        static void FFT(ref List<Complex> L, bool invert)
        {
            int sz = L.Count;

            if (sz == 1)
                return;
            
            List<Complex> evenList = new List<Complex>();
            List<Complex> oddList = new List<Complex>();
            
            for (int i = 0; i * 2 < sz; i++)
            {
                evenList.Add(L[2 * i]);
                oddList.Add(L[2 * i + 1]);
            }
            
            FFT(ref evenList, invert);
            FFT(ref oddList, invert);
            double ang = 2 * Math.PI / sz * (invert ? -1 : 1);
            Complex w = 1;
            Complex wn = new Complex(Math.Cos(ang), Math.Sin(ang));
            
            for (int i = 0; i * 2 < sz; i++)
            {
                L[i] = evenList[i] + w * oddList[i];
                L[i + sz / 2] = evenList[i] - w * oddList[i];
                
                if (invert)
                {
                    L[i] /= 2;
                    L[i + sz / 2] /= 2;
                }

                w *= wn;
            }
        }

        static void MakeLengthPowerOfTwo(ref int len, ref List<int> firstNumber, ref List<int> secondNumber, ref List<Complex> fftFirst, ref List<Complex> fftSecond)
        {
            while (len < firstNumber.Count + secondNumber.Count)
            {
                len <<= 1;
            }

            for (int i = 0; i < firstNumber.Count; i++)
            {
                fftFirst.Add(firstNumber[i]);
            }
            
            for (int i = firstNumber.Count; i < len; i++)
            {
                fftFirst.Add(0);
            }
            
            for (int i = 0; i < secondNumber.Count; i++)
            {
                fftSecond.Add(secondNumber[i]);
            }
            
            for (int i = secondNumber.Count; i < len; i++)
            {
                fftSecond.Add(0);
            }

        }
        public static List<int> FFtmultiplication(List<int> firstNumber, List<int> secondNumber)
        {
            List<Complex> fftFirst = new List<Complex>();
            List<Complex> fftSecond = new List<Complex>();
            int len = 1;
            MakeLengthPowerOfTwo(ref len, ref firstNumber, ref secondNumber, ref fftFirst, ref fftSecond);

            FFT(ref fftFirst, false);
            FFT(ref fftSecond, false);
            
            for (int i = 0; i < len; i++)
            {
                fftFirst[i] *= fftSecond[i];
            }
            
            FFT(ref fftFirst, true);
            List<int> ret = new List<int>();
            
            for (int i = 0; i < len; i++)
            {
                ret.Add((int)Math.Round(fftFirst[i].Real));
            }
            
            return ret;
        }
        public static void ConvertToList(String s, ref List<int> l)
        {
            for (int i = s.Size() - 1; i >= 0; i--)
            {
                l.Add(s[i] - '0');
            }
        }

        public static void TzbeetElAnswer(ref List<int> ans)
        {
            int carry = 0;
            List<int> ret = new List<int>();
            
            for (int i = 0; i < ans.Count; i++)
            {
                ans[i] += carry;
                carry = ans[i] / 10;
                ans[i] %= 10;
            }
            
            bool ok = false;
            
            for (int i = ans.Count - 1; i >= 0; i--)
            {
                if (!ok && ans[i] != 0)
                {
                    ok = true;
                }
                if (ok)
                    ret.Add(ans[i]);
            }

            ans = ret;
        }

        public static String MultiplyByTwo(String x)
        {
            String result = new String(x.Size() + 2, true);
            int carry = 0;

            for (int i = x.Size() - 1; i >= 0; i--)
            {
                result.PushFront(((((x[i] - '0') * 2) + carry) % 10).ToString());
                carry = ((x[i] - '0') * 2) / 10;
            }

            if (carry > 0)
            {
                result.PushFront(carry.ToString());
            }

            return result;
        }

        public static String Multiply(String first, String second)
        {
            if (first.Size() != second.Size())
                MakeLengthEqual(ref first, ref second);
            
            if (first.Size() == 1 || second.Size() == 1)
            {
                String ans = new String((long.Parse(first.ToString()) * long.Parse(second.ToString())).ToString());
                return ans;
            }

            if(first.Size() % 2 == 1)
            {
                first.PushFront('0');
                second.PushFront('0');
            }

            int cutPos = GetPostion(ref first);
            String a = GetFirstPart(first, cutPos);
            String b = GetSecondPart(first, cutPos);
            String c = GetFirstPart(second, cutPos);
            String d = GetSecondPart(second, cutPos);


            String ac = Multiply(a, c);
            String bd = Multiply(b, d);
            String ab_cd = Multiply(StringAddation(a, b), StringAddation(c, d));


            return CalculateAnswer(ref ac, ref bd, ref ab_cd, b.Size() + d.Size());
        }

        public static String PadRight(String s, int n)
        {
            while (n-- > 0)
            {
                s.PushBack('0');
            }
            
            return s;
        }

        public static String PadLeft(String s, int n)
        {
            while (n-- > 0)
            {
                s.PushFront('0');
            }

            return s;
        }

        private static String CalculateAnswer(ref String ac, ref String bd, ref String ab_cd, int padding)
        {
            String t = StringSubtraction(StringSubtraction(ab_cd, ac), bd);
            String tt = PadRight(t, padding / 2);
            String ttt = PadRight(ac, padding);

            return StringAddation(StringAddation(tt, ttt), bd);
        }

        private static String GetFirstPart(String str, int cutPos)
        {
            String ret = new String();

            for (int i = 0; i < cutPos; i++)
                ret.PushBack(str[i]);
            
            return ret;
        }

        private static String GetSecondPart(String str, int cutPos)
        {
            String ret = new String();

            for (int i = cutPos; i < str.Size(); i++)
            {
                ret.PushBack(str[i]);
            }

            return ret;
        }

        private static int GetPostion(ref String first)
        {
            return (first.Size() + 1) / 2;
        }

        public static String StringAddation(String a, String b)
        {
            String result = new String(Math.Max(a.Size(), b.Size()) + 2);
            int j = b.Size() -1 , i = a.Size() - 1;
            int carry = 0, res;

            while (j >= 0 && i >= 0)
            {
                int n1 = a[i] - '0';
                int n2 = b[j] - '0';
                res = (n1 + n2 + carry) % 10;
                carry = (n1 + n2 + carry) / 10;
                result.PushFront(res.ToString());
                i--; j--;
            }

            while(i >= 0)
            {
                int n1 = a[i] - '0';
                res = (n1 + carry) % 10;
                carry = (n1 + carry) / 10;
                result.PushFront(res.ToString());
                i--;
            }

            while (j >= 0)
            {
                int n2 = b[j] - '0';
                res = (n2 + carry) % 10;
                carry = (n2 + carry) / 10;
                result.PushFront(res.ToString());
                j--;
            }

            if (carry > 0)
                result.PushFront(carry.ToString());

            return SanitizeResult(ref result);
        }

        public static String GCD(String a, String b)
        {
            if (b.Equals(zero))
                return a.Clone();

            return GCD(b, Div(a, b.Clone()).r);
        }

        public static String StringSubtraction(String a, String b)
        {

            /*if (StringIsSmaller(ref a, ref b)) // O(N)
            {
                Swap(ref a, ref b); // O(1)
            }*/

            String result = new String(Math.Max(a.Size(), b.Size()) + 1, true);
            int i = a.Size() - 1, j = b.Size() - 1;
            int n;

            while(j >= 0)
            {
                n = a[i] - b[j]; 
                
                if (n >= 0)
                {
                    result.PushFront(n.ToString());
                    i--; j--;
                }
                else
                {
                    n += 10;
                    result.PushFront(n.ToString());
                    i--; j--;

                    while (j >= 0 && a[i] - 1 < b[j])
                    {
                        n = a[i] - b[j] + 9; // 10 - 1
                        result.PushFront(n.ToString());
                        i--; j--;
                    }
                    
                    a[i]--;
                }
            }

            while(i >= 0)
                result.PushFront(a[i--]);

            result = SanitizeResult(ref result);
            return result;
        }

        private static bool StringIsSmaller(ref String a, ref String b)
        {
            if (a.Size() < b.Size())
                return true;
            if (a.Size() > b.Size())
                return false;

            for (int i = 0; i < a.Size(); i++)
            {
                if (a[i] < b[i])
                    return true;
                if (a[i] > b[i])
                    return false;
            }

            return false;
        }

        private static void Swap(ref String a, ref String b)
        {
            String temp = a;
            a = b;
            b = temp;
        }

        private static String RemoveZero(String str)
        {
            while (str[0] == '0')
                str.PopFront();

            return str;
        }

        private static String SanitizeResult(ref String result)
        {
            result = RemoveZero(result);

            if (result.Size() == 0)
                result.PushBack("0");

            return result;
        }

        private static void MakeLengthEqual(ref String x, ref String y)
        {
            if (x.Size() == y.Size())
                return;

            if (x.Size() > y.Size())
            {
                int n = x.Size() - y.Size();
                
                for (int i = 0; i < n; i++)
                {
                    y.PushFront('0');
                }

                return;
            }

            if (y.Size() > x.Size())
            {
                int n = y.Size() - x.Size();

                for (int i = 0; i < n; i++)
                {
                    x.PushFront('0');
                }

                return;
            }
        }

        public static String DivByTwo(String x)
        {
            String result = new String(x.Size());
            int last = 0;

            if (x[0] > '0')
            {
                if ((x[0] - '0') % 2 != 0)
                    last = 5;

                if (x[0] > '1')
                    result.PushBack(((x[0] - '0') / 2).ToString());
            }

            for (int i = 1; i < x.Size(); i++)
            {
                result.PushBack((((x[i] - '0') / 2 + last)).ToString());

                if ((x[i] - '0') % 2 != 0)
                    last = 5;
                else
                    last = 0;
            }

            if (result.Size() == 0)
                result.PushBack("0");

            return result;
        }

        private static String FastMod(String a, String mod)
        {    
            
            String ret = new String(mod.Size() + 2);
            ret.PushBack("0");

            for (int i = 0; i < a.Size(); i++) // O(N)
            {
                if (ret[0] != '0') // O(1)
                {
                    ret.PushBack(a[i]); // O(1)
                }
                else
                {
                    ret[0] = a[i]; // O(1)
                }

                if(!StringIsSmaller(ref ret, ref mod))
                    ret.Assign(Div(ret, mod.Clone()).r); // O(1)
            }

            return ret;
        }

        public static Pair Div(String a, String b)
        {
            if (StringIsSmaller(ref a, ref b))
            {
                Pair p = new Pair()
                {
                    q = new String("0"),
                    r = a.Clone()
                };

                return p;
            }

            Pair p2 = Div(a, MultiplyByTwo(b));
            p2.q = MultiplyByTwo(p2.q);

            if (StringIsSmaller(ref p2.r, ref b))
                return p2;

            p2.q = StringAddation(p2.q, one);
            p2.r = StringSubtraction(p2.r, b);
         
            return p2;
        }

        public static String FastPower(String a, String p, String mod)
        {
            String ans = new String("1");
            // O(N * Log n * Log p) // 300 * 1024 * 1024
            while (StringIsSmaller(ref zero, ref p))  // O(1)
            {
                if (((p[p.Size() - 1] - '0') & 1) == 1) // O(1)
                {   
                    ans = FastMultiply(ans, a); // O(NlogN)

                    if (StringIsSmaller(ref mod, ref ans)) // O(N)
                        ans = FastMod(ans, mod);  // O(N)
                }

                a = FastMultiply(a, a); // Nlog(N)
                p = DivByTwo(p); // O(N)

                if (StringIsSmaller(ref mod, ref a)) // O(n)
                {
                    a = FastMod(a, mod); // O(N)
                }
            }

            return ans;
        }

    }
}
