using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography
{
    class String
    {
        private const int defaultSize = 650;
        private const int frontDefaultSize = 50;
        private char[] ch;
        private char[] frontCh;
        private int size = 0, frontSize = 0;

        public String()
        {
            ch = new char[defaultSize];
            frontCh = new char[frontDefaultSize];
            this.size = 0;
            this.frontSize = 0;
        }

        public String(int size, bool frontSize = false)
        {
            if(frontSize)
            {
                ch = new char[frontDefaultSize];
                frontCh = new char[size];
            }
            else
            {
                ch = new char[size];
                frontCh = new char[frontDefaultSize];
            }

            this.size = 0;
            this.frontSize = 0;
        }

        public String(string str)
        {
            ch = new char[str.Length];
            frontCh = new char[frontDefaultSize];
            this.frontSize = 0;

            for (int i = 0; i < str.Length; i++)
            {
                ch[size++] = str[i];
            }

        }


        public String(char []ch, bool copy = true)
        {
            frontCh = new char[frontDefaultSize];
            this.frontSize = 0;

            if (copy)
            {
                this.ch = new char[ch.Length];

                for (int i = 0; i < ch.Length; i++)
                {
                    this.ch[i] = ch[i];
                }
            }
            else
            {
                this.ch = ch;
            }

            size = this.ch.Length;
        }
        public void Assign(String str)
        {
            if(ch.Length < str.Size())
            {
                ch = Expand(ch, str.Size());
            }
              
            size = 0;

            for (int i = 0; i < str.Size(); i++)
            {
                ch[size++] = str[i];
            }

        }

        public int Size()
        {
            return frontSize + size;
        }

        public bool Equals(String str)
        {
            bool ok = (str.Size() == this.Size());

            for(int i = 0; i < str.Size() && ok; i ++)
            {
                ok &= (str[i] == this[i]);
            }

            return ok;
        }

        private char [] Expand(char[] ch, int newSize, bool reverse = false)
        {
            newSize = (newSize == 0 ? defaultSize : newSize);
            char[] temp = new char[newSize]; // +

            if (reverse)
            {
                for (int i = 0; i < frontSize; i++)
                {
                    temp[temp.Length - i - 1] = ch[ch.Length - i - 1];
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    temp[i] = ch[i];
                }
            }

            return temp;
        }

        public void PushBack(String str)
        {
            if(this.size + str.Size() > this.ch.Length)
            {
                ch = Expand(ch, this.ch.Length + str.Size());
            }

            for(int i = 0; i < str.Size(); i ++)
            {
                ch[size++] = str[i]; 
            }
        }

        public void PushBack(string str)
        {
            if (this.size + str.Length > this.ch.Length)
            {
                ch = Expand(ch, this.ch.Length + str.Length);
            }

            for (int i = 0; i < str.Length; i++)
            {
                ch[size++] = str[i];
            }
        }

        public void PushBack(char character)
        {
            if (this.size + 1 > this.ch.Length)
            {
                ch = Expand(ch, this.ch.Length * 2);
            }

            ch[size++] = character;
        }

        public void PopBack()
        {
            size--;
        }

        public void PushFront(String str)
        {
            if (this.frontSize + str.Size() > this.frontCh.Length)
            {
                frontCh = Expand(frontCh, this.frontCh.Length + str.Size(), true);
            }

            for (int i = str.Size() - 1; i >= 0; i--)
            {
                frontCh[frontCh.Length - ++frontSize] = str[i];
            }
        }

        public void PushFront(string str)
        {
            if (this.frontSize + str.Length > this.frontCh.Length)
            {
                frontCh = Expand(frontCh, this.frontCh.Length + str.Length, true);
            }

            for (int i = str.Length - 1; i >= 0; i--)
            {
                frontCh[frontCh.Length - ++frontSize] = str[i];
            }
        }

        public void PushFront(char character)
        {
            if (this.frontSize + 1 > this.frontCh.Length)
            {
                frontCh = Expand(frontCh, this.frontCh.Length * 2, true);
            }

            frontCh[frontCh.Length - ++frontSize] = character;
        }

        public void PopFront()
        {
            this.frontSize--;
        }

        public string ToString()
        {
            char[] temp = new char[this.Size()];

            for (int i = 0; i < this.Size(); i++)
            {
                temp[i] = this[i];
            }

            return new string(temp);
        }
        public char[] ToCharArray()
        {
            char[] temp = new char[this.Size()];

            for (int i = 0; i < this.Size(); i++)
            {
                temp[i] = this[i];
            }

            return temp;
        }

        public char this[int i]
        {
            get 
            {
                if (i >= frontSize)
                {
                    return ch[i - frontSize];
                }

                return frontCh[frontCh.Length - frontSize + i];
            }

            set 
            {
                if (i >= frontSize)
                {
                    ch[i - frontSize] = value;
                }
                else
                {
                    frontCh[frontCh.Length - frontSize + i] = value;
                }
            }
        }

        public static String operator +(String a, String b)
        {
            char[] temp = new char[a.Size() + b.Size()];

            for (int i = 0; i < a.Size(); i++)
            {
                temp[i] = a[i];
            }

            for (int i = 0; i < b.Size(); i++)
            {
                temp[a.Size() + i] = b[i];
            }

            return new String(temp, false);
        }

        public String Clone()
        {
            return new String(this.ToCharArray(), false);
        }

    }
}
