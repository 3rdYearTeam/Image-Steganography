using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography
{
    class String
    {
        private const int defaultSize = 100;
        private const int frontDefaultSize = 50;
        private char[] ch;
        private char[] frontCh;
        private int size = 0, frontSize = 0;

        public String()
        {
            ch = new char[defaultSize];// O(1)
            frontCh = new char[frontDefaultSize];// O(1)
            this.size = 0;// O(1)
            this.frontSize = 0;// O(1)
        }

        public String(int size, bool frontSize = false)
        {
            if(frontSize)// O(1)
            {
                ch = new char[frontDefaultSize];// O(1)
                frontCh = new char[size];// O(1)
            }
            else
            {
                ch = new char[size];// O(1)
                frontCh = new char[frontDefaultSize];// O(1)
            }

            this.size = 0;// O(1)
            this.frontSize = 0;// O(1)
        }

        public String(string str)
        {
            ch = new char[str.Length];// O(N)
            frontCh = new char[frontDefaultSize];// O(1)
            this.frontSize = 0;// O(1)
            // O(N)
            for (int i = 0; i < str.Length; i++)// O(1)
            {
                ch[size++] = str[i];// O(1)
            }

        }


        public String(char []ch, bool copy = true)
        {
            frontCh = new char[frontDefaultSize];// O(1)v
            this.frontSize = 0;// O(1)

            if (copy)// O(1)
            {
                this.ch = new char[ch.Length];// O(1)

                for (int i = 0; i < ch.Length; i++)// O(1)
                {
                    this.ch[i] = ch[i];// O(1)
                }
            }
            else
            {
                this.ch = ch;// O(1)
            }

            size = this.ch.Length;// O(1)
        }
        public void Assign(String str)// O(N)
        {
            if(ch.Length < str.Size())// O(1)
            {
                ch = Expand(ch, str.Size());// O(N)
            }
              
            size = 0;// O(1)
            // O(N)
            for (int i = 0; i < str.Size(); i++)// O(q)
            {
                ch[size++] = str[i];// O(1)
            }

        }

        public int Size()// O(1)
        {
            return frontSize + size;// O(1)
        }

        public bool Equals(String str)// O(N)
        {
            bool ok = (str.Size() == this.Size());// O(1)
            // O(N)
            for (int i = 0; i < str.Size() && ok; i ++)// O(1)
            {
                ok &= (str[i] == this[i]);// O(1)
            }

            return ok;// O(1)
        }

        private char [] Expand(char[] ch, int newSize, bool reverse = false)// O(N)
        {
            newSize = (newSize == 0 ? defaultSize : newSize);// O(1)
            char[] temp = new char[newSize]; // +// O(N)

            if (reverse)// O(1)
            {
                for (int i = 0; i < frontSize; i++)// O(1)
                {
                    temp[temp.Length - i - 1] = ch[ch.Length - i - 1];// O(1)
                }
            }
            else
            {
                for (int i = 0; i < size; i++)// O(1)
                {
                    temp[i] = ch[i];// O(1)
                }
            }

            return temp;// O(1)
        }

        public void PushBack(String str)// O(N)
        {
            if(this.size + str.Size() > this.ch.Length)// O(1)
            {
                ch = Expand(ch, this.ch.Length + str.Size());// O(N)
            }
            // O(N)
            for (int i = 0; i < str.Size(); i ++)// O(1)
            {
                ch[size++] = str[i]; // O(1)
            }
        }

        public void PushBack(string str)// O(N)
        {
            // O(1)
            if (this.size + str.Length > this.ch.Length)// O(1)
            {
                ch = Expand(ch, this.ch.Length + str.Length);// O(1)
            }
            // O(N)
            for (int i = 0; i < str.Length; i++)// O(1)
            {
                ch[size++] = str[i];// O(1)
            }
        }

        public void PushBack(char character)// O(1)
        {
            if (this.size + 1 > this.ch.Length)// O(1)
            {
                ch = Expand(ch, this.ch.Length * 2);// O(N)
            }

            ch[size++] = character;// O(1)
        }

        public void PopBack()// O(1)
        {
            size--;// O(1)
        }

        public void PushFront(String str)// O(1)
        {
            if (this.frontSize + str.Size() > this.frontCh.Length)// O(1)
            {
                frontCh = Expand(frontCh, this.frontCh.Length + str.Size(), true);// O(1)
            }

            for (int i = str.Size() - 1; i >= 0; i--)// O(1)
            {
                frontCh[frontCh.Length - ++frontSize] = str[i];// O(1)
            }
        }

        public void PushFront(string str)// O(N)
        {
            if (this.frontSize + str.Length > this.frontCh.Length)// O(1)
            {
                frontCh = Expand(frontCh, this.frontCh.Length + str.Length, true);// O(1)
            }
            // O(N)
            for (int i = str.Length - 1; i >= 0; i--)// O(1)
            {
                frontCh[frontCh.Length - ++frontSize] = str[i];// O(1)
            }
        }

        public void PushFront(char character)// O(1)
        {
            if (this.frontSize + 1 > this.frontCh.Length)// O(1)
            {
                frontCh = Expand(frontCh, this.frontCh.Length * 2, true);// O(1)
            }

            frontCh[frontCh.Length - ++frontSize] = character;// O(1)
        }

        public void PopFront()// O(1)
        {
            this.frontSize--;// O(1)
        }

        public string ToString()// O(N)
        {
            char[] temp = new char[this.Size()];// O(N)
            //O(N)
            for (int i = 0; i < this.Size(); i++)// O(1)
            {
                temp[i] = this[i];// O(1)
            }

            return new string(temp); //O(1)
        }
        public char[] ToCharArray()//O(N)
        {
            char[] temp = new char[this.Size()];//O(N)
            //O(N)
            for (int i = 0; i < this.Size(); i++)//O(1)
            {
                temp[i] = this[i];//O(1)
            }

            return temp;//O(1)
        }

        public char this[int i]
        {
            get 
            {
                if (i >= frontSize)//O(1)
                {
                    return ch[i - frontSize];//O(1)
                }

                return frontCh[frontCh.Length - frontSize + i];//O(1)
            }

            set 
            {
                if (i >= frontSize)//O(1)
                {
                    ch[i - frontSize] = value;//O(1)
                }
                else
                {
                    frontCh[frontCh.Length - frontSize + i] = value;//O(1)
                }
            }
        }

        public static String operator +(String a, String b)//O(N)
        {
            char[] temp = new char[a.Size() + b.Size()];//O(N)
            //O(N)
            for (int i = 0; i < a.Size(); i++)//O(1)
            {
                temp[i] = a[i];//O(1)
            }
            //O(N)
            for (int i = 0; i < b.Size(); i++)//O(1)
            {
                temp[a.Size() + i] = b[i];//O(1)
            }

            return new String(temp, false);//O(1)
        }

        public String Clone()
        {
            return new String(this.ToCharArray(), false);//O(N)
        }

    }
}
