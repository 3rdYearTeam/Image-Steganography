using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography
{
    class Tools
    {
        static public int GetBit(int value, int i)
        {
            if ((value & (1 << i)) != 0)
                return 1;

            return 0;
        }
        static public int ClearBit(int value, int i)
        {
            value = value & (value ^ (1 << i));
            return value;
        }

        static public int SetBit(int value, int i)
        {
            value = ClearBit(value, i);
            value |= (1 << i);
            return value;
        }

        static public int SetBitValue(int value, int i, int x)
        {
            if (x != 0)
                value = SetBit(value, i);
            else
                value = ClearBit(value, i);

            return value;
        }
    }
}
