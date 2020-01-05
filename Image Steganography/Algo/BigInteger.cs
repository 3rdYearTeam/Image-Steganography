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
            public String q, r; //O(1)
        }

        private static readonly String one = new String("1"); //O(1)
        private static String zero = new String("0"); //O(1)

        public static String FastMultiply(String a, String b) //O(NLogN)
        {
            List<int> l1 = new List<int>(); //O(1)
            List<int> l2 = new List<int>(); //O(1)
            BigInteger.ConvertToList(a, ref l1); //O(N)
            BigInteger.ConvertToList(b, ref l2); //O(N)
            var l = BigInteger.FFtmultiplication(l1, l2); //O(NLogN)
            BigInteger.TzbeetElAnswer(ref l);//O(N)
            String result = new String(l.Count);//O(N)

            foreach (var digit in l)//O(N)
                result.PushBack(digit.ToString()); // O(1);

            return result; //O(!)
        }

        static void FFT(ref List<Complex> L, bool invert)// //O(NlogN)
        {
            int sz = L.Count;//O(1)

            if (sz == 1)//O(1)
                return;//O(1)

            List<Complex> evenList = new List<Complex>();//O(1)
            List<Complex> oddList = new List<Complex>();//O(1)
            //O(N)
            for (int i = 0; i * 2 < sz; i++)//O(1)
            {
                evenList.Add(L[2 * i]);//O(1)
                oddList.Add(L[2 * i + 1]);//O(1)
            }
            
            FFT(ref evenList, invert);// T(N) = 2T(N / 2) + O(N)
            FFT(ref oddList, invert);// T(N) = 2T(N / 2) + O(N)
            double ang = 2 * Math.PI / sz * (invert ? -1 : 1);//O(1)
            Complex w = 1;//O(1)
            Complex wn = new Complex(Math.Cos(ang), Math.Sin(ang));//O(1)
            //O(N)
            for (int i = 0; i * 2 < sz; i++)//O(1)
            {
                L[i] = evenList[i] + w * oddList[i];//O(1)
                L[i + sz / 2] = evenList[i] - w * oddList[i];//O(1)

                if (invert)//O(1)
                {
                    L[i] /= 2;//O(1)
                    L[i + sz / 2] /= 2;//O(1)
                }

                w *= wn;//O(1)
            }
        }

        static void MakeLengthPowerOfTwo(ref int len, ref List<int> firstNumber, ref List<int> secondNumber, ref List<Complex> fftFirst, ref List<Complex> fftSecond) //O(N)
        {
            // O(N)
            while (len < firstNumber.Count + secondNumber.Count)// O(1)
            {
                len <<= 1;// O(1)
            }
            // O(N)
            for (int i = 0; i < firstNumber.Count; i++)// O(1)
            {
                fftFirst.Add(firstNumber[i]);// O(1)
            }
            // O(N) 
            for (int i = firstNumber.Count; i < len; i++)// O(1)
            {
                fftFirst.Add(0);// O(1)
            }
            // O(N)           
            for (int i = 0; i < secondNumber.Count; i++)// O(1)
            {
                fftSecond.Add(secondNumber[i]);// O(1)
            }
            // O(N)
            for (int i = secondNumber.Count; i < len; i++)// O(1)
            {
                fftSecond.Add(0);// O(1)
            }

        }
        public static List<int> FFtmultiplication(List<int> firstNumber, List<int> secondNumber) // O(NlogN)
        {
            List<Complex> fftFirst = new List<Complex>(); // O(1)
            List<Complex> fftSecond = new List<Complex>(); // O(1)
            int len = 1;
            MakeLengthPowerOfTwo(ref len, ref firstNumber, ref secondNumber, ref fftFirst, ref fftSecond); // O(N)

            FFT(ref fftFirst, false); // O(NlogN)
            FFT(ref fftSecond, false);// O(Nlogn)
            // O(N)
            for (int i = 0; i < len; i++)// O(1)
            {
                fftFirst[i] *= fftSecond[i];// O(1)
            }
            
            FFT(ref fftFirst, true);// O(NlgoN)
            List<int> ret = new List<int>();// O(1)
            // O(N)
            for (int i = 0; i < len; i++)// O(1)
            {
                ret.Add((int)Math.Round(fftFirst[i].Real));// O(1)
            }
            
            return ret;// O(1)
        }
        public static void ConvertToList(String s, ref List<int> l)// O(N)
        {
            // O(N)
            for (int i = s.Size() - 1; i >= 0; i--)// O(1)
            {
                l.Add(s[i] - '0');// O(1)
            }
        }

        public static void TzbeetElAnswer(ref List<int> ans)// O(N)
        {
            int carry = 0;// O(1)
            List<int> ret = new List<int>();// O(1)
            // O(N)
            for (int i = 0; i < ans.Count; i++)// O(1)
            {
                ans[i] += carry;// O(1)
                carry = ans[i] / 10;// O(1)
                ans[i] %= 10;// O(1)
            }
            
            bool ok = false;// O(1)
            // O(N)
            for (int i = ans.Count - 1; i >= 0; i--)// O(1)
            {
                if (!ok && ans[i] != 0)// O(1)
                {
                    ok = true;// O(1)
                }

                if (ok)// O(1)
                    ret.Add(ans[i]);// O(1)
            }

            ans = ret;// O(1)
        }

        public static String MultiplyByTwo(String x)// O(N)
        {
            String result = new String(x.Size() + 2, true);// O(N)
            int carry = 0;// O(1)
            // O(N)
            for (int i = x.Size() - 1; i >= 0; i--)// O(1)
            {
                result.PushFront(((((x[i] - '0') * 2) + carry) % 10).ToString());// O(1)
                carry = ((x[i] - '0') * 2) / 10;// O(1)
            }

            if (carry > 0)// O(1)
            {
                result.PushFront(carry.ToString());// O(1)
            }

            return result;// O(1)
        }

        public static String Multiply(String first, String second)// O(N^1.585)
        {
            if (first.Size() != second.Size())// O(1)
                MakeLengthEqual(ref first, ref second);// O(N)

            if (first.Size() == 1 || second.Size() == 1)// O(1)
            {
                String ans = new String((long.Parse(first.ToString()) * long.Parse(second.ToString())).ToString());// O(1)
                return ans;// O(1)
            }

            if(first.Size() % 2 == 1)// O(1)
            {
                first.PushFront('0');// O(1)
                second.PushFront('0');// O(1)
            }

            int cutPos = GetPostion(ref first);// O(1)
            String a = GetFirstPart(first, cutPos);// O(N)
            String b = GetSecondPart(first, cutPos);// O(N)
            String c = GetFirstPart(second, cutPos);// O(N)
            String d = GetSecondPart(second, cutPos);// O(N)


            String ac = Multiply(a, c); // T(N) = 3T(N/2) + O(N)
            String bd = Multiply(b, d);// T(N) = 3T(N/2) + O(N)
            String ab_cd = Multiply(StringAddation(a, b), StringAddation(c, d));// T(N) = 3T(N/2) + O(N)


            return CalculateAnswer(ref ac, ref bd, ref ab_cd, b.Size() + d.Size()); // O(N)
        }

        public static String PadRight(String s, int n)
        {
            // O(N)
            while (n-- > 0) // O(1)
            {
                s.PushBack('0'); // O(1)
            }
            
            return s; // O(1)
        }

        public static String PadLeft(String s, int n) // O(1)
        {
            // O(N)
            while (n-- > 0) // O(1)
            {
                s.PushFront('0'); // O(1)
            }

            return s; // O(1)
        }

        private static String CalculateAnswer(ref String ac, ref String bd, ref String ab_cd, int padding)
        {
            String t = StringSubtraction(StringSubtraction(ab_cd, ac), bd);// O(N)
            String tt = PadRight(t, padding / 2);// O(N)
            String ttt = PadRight(ac, padding);// O(N)

            return StringAddation(StringAddation(tt, ttt), bd);// O(N)
        }

        private static String GetFirstPart(String str, int cutPos)// O(N)
        {
            String ret = new String(); // O(1)
            // O(N)
            for (int i = 0; i < cutPos; i++)// O(1)
                ret.PushBack(str[i]);// O(1)

            return ret;// O(1)
        }

        private static String GetSecondPart(String str, int cutPos)// O(N)
        {
            String ret = new String();// O(1)
            // O(N)
            for (int i = cutPos; i < str.Size(); i++)// O(1)
            {
                ret.PushBack(str[i]);// O(1)
            }

            return ret;// O(1)
        }

        private static int GetPostion(ref String first)// O(1)
        {
            return (first.Size() + 1) / 2;// O(1)
        }

        public static String StringAddation(String a, String b)// O(N)
        {
            String result = new String(Math.Max(a.Size(), b.Size()) + 2);// O(N)
            int j = b.Size() -1 , i = a.Size() - 1;// O(1)
            int carry = 0, res;// O(1)
            // O(N)
            while (j >= 0 && i >= 0)// O(1)
            {
                int n1 = a[i] - '0';// O(1)
                int n2 = b[j] - '0';// O(1)
                res = (n1 + n2 + carry) % 10;// O(1)
                carry = (n1 + n2 + carry) / 10;// O(1)
                result.PushFront(res.ToString());// O(1)
                i--; j--;// O(1)
            }
            // O(N)
            while (i >= 0)// O(1)
            {
                int n1 = a[i] - '0';// O(1)
                res = (n1 + carry) % 10;// O(1)
                carry = (n1 + carry) / 10;// O(1)
                result.PushFront(res.ToString());// O(1)
                i--;// O(1)
            }
            // O(N)
            while (j >= 0)// O(1)
            {
                int n2 = b[j] - '0';// O(1)
                res = (n2 + carry) % 10;// O(1)
                carry = (n2 + carry) / 10;// O(1)
                result.PushFront(res.ToString());// O(1)
                j--;// O(1)
            }

            if (carry > 0)// O(1)
                result.PushFront(carry.ToString());// O(1)

            return SanitizeResult(ref result);// O(N)
        }

        public static String GCD(String a, String b) // O(log(A * B) * NLogN)
        {
            if (b.Equals(zero)) //O(1)
                return a.Clone(); //O(N)

            return GCD(b, Div(a, b.Clone()).r);  
        }

        public static String StringSubtraction(String a, String b)// O(N)
        {

            /*if (StringIsSmaller(ref a, ref b)) // O(N)
            {
                Swap(ref a, ref b); // O(1)
            }*/

            String result = new String(Math.Max(a.Size(), b.Size()) + 1, true);// O(N)
            int i = a.Size() - 1, j = b.Size() - 1;// O(1)
            int n;// O(1)
            // O(N)
            while (j >= 0)// O(1)
            {
                n = a[i] - b[j]; // O(1)

                if (n >= 0)// O(1)
                {
                    result.PushFront(n.ToString());// O(1)
                    i--; j--;// O(1)
                }
                else
                {
                    n += 10;// O(1)
                    result.PushFront(n.ToString());// O(1)
                    i--; j--;// O(1)
                    // O(N)
                    while (j >= 0 && a[i] - 1 < b[j])// O(1)
                    {
                        n = a[i] - b[j] + 9; // 10 - 1
                        result.PushFront(n.ToString());// O(1)
                        i--; j--;// O(1)
                    }
                    
                    a[i]--;// O(1)
                }
            }
            // O(N)
            while (i >= 0) // O(1)
                result.PushFront(a[i--]); // O(1)

            result = SanitizeResult(ref result);// O(N)
            return result;// O(1)
        }

        private static bool StringIsSmaller(ref String a, ref String b)// O(N)
        {
            if (a.Size() < b.Size())// O(1)
                return true;// O(1)
            if (a.Size() > b.Size())// O(1)
                return false;// O(1)
            // O(N)
            for (int i = 0; i < a.Size(); i++)// O(1)
            {
                if (a[i] < b[i])// O(1)
                    return true;// O(1)
                if (a[i] > b[i])// O(1)
                    return false;// O(1)
            }

            return false;// O(1)
        }

        private static void Swap(ref String a, ref String b)// O(1)
        {
            String temp = a;// O(1)
            a = b;// O(1)
            b = temp;// O(1)
        }

        private static String RemoveZero(String str)// O(N)
        {
            // O(N)
            while (str[0] == '0')// O(1)
                str.PopFront();// O(1)

            return str;// O(1)
        }

        private static String SanitizeResult(ref String result)// O(N)
        {
            result = RemoveZero(result);// O(1)

            if (result.Size() == 0)// O(1)
                result.PushBack("0");// O(1)

            return result;// O(1)
        }

        private static void MakeLengthEqual(ref String x, ref String y)// O(N)
        {
            if (x.Size() == y.Size())// O(1)
                return;// O(1)

            if (x.Size() > y.Size())// O(1)
            {
                int n = x.Size() - y.Size();// O(1)
                // O(N)
                for (int i = 0; i < n; i++)// O(1)
                {
                    y.PushFront('0');// O(1)
                }

                return;// O(1)
            }
            // O(1)
            if (y.Size() > x.Size())
            {
                int n = y.Size() - x.Size();// O(1)
                // O(N)
                for (int i = 0; i < n; i++)// O(1)
                {
                    x.PushFront('0');// O(1)
                }

                return;// O(1)
            }
        }

        public static String DivByTwo(String x)// O(NlogN)
        {
            String result = new String(x.Size());// O(1)
            int last = 0;// O(1)

            if (x[0] > '0')// O(1)
            {
                if ((x[0] - '0') % 2 != 0)// O(1)
                    last = 5;// O(1)

                if (x[0] > '1')// O(1)
                    result.PushBack(((x[0] - '0') / 2).ToString());// O(1)
            }
            // O(N)
            for (int i = 1; i < x.Size(); i++)// O(1)
            {
                result.PushBack((((x[i] - '0') / 2 + last)).ToString());// O(1)

                if ((x[i] - '0') % 2 != 0)// O(1)
                    last = 5;// O(1)
                else// O(1)
                    last = 0;// O(1)
            }

            if (result.Size() == 0)// O(1)
                result.PushBack("0");// O(1)

            return result;// O(1)
        }

        private static String FastMod(String a, String mod)// O(N^2)
        {    
            
            String ret = new String(mod.Size() + 2);// O(N)
            ret.PushBack("0");// O(1)
            // O(N^2)
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

                if(!StringIsSmaller(ref ret, ref mod))// O(N)
                    ret.Assign(Div(ret, mod).r); // O(N)
            }

            return ret;// O(1)
        }

        public static Pair Div(String a, String b)// O(N)
        {
            if (StringIsSmaller(ref a, ref b))// O(N)
            {
                Pair p = new Pair()// O(1)
                {
                    q = new String("0"),// O(1)
                    r = a.Clone()// O(1)
                };

                return p;// O(1)
            }

            Pair p2 = Div(a, MultiplyByTwo(b));// T(n) = T(n / 2) + O(N)
            p2.q = MultiplyByTwo(p2.q);// O(N)

            if (StringIsSmaller(ref p2.r, ref b))// O(N)
                return p2;// O(1)

            p2.q = StringAddation(p2.q, one);// O(N)
            p2.r = StringSubtraction(p2.r, b);// O(N)

            return p2;// O(1)
        }

        public static String FastPower(String a, String p, String mod) // O(N * Log n * Log p)
        {
            String ans = new String("1");// O(1)
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

        static bool checkDivisibilityBy13(string num)// O(N)
        {
            int length = num.Length;// O(1)
            if (length == 1 && num[0] == '0')// O(1)
                return true;// O(1)

            if (length % 3 == 1)// O(1)
            {
                num += "00";// O(1)
                length += 2;// O(1)
            }
            else if (length % 3 == 2)// O(1)
            {
                num += ("0");// O(1)
                length += 1;// O(1)
            }
            int sum = 0, p = 1;// O(1)
            // O(N)
            for (int i = length - 1; i >= 0; i--)// O(1)
            {
                int group = 0;// O(1)
                group += num[i--] - '0';// O(1)
                group += (num[i--] - '0') * 10;// O(1)
                group += (num[i] - '0') * 100;// O(1)

                sum = sum + group * p;// O(1)
                p *= (-1);// O(1)
            }
            sum = Math.Abs(sum);// O(1)
            return (sum % 13 == 0);// O(1)
        }

        static bool checkPrimiality(String s)// O(N^2)
        {
            int sz = s.Size();// O(1)
            if (s[sz - 1].Equals(new String("5")))// O(1)
            {
                return false;// O(1)
            }

            int sumOfDigits = 0, s1 = 0, s2 = 0;// O(1)
            // O(N)
            for (int i = 0; i < sz; i += 2)// O(1)
            {
                sumOfDigits += s[i] - '0';// O(1)
                s1 += s[i] - '0';// O(1)
                if (i + 1 < sz)// O(1)
                {
                    sumOfDigits += s[i + 1] - '0';// O(1)
                    s2 += s[i + 1] - '0';// O(1)
                }
            }

            if (sumOfDigits % 3 == 0)// O(1)
            {
                return false;// O(1)
            }

            if ((((s1 - s2) % 11) + 11) % 11 == 0)// O(1)
            {
                return false;// O(1)
            }

            String s7 = new String(s.ToString());// O(N)
            // O(N^2)
            while (s7.Size() > 2)// O(1)
            {
                int x = s7[s7.Size() - 1] - '0';// O(1)
                x *= 2;// O(1)
                String lastDigit = new String(x.ToString());// O(1)
                s7.PopBack();// O(1)
                s7 = StringSubtraction(s7, lastDigit);// O(N)
            }
            if (int.Parse(s7.ToString()) % 7 == 0)// O(1)
                return false;// O(1)
            if (checkDivisibilityBy13(s.ToString()))// O(N)
                return false;// O(1)

            Random rnd = new Random();// O(1)
            for (int i = 0; i < 3; i++)// O(1)
            {
                String temp = new String("");// O(1)

                for (int j = 0; j < 3; j++)// O(1)
                    temp.PushBack(rnd.Next(2, int.MaxValue).ToString());// O(1)
                Console.WriteLine(s);// O(1)
                Console.WriteLine(temp);// O(1)

                if (!GCD(temp, s).Equals(one))//O(log(A * B) * NLogN)
                {
                    return false;// O(1)
                }
                if (!FastPower(temp, StringSubtraction(s, one), s).Equals(one))// O(N * LOG N * LOG P)
                {
                    return false;// O(1)
                }
            }
            return true;
        }


        static public KeyValuePair<String, String> GeneratePrime()  //O(N^3)
        {
            String p = new String(""); //O(1)
            
            for (int i = 0; i < 60; i++) //O(1)
                p.PushBack('9'); //O(1)
             //O(N^2)
            while (!checkPrimiality(p)) //O(N^2)
            {
                p = StringAddation(p, new String("2")); //O(1)
            }

            String q = new String(p.ToString()); //O(N)
            p = StringAddation(p, new String("2")); //O(N)
             //O(N^3)
            while (!checkPrimiality(q)) //O(N^2)
            {
                q = StringAddation(q, new String("2"));  //O(N)
            }

            Console.WriteLine(p + "  <---->  " + q);
            return new KeyValuePair<String, String>(p, q); //O(1)
        }



    }
}
