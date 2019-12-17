using System;
using System.Text;

namespace Image_Steganography
{
    class BigInteger
    {
        private static readonly StringBuilder one = new StringBuilder("1");
        private static StringBuilder zero = new StringBuilder("0");
        
        public static StringBuilder MultiplyByTwo(StringBuilder x)
        {
            StringBuilder result = new StringBuilder("");
            int carry = 0;

            for (int i = x.Length - 1; i >= 0; i--)
            {
                StringBuilder temp = new StringBuilder(((((x[i] - '0') * 2) + carry) % 10).ToString());
                result = temp.Append(result);
                carry = ((x[i] - '0') * 2) / 10;
            }

            if (carry > 0)
            {
                StringBuilder temp = new StringBuilder(carry.ToString());
                result = temp.Append(result);
            }
            return result;
        }

        public static StringBuilder Multiply(StringBuilder first, StringBuilder second)
        {
            if (first.Length != second.Length)
                MakeLengthEqual(ref first, ref second);

            if (first.Length == 1 || second.Length == 1)
            {
                StringBuilder ans = new StringBuilder((long.Parse(first.ToString()) * long.Parse(second.ToString())).ToString());
                return ans;
            }

            int cutPos = GetPostion(ref first);
            StringBuilder a = GetFirstPart(first, cutPos);
            StringBuilder b = GetSecondPart(first, cutPos);
            StringBuilder c = GetFirstPart(second, cutPos);
            StringBuilder d = GetSecondPart(second, cutPos);

            StringBuilder ac = Multiply(a, c);
            StringBuilder bd = Multiply(b, d);
            StringBuilder ab_cd = Multiply(StringAddation(a, b), StringAddation(c, d));

            return CalculateAnswer(ref ac, ref bd, ref ab_cd, b.Length + d.Length);
        }

        public static StringBuilder PadRight(StringBuilder s, int n)
        {
            while (n > 0)
            {
                n--;
                s.Append('0');
            }
            
            return s;
        }

        public static StringBuilder PadLeft(StringBuilder s, int n)
        {
            StringBuilder ret = new StringBuilder("");

            while (n > 0)
            {
                n--;
                ret.Append('0');
            }

            ret.Append(s);
            return ret;
        }

        private static StringBuilder CalculateAnswer(ref StringBuilder ac, ref StringBuilder bd, ref StringBuilder ab_cd, int padding)
        {
            StringBuilder t = StringSubtraction(StringSubtraction(ab_cd, ac), bd);
            StringBuilder tt = PadRight(t, padding / 2);
            StringBuilder ttt = PadRight(ac, padding);

            return StringAddation(StringAddation(tt, ttt), bd);
        }

        private static StringBuilder GetFirstPart(StringBuilder str, int cutPos)
        {
            StringBuilder ret = new StringBuilder("");
            for (int i = 0; i < cutPos; i++)
                ret.Append(str[i]);
            return ret;
        }

        private static StringBuilder GetSecondPart(StringBuilder str, int cutPos)
        {
            StringBuilder ret = new StringBuilder("");
            for (int i = cutPos; i < str.Length; i++)
            {
                ret.Append(str[i]);
            }
            return ret;
        }

        private static int GetPostion(ref StringBuilder first)
        {
            return (first.Length + 1) / 2;
        }

        public static StringBuilder StringAddation(StringBuilder a, StringBuilder b)
        {
            StringBuilder result = new StringBuilder("");

            if (a.Length > b.Length)
            {
                Swap(ref a, ref b);
            }

            MakeLengthEqual(ref a, ref b);
            int length = a.Length;
            int carry = 0, res;

            for (int i = length - 1; i >= 0; i--)
            {
                int n1 = int.Parse(a[i].ToString());
                int n2 = int.Parse(b[i].ToString());
                res = (n1 + n2 + carry) % 10;
                carry = (n1 + n2 + carry) / 10;
                StringBuilder temp = new StringBuilder(res.ToString());
                result = temp.Append(result);
            }

            if (carry != 0)
            {
                StringBuilder temp = new StringBuilder(carry.ToString());
                result = temp.Append(result);
            }

            return SanitizeResult(ref result);
        }

        public static StringBuilder GCD(StringBuilder a, StringBuilder b)
        {
            if (b.Equals(zero))
                return a;

            return GCD(b, Div(a, b).r);
        }


        public static StringBuilder StringSubtraction(StringBuilder a, StringBuilder b)
        {
            bool resultNegative = false;
            StringBuilder result = new StringBuilder("");

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
                int n1 = int.Parse(a[i].ToString());
                int n2 = int.Parse(b[i].ToString());

                if (n1 - carry < n2)
                {
                    n1 = n1 + 10;
                    nextCarry = true;
                }
                res = (n1 - n2 - carry);
                StringBuilder temp = new StringBuilder(res.ToString());
                result = temp.Append(result);
                if (nextCarry)
                    carry = 1;
                else
                    carry = 0;
            }

            result = SanitizeResult(ref result);
            return result;
        }

        private static bool StringIsSmaller(ref StringBuilder a, ref StringBuilder b)
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

        private static void Swap(ref StringBuilder a, ref StringBuilder b)
        {
            StringBuilder temp = a;
            a = b;
            b = temp;
        }

        private static StringBuilder RemoveZero(StringBuilder s)
        {
            StringBuilder ret = new StringBuilder("");
            int sz = s.Length;
            Boolean ok = false;

            for (int i = 0; i < sz; i++)
            {
                if (s[i] != '0')
                {
                    ok = true;
                }
                if (ok)
                    ret.Append(s[i]);
            }

            return ret;
        }

        private static StringBuilder SanitizeResult(ref StringBuilder result)
        {
            result = RemoveZero(result);

            if (result.Length == 0)
                result.Append("0");

            return result;
        }

        private static void MakeLengthEqual(ref StringBuilder x, ref StringBuilder y)
        {
            if (x.Length == y.Length)
                return;

            if (x.Length > y.Length)
            {
                int n = x.Length - y.Length;
                StringBuilder temp = new StringBuilder("");
                for (int i = 0; i < n; i++)
                {
                    temp.Append('0');
                }
                y = temp.Append(y);
                return;
            }

            if (y.Length > x.Length)
            {
                int n = y.Length - x.Length;
                StringBuilder temp = new StringBuilder("");
                for (int i = 0; i < n; i++)
                {
                    temp.Append('0');
                }
                x = temp.Append(x);
                return;
            }
        }

        public class Pair
        {
            public StringBuilder q, r;
        }

        public static StringBuilder DivByTwo(StringBuilder x)
        {
            StringBuilder result = new StringBuilder("");
            int last = 0;

            if (x[0] > '0')
            {
                if ((x[0] - '0') % 2 != 0)
                    last = 5;

                if (x[0] > '1')
                    result.Append(((x[0] - '0') / 2).ToString());
            }

            for (int i = 1; i < x.Length; i++)
            {
                result.Append((((x[i] - '0') / 2 + last)).ToString());

                if ((x[i] - '0') % 2 != 0)
                    last = 5;
                else
                    last = 0;
            }

            if (result.Length == 0)
                result.Append("0");

            return result;
        }

        public static Pair Div(StringBuilder a, StringBuilder b)
        {
            if (StringIsSmaller(ref a, ref b))
            {
                Pair p = new Pair()
                {
                    q = new StringBuilder("0"),
                    r = a
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

        public static StringBuilder FastPower(StringBuilder a, StringBuilder p, StringBuilder mod)
        {
            StringBuilder ans = new StringBuilder("1");

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

                if (StringIsSmaller(ref mod, ref a))
                    a = Div(a, mod).r;
            }

            return ans;
        }

    }
}
